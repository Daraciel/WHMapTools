using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WHMapTools.Interfaces
{
    public abstract class IMap : IDibujable
    {
        #region CONSTRUCTORS

        public IMap()
        {
        }

        #endregion

        #region PROPERTIES

        public Tuple<int, int> Size { get; set; }

        #endregion

        #region IDIBUJABLE

        public abstract Image Show();

        #endregion

    }
}