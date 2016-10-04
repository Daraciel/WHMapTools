
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WHMapTools.Interfaces
{
    /**
     * 
     */
    public abstract class IAlgorithm
    {

        protected bool Debug;

        /**
         * 
         */
        public IAlgorithm()
        {
        }


        /**
         * @param params 
         * @return
         */
        public abstract void Initialize(InitializeParams Params);

        /**
         * @return
         */
        public abstract IMap Create();

    }
}

