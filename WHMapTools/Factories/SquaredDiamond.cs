using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHMapTools.Enums;
using WHMapTools.Interfaces;
using WHMapTools.Maps;


namespace WHMapTools.Factories
{
    public class SquaredDiamond : IAlgorithm, INotifier
    {
        private const int MAX_RANDOM_VALUE = Int32.MaxValue / 2;

        #region EVENTS

        public event EventHandler<NotifyEventArgs> Notify;

        #endregion
        
        #region FIELDS

        private int Detail;
        private int? Seed;
        private float Roughness;
        private Random rnd;
        private bool Debug;

        private HeightMap resultMap;

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            this.resultMap = new HeightMap(this.Detail);

            InitializeHeightMap();

            Divide(this.resultMap.maxIterations, this.Roughness);

            NormalizeMap();

            return this.resultMap;
        }

        public override void Initialize(InitializeParams Params)
        {
            LoadDefaultValues();
            foreach (KeyValuePair<AlgorithmParameters, object> kvp in Params.Parameters)
            {
                switch (kvp.Key)
                {
                    case AlgorithmParameters.DETAIL:
                        Detail = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.ROUGHNESS:
                        Roughness = (float)kvp.Value;
                        break;
                    case AlgorithmParameters.SEED:
                        Seed = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.DEBUG:
                        Debug = (bool)kvp.Value;
                        break;
                }

            }

            if(this.Seed.HasValue)
            {
                rnd = new Random(this.Seed.Value);
            }
            else
            {
                rnd = new Random();
            }
        }

        #endregion

        #region PRIVATE METHODS

        private void LoadDefaultValues()
        {
            Detail = 9;
            Roughness = 0.7f;
            Seed = null;
            Debug = false;

        }

        private void Divide(int size, float slope)
        {
            int x, y, half;
            float offset;
            half = size / 2;
            float scale = this.Roughness * this.resultMap.side;
            if (half >= 1)
            {
                for (y = half; y < this.resultMap.maxIterations; y += size)
                {
                    for (x = half; x < this.resultMap.maxIterations; x += size)
                    {
                        offset = getOffset(slope);
                        Square(x, y, half, offset);
                    }
                }


                for (y = 0; y <= this.resultMap.maxIterations; y += half)
                {
                    for (x = (y + half) % size; x <= this.resultMap.maxIterations; x += size)
                    {
                        //offset = getRandomInt(MAX_RANDOM_VALUE) * scale * 2 - scale;

                        offset = getOffset(slope);
                        Diamond(x, y, half, offset);
                    }
                }

                slope *= this.Roughness;
                Divide(half, slope);
            }
        }

        private float getOffset(float slope)
        {
            return getRandomInt(MAX_RANDOM_VALUE) * slope;
        }

        private void Diamond(int x, int y, int size, float offset)
        {
            float newValue;
            float[] values = new float[] {
                                            this.getValue(x, y - size),
                                            this.getValue(x + size, y),
                                            this.getValue(x, y + size),
                                            this.getValue(x - size, y)
                };
            newValue = this.Average(values) + offset;

            this.setValue(x, y, newValue);
        }

        private void Square(int x, int y, int size, float offset)
        {
            float newValue;
            float[] values = new float[] {
                                            this.getValue(x - size, y - size),
                                            this.getValue(x + size, y - size),
                                            this.getValue(x + size, y + size),
                                            this.getValue(x - size, y + size)
                };
            newValue = this.Average(values) + offset;

            this.setValue(x, y, newValue);
        }

        private float Average(float[] values)
        {
            float result = 0;
            values = values.Where(p => p != -1).ToArray();
            result = values.Sum();
            result /= values.Length;

            return result;
        }

        private void InitializeHeightMap()
        {
            this.setValue(0, 0, 0);
            this.setValue(this.resultMap.maxIterations, 0, 0);
            this.setValue(this.resultMap.maxIterations, this.resultMap.maxIterations, 0);
            this.setValue(0, this.resultMap.maxIterations, 0);
        }

        private int getRandomInt(int limit)
        {
            int result = 0;

            result = rnd.Next(-limit, limit);

            return result;
        }

        private void setValue(int x, int y, float value)
        {
            this.resultMap.heightmap[x + this.resultMap.side * y] = value;
        }

        private float getValue(int x, int y)
        {
            float result = -1;
            if (x >= 0 && 
                x <= this.resultMap.maxIterations && 
                y >= 0 && 
                y <= this.resultMap.maxIterations)
            {
                result = this.resultMap.heightmap[x + this.resultMap.side * y];
            }

            return result;
        }

        private void NormalizeMap()
        {
            float lowest = this.resultMap.heightmap.Min();
            float highest = this.resultMap.heightmap.Max();
            for(int i=0; i<this.resultMap.heightmap.Length; i++)
            {
                this.resultMap.heightmap[i] = (this.resultMap.heightmap[i] - lowest) / (highest - lowest);
            }
        }

        #endregion
    }
}
