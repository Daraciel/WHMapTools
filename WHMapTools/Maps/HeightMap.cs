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

            float maxHeight = this.heightmap.Max();

            float minHeight = this.heightmap.Min();
            int bnColor;
            Bitmap result = new Bitmap(this.side, this.side);
            Image temp = null;
            Color c;
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.FillRectangle(Brushes.Red, 0, 0, result.Width, result.Height);
                for (int x = 0; x < this.side; x++)
                {
                    for (int y = 0; y < this.side; y++)
                    {
                        bnColor = (int)((this.heightmap[x + this.side * y] / maxHeight) * 255);
                        c = Color.FromArgb(bnColor, bnColor, bnColor);
                        result.SetPixel(x,y, c);
                    }
                }
            }
            return result;
        }

        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}
