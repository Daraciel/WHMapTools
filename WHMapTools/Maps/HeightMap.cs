using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WHMapTools.Enums;
using WHMapTools.Interfaces;

namespace WHMapTools.Maps
{
    public class HeightMap : IMap
    {

        #region PROPERTIES

        public float[] heightmap;

        public int side;

        public int maxIterations;

        #endregion

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        public HeightMap(int detail)
        {
            this.side = (int)Math.Pow(2, detail) + 1;
            this.maxIterations = this.side - 1;
            this.Size = new Tuple<int, int>(this.side, this.side);
            this.heightmap = new float[this.Size.Item1 * this.Size.Item2];
        }

        #endregion

        #region IMAP

        public override Image Show()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}
