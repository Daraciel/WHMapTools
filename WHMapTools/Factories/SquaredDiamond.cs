﻿using System;
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

            Divide(this.resultMap.maxIterations);



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

        private void Divide(int size)
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
                        offset = rnd.Next() * scale * 2 - scale;
                        Square(x, y, half, offset);
                    }
                }


                for (y = 0; y <= this.resultMap.maxIterations; y += half)
                {
                    for (x = (y + half) % size; x <= this.resultMap.maxIterations; x += size)
                    {
                        offset = rnd.Next() * scale * 2 - scale;
                        Diamond(x, y, half, offset);
                    }
                }

                Divide(half);
            }
        }

        private void Diamond(int x, int y, int size, float offset)
        {
            throw new NotImplementedException();
        }

        private void Square(int x, int y, int size, float offset)
        {
            throw new NotImplementedException();
        }

        private float Average(float[] values)
        {
            float result = 0;
            values = values.Where(p => p != -1).ToArray();
            result = values.Sum();
            result /

            return result;
        }

        private void InitializeHeightMap()
        {
            this.setValue(0, 0, this.resultMap.maxIterations);
            this.setValue(this.resultMap.maxIterations, 0, this.resultMap.maxIterations / 2);
            this.setValue(this.resultMap.maxIterations, this.resultMap.maxIterations, 0);
            this.setValue(0, this.resultMap.maxIterations, this.resultMap.maxIterations / 2);
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

        #endregion
    }
}