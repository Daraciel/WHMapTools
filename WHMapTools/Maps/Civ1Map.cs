using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using WHMapTools.Enums;
using WHMapTools.Interfaces;

namespace WHMapTools.Maps
{
    /**
     * 
     */
    public class Civ1Map : IMap
    {

        #region PROPERTIES

        public Civ1MapLayer[] Layers { get; set; }

        #endregion

        #region FIELDS

        private Dictionary<Civ1MapLandTypes, Color> Colors;

        #endregion

        #region CONSTRUCTORS

        public Civ1Map()
        {
            InitColors();
        }
        public Civ1Map(Tuple<int, int> size)
        {
            this.Size = size;
            Layers = new Civ1MapLayer[10];
            for(int i=0; i<Layers.Length; i++)
            {
                Layers[i] = new Civ1MapLayer(size);
            }
            InitColors();

        }

        #endregion

        #region IMAP

        public override Image Show()
        {
            int expandW = 4;
            int expandH = 4;
            Bitmap result = new Bitmap(((Size.Item2 + 0) * expandH) + 200, ((Size.Item1 + 0) * expandW) + 20);
            //Image result = new Bitmap(Size.Item2 * expandH, Size.Item1 * expandW);
            Image temp = null;
            using(var graphics = Graphics.FromImage(result))
            {
                graphics.FillRectangle(Brushes.Black, 0, 0, result.Width, result.Height);
                temp = CreateMapImage(expandW, expandH);
                graphics.DrawImageUnscaled(temp, 10, 10);
                temp = CreateLegend(expandW, expandH);
                graphics.DrawImageUnscaled(temp, (Size.Item2 * expandH) + 50, 10);
            }

            return result;
        }

        private Image CreateLegend(int expandW, int expandH)
        {
            Bitmap result = new Bitmap(Size.Item2/3 * expandH, Size.Item1 * expandW);
            int pixelsperslot = (Size.Item1 * expandW)/16;



            return result;
        }

        private Image CreateMapImage(int expandW, int expandH)
        {
            Bitmap result = new Bitmap(Size.Item2 * expandH, Size.Item1 * expandW);
            Color c;

            int dimH = Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            for (int i = 0; i < dimH; i++)
            {
                for (int j = 0; j < dimW; j++)
                {
                    c = GetColorByLandType(Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j]);
                    for (int k = 0; k < expandH; k++)
                    {
                        for (int l = 0; l < expandW; l++)
                        {
                            result.SetPixel((j * expandW) + l, (i * expandH) + k, c);
                        }
                    }
                }
            }

            return result;
        }

        private Color GetColorByLandType(byte LandType)
        {
            Color result;
            Colors.TryGetValue((Civ1MapLandTypes)LandType,out result);
            return result;
        }

        #endregion


        #region PRIVATE METHODS



        private void InitColors()
        {
            Colors = new Dictionary<Civ1MapLandTypes, Color>();
            Colors.Add(Civ1MapLandTypes.NA, Color.FromArgb(255, 0, 0, 0));
            Colors.Add(Civ1MapLandTypes.OCEAN, Color.FromArgb(255, 0, 0, 127));
            Colors.Add(Civ1MapLandTypes.FOREST, Color.FromArgb(255, 0, 127, 0));
            Colors.Add(Civ1MapLandTypes.SWAMP, Color.FromArgb(255, 0, 127, 127));
            Colors.Add(Civ1MapLandTypes.NA2, Color.FromArgb(255, 127, 0, 0));
            Colors.Add(Civ1MapLandTypes.NA3, Color.FromArgb(255, 127, 0, 127));
            Colors.Add(Civ1MapLandTypes.PLAIN, Color.FromArgb(255, 127, 127, 0));
            Colors.Add(Civ1MapLandTypes.TUNDRA, Color.FromArgb(255, 191, 191, 191));
            Colors.Add(Civ1MapLandTypes.NA4, Color.FromArgb(255, 127, 127, 127));
            Colors.Add(Civ1MapLandTypes.RIVER, Color.FromArgb(255, 0, 0, 255));
            Colors.Add(Civ1MapLandTypes.GRASSLAND, Color.FromArgb(255, 0, 255, 0));
            Colors.Add(Civ1MapLandTypes.JUNGLE, Color.FromArgb(255, 0, 255, 255));
            Colors.Add(Civ1MapLandTypes.HILL, Color.FromArgb(255, 255, 0, 0));
            Colors.Add(Civ1MapLandTypes.MOUNTAIN, Color.FromArgb(255, 255, 0, 255));
            Colors.Add(Civ1MapLandTypes.DESERT, Color.FromArgb(255, 255, 255, 0));
            Colors.Add(Civ1MapLandTypes.ARCTIC, Color.FromArgb(255, 255, 255, 255));
        }


        #endregion

    }
}