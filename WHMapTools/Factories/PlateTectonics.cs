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
        public event EventHandler<NotifyEventArgs> Notify;

        public override IMap Create()
        {
            throw new NotImplementedException();
        }

        public override void Initialize(InitializeParams Params)
        {
            throw new NotImplementedException();
        }
    }
}
