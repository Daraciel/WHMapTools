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
            throw new NotImplementedException();
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

        private void setValue(int x, int y, float value)
        {
            this.resultMap.heightmap[x + this.resultMap.side * y] = value;
        }

        #endregion
    }
}
