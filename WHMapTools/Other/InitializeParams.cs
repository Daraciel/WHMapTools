using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHMapTools.Enums;

namespace WHMapTools
{
    /**
     * 
     */
    public class InitializeParams
    {

        /**
         * 
         */
        public InitializeParams()
        {
            Parameters = new Dictionary<AlgorithmParameters, object>();
        }

        /**
         * 
         */
        public Dictionary<AlgorithmParameters, object> Parameters { get; set; }


    }
}
