using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHMapTools.Interfaces;
using WHMapTools.Factories.PlateCollision;
using WHMapTools.Enums;
using WHMapTools.Maps;

namespace WHMapTools.Factories
{
    public class PlateTectonics : IAlgorithm, INotifier
    {

        #region CONSTANTS

        private const int MAX_RANDOM_VALUE = Int32.MaxValue / 2;

        #endregion

        #region EVENTS

        public event EventHandler<NotifyEventArgs> Notify;

        #endregion

        #region FIELDS

        private HeightMap BaseMap;

        private Tuple<int, int> Size;
        private int? Seed;
        private Random rnd;
        private float SeaLevel;
        private uint ErosionPeriod;
        private float FoldingRatio;
        private uint AggregationCount;
        private float AggregationPercentage;
        private uint MaxCycles;




        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            throw new NotImplementedException();
        }

        public override void Initialize(InitializeParams Params)
        {
            LoadDefaultValues();
            foreach (KeyValuePair<AlgorithmParameters, object> kvp in Params.Parameters)
            {
                switch (kvp.Key)
                {
                    case AlgorithmParameters.BASEMAP:
                        if (Size != null)
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            BaseMap = (HeightMap)kvp.Value;
                        }
                        break;
                    case AlgorithmParameters.SEED:
                        Seed = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.SIZE:
                        if (BaseMap != null)
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            Size = (Tuple<int, int>)kvp.Value;
                        }
                        break;
                    case AlgorithmParameters.SEALEVEL:
                        SeaLevel = (float)kvp.Value;
                        break;
                    case AlgorithmParameters.EROSIONPERIOD:
                        ErosionPeriod = (uint)kvp.Value;
                        break;
                    case AlgorithmParameters.FOLDINGRATIO:
                        FoldingRatio = (float)kvp.Value;
                        break;
                    case AlgorithmParameters.AGGREGATIONCOUNT:
                        AggregationCount = (uint)kvp.Value;
                        break;
                    case AlgorithmParameters.AGGREGATIONPERCENTAGE:
                        AggregationPercentage = (float)kvp.Value;
                        break;
                    case AlgorithmParameters.MAXCYCLES:
                        MaxCycles = (uint)kvp.Value;
                        break;
                    case AlgorithmParameters.DEBUG:
                        Debug = (bool)kvp.Value;
                        break;
                }

            }

            if (this.Seed.HasValue)
            {
                rnd = new Random(this.Seed.Value);
            }
            else
            {
                rnd = new Random();
            }
        }

        private void LoadDefaultValues()
        {
            Size = new Tuple<int, int>(512, 512);
            Seed = null;
            SeaLevel = 0.5f;
            ErosionPeriod = 10;
            Debug = false;
            FoldingRatio = 0.5f;
            AggregationCount = 5;
            AggregationPercentage = 0.5f;
            MaxCycles = 100;
        }

        #endregion

        #region PRIVATE METHODS


        #endregion

    }
}
