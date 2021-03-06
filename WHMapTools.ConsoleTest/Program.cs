﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHMapTools.Factories;
using WHMapTools.Interfaces;
using WHMapTools.Maps;

namespace WHMapTools.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestCiv1Map();
            int times = 10;
            for(int i = 0; i <times; i++)
            {
                TestHeightMap(i);
            }
        }

        private static bool showChunks = false;
        private static bool showGeo = true;
        private static bool showTemperature = true;

        private static void TestCiv1Map(int i)
        {
            InitializeParams inip = new InitializeParams();
            inip.Parameters.Add(Enums.AlgorithmParameters.DEBUG, true);
            inip.Parameters.Add(Enums.AlgorithmParameters.DEBUGCHUNKITERATIONS, 9999);
            inip.Parameters.Add(Enums.AlgorithmParameters.LANDMASS, 1);
            Civilization1 factory = new Civilization1();
            factory.Notify += OnNotify;
            factory.Initialize(inip);
            IMap map = factory.Create();
            Image mapImage = map.Show();

            mapImage.Save("testCiv1Map" + i+".bmp", ImageFormat.Bmp);
        }

        private static void TestHeightMap(int i)
        {
            InitializeParams inip = new InitializeParams();
            //inip.Parameters.Add(Enums.AlgorithmParameters.DEBUG, true);
            //inip.Parameters.Add(Enums.AlgorithmParameters.DEBUGCHUNKITERATIONS, 9999);
            //inip.Parameters.Add(Enums.AlgorithmParameters.LANDMASS, 1);
            SquaredDiamond factory = new SquaredDiamond();
            //factory.Notify += OnNotify;
            factory.Initialize(inip);
            IMap map = factory.Create();
            Image mapImage = map.Show();

            mapImage.Save("testHeightMap" + i + ".bmp", ImageFormat.Bmp);
        }

        private static void OnNotify(object sender, Interfaces.NotifyEventArgs e)
        {
            if (e.Layer == 0 && showGeo)
            {
                Console.Out.WriteLineAsync("Actual map");
                PrintByteArray(e.Map);
            }
            else if (e.Layer == 1 && showTemperature)
            {
                Console.Out.WriteLineAsync("Temperature Map layer");
                PrintByteArray(e.Map);
            }
            else if(e.Layer == 8 && showChunks)
            {
                Console.Out.WriteLineAsync("Chunk layer");
                PrintByteArray(e.Map);
            }


        }

        private static void PrintByteArray(byte[,] p)
        {

            int dimH = p.GetLength(0);
            int dimW = p.GetLength(1);
            for (int i = 0; i < dimH; i++)
            {
                for (int j = 0; j < dimW; j++)
                {
                    Console.Out.Write(p[i, j]);
                }
                Console.Out.Write(Console.Out.NewLine);
            }
        }
    }
}
