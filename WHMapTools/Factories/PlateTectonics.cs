using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHMapTools.Interfaces;
using WHMapTools.Factories.PlateCollision;

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

            if (this.Seed.HasValue)
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


        #endregion

    }
}
