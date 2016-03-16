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
    /**
     * 
     */
    public class Civilization1 : IAlgorithm, INotifier
    {
        #region CONSTANTS

        //private Tuple<Point, Point> ChunkRange = new Tuple<Point, Point>(new Point(4, 8), new Point(71, 33));
        private Tuple<Point, Point> StaringPosRange = new Tuple<Point, Point>(new Point(8, 4), new Point(33, 71));
        private Tuple<Point, Point> ChunkRange = new Tuple<Point, Point>(new Point(3, 3), new Point(45, 76));
        private Tuple<int, int> PathLengthRange = new Tuple<int, int>(1, 64);

        #endregion

        #region EVENTS

        public event EventHandler<NotifyEventArgs> Notify;

        

        #endregion

        #region CONSTRUCTORS

        public Civilization1()
        {
        }

        #endregion

        #region FIELDS

        private int LandMass;
        private int Temperature;
        private int Age;
        private int Climate;
        private int? Seed;
        private Tuple<int, int> Size;
        private Random rnd;
        private bool Debug;
        private int DebugChunkIterations;

        private Civ1Map resultMap;
        private Dictionary<Civ1MapLandTypes, Color> Colors;

        #endregion

        #region IALGORITHM

        public override IMap Create()
        {
            resultMap = new Civ1Map(Size);

            if(Seed.HasValue)
            {
                rnd = new Random(Seed.Value);
            }
            else
            {
                rnd = new Random();
            }

            GenerateLandMass();

            AdjustTemperature();

            AdjustClimate();

            AdjustAge();

            GenerateRivers();

            ComputeDataRelatedData();

            GeneratePoles();

            return resultMap;
        }

        public override void Initialize(InitializeParams Params)
        {
            LoadDefaultValues();
            foreach(KeyValuePair<AlgorithmParameters, object> kvp in Params.Parameters)
            {
                switch(kvp.Key)
                {
                    case AlgorithmParameters.LANDMASS:
                        LandMass = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.TEMPERATURE:
                        Temperature = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.CLIMATE:
                        Climate = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.AGE:
                        Age = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.SEED:
                        Seed = (int)kvp.Value;
                        break;
                    case AlgorithmParameters.SIZE:
                        Size = (Tuple<int, int>)kvp.Value;
                        break;
                    case AlgorithmParameters.DEBUG:
                        Debug = (bool)kvp.Value;
                        break;
                    case AlgorithmParameters.DEBUGCHUNKITERATIONS:
                        DebugChunkIterations = (int)kvp.Value;
                        break;
                }

            }
        }

        #endregion

        #region PRIVATE METHODS

        private void LoadDefaultValues()
        {
            LandMass = 1;
            Temperature = 1;
            Climate = 1;
            Age = 1;
            Seed = null;
            //Size = new Tuple<int, int>(200, 330);
            Size = new Tuple<int, int>(50, 80);
            DebugChunkIterations = 32;
            Debug = false;

        }

        private void GenerateLandMass()
        {
            int debugcount = DebugChunkIterations;
            do
            {
                GenerateRandomChunk();
                MergeStencilArea();
                if(Debug) debugcount--;

            } while (!IsSufficientLandMass() && debugcount>0);
            CorrectNarrowPassages();
        }

        #region LANDMASS-RELATED METHODS

        private void GenerateRandomChunk()
        {
            resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Initialize();
            Point currentPosition = GetRandomValueBetweenRange(StaringPosRange);
            int pathLength = GetRandomValueBetweenRange(PathLengthRange);

            SetPositionAsLandInChunk(currentPosition);
            while (pathLength > 0 && IsChunkInBounds(currentPosition, ChunkRange))
            {
                MovePointToARandomNeighbour(ref currentPosition, false);
                SetPositionAsLandInChunk(currentPosition);
                pathLength--;
            }
            
            if(Notify != null && Debug)
            {
                Notify(this, new NotifyEventArgs() { Layer = (int)Civ1MapLayers.STENCILLAYER, Map = resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values });
            }


        }

        private int GetRandomValueBetweenRange(Tuple<int, int> range)
        {
            int result = rnd.Next(range.Item1, range.Item2 + 1);

            return result;
        }

        private Point GetRandomValueBetweenRange(Tuple<Point, Point> range)
        {
            int x = rnd.Next(range.Item1.X, range.Item2.X + 1);
            int y = rnd.Next(range.Item1.Y, range.Item2.Y + 1);
            Point result = new Point(x, y);

            return result;
        }

        private bool IsChunkInBounds(Point currentPosition, Tuple<Point, Point> ChunkRange)
        {
            bool result = false;
            if(IsInRange(currentPosition, ChunkRange))
            {
                if (IsInRange(new Point(currentPosition.X+1, currentPosition.Y), ChunkRange))
                {
                    if (IsInRange(new Point(currentPosition.X, currentPosition.Y + 1), ChunkRange))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool IsInRange(Point currentPosition, Tuple<Point, Point> ChunkRange)
        {
            bool result = false;
            if (currentPosition.X >= ChunkRange.Item1.X && currentPosition.X <= ChunkRange.Item2.X)
            {
                if (currentPosition.Y >= ChunkRange.Item1.Y && currentPosition.Y <= ChunkRange.Item2.Y)
                {
                    result = true;
                }
            }

            return result;
        }

        private void MovePointToARandomNeighbour(ref Point currentPosition, bool IsCompleteNeighbour)
        {
            Point futurePosition;
            int upperRange = 5;
            if(IsCompleteNeighbour)
            {
                upperRange = 9;
            }
            do
            {

                futurePosition = currentPosition;
                int toMove = rnd.Next(1, upperRange);
                switch (toMove)
                {
                    case 1: //Move N
                        futurePosition.X--;
                        break;
                    case 2: //Move S
                        futurePosition.X++;
                        break;
                    case 3: //Move W
                        futurePosition.Y--;
                        break;
                    case 4: //Move E
                        futurePosition.Y++;
                        break;
                    case 5: //Move NW
                        futurePosition.X--;
                        futurePosition.Y--;
                        break;
                    case 6: //Move NE
                        futurePosition.X--;
                        futurePosition.Y++;
                        break;
                    case 7: //Move SW
                        futurePosition.X++;
                        futurePosition.Y--;
                        break;
                    case 8: //Move SE
                        futurePosition.X++;
                        futurePosition.Y++;
                        break;

                }
            } while (futurePosition.X < 0 ||
                    futurePosition.Y < 0 ||
                    futurePosition.X >= Size.Item1 ||
                    futurePosition.Y >= Size.Item2);
            currentPosition = futurePosition;
            
        }

        private void SetPositionAsLandInChunk(Point currentPosition)
        {
            resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.X, currentPosition.Y] = 1;
            resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.X, currentPosition.Y + 1] = 1;
            resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.X + 1, currentPosition.Y] = 1;

            //resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.Y, currentPosition.X] = 1;
            //resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.Y, currentPosition.X + 1] = 1;
            //resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[currentPosition.Y + 1, currentPosition.X] = 1;
        }

        private void MergeStencilArea()
        {

            int dimH = resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values.GetLength(1);
            Parallel.For(0, dimH, y =>
            {
                Parallel.For(0, dimW, x =>
                {
                    if (resultMap.Layers[(int)Civ1MapLayers.STENCILLAYER].Values[y, x] == 1)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[y, x]++;
                    }
                });
            });

            //if (Notify != null && Debug)
            //{
            //    Notify(this, new NotifyEventArgs() { Layer = (int)Civ1MapLayers.GEOLAYER, Map = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values });
            //}
        }

        private bool IsSufficientLandMass()
        {
            int totalLandMass = 0;
            int threshold = 0;
            bool result = false;

            totalLandMass = GetTotalLandMass(ref resultMap.Layers[(int)Civ1MapLayers.GEOLAYER]);
            threshold = ( LandMass + 2 ) * 320;

            if(totalLandMass >= ( ( LandMass + 2 ) * 320))
            {
                result = true;
            }

            return result;
        }

        private int GetTotalLandMass(ref Civ1MapLayer civ1MapLayer)
        {
            int dimH = civ1MapLayer.Values.GetLength(0);
            int dimW = civ1MapLayer.Values.GetLength(1);
            int result = 0;
            for (int i = 0; i < dimH; i++)
            {
                for (int j = 0; j < dimW; j++)
                {
                    if (civ1MapLayer.Values[i,j] > 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        private void CorrectNarrowPassages()
        {
            int dimH = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            for (int i = 0; i < dimH-1; i++)
            {
                for (int j = 0; j < dimW-1; j++)
                {
                    if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] > 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j] == 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j + 1] == 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j + 1] > 0)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j] = 1;
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j + 1] = 1;
                    }
                    else if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] == 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j] > 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j + 1] > 0 &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j + 1] == 0)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i + 1, j + 1] = 1;
                    }
                }
            }

            if (Notify != null && Debug)
            {
                Notify(this, new NotifyEventArgs() { Layer = (int)Civ1MapLayers.GEOLAYER, Map = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values });
            }
        }

        #endregion

        private void AdjustTemperature()
        {

            int dimH = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            int temperature = 0;
            for (int i = 0; i < dimH; i++)
            {
                for (int j = 0; j < dimW; j++)
                {
                    if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] == 1)
                    {
                        temperature = GetTemperatureByLatitude(i);
                        switch(temperature)
                        {
                            case 0:
                            case 1://DESERT
                                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.DESERT;
                                break;
                            case 2:
                            case 3://PLAINS
                                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.PLAIN;
                                break;
                            case 4:
                            case 5://TUNDRA
                                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.TUNDRA;
                                break;
                            case 6:
                            case 7://ARCTIC
                                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.ARCTIC;
                                break;
                            default:
                                throw new IndexOutOfRangeException("admitted range [0..7] and number is: "+temperature);
                                break;
                        }
                    }
                    else if(resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] == 2)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.MOUNTAIN;
                    }
                    else if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] > 2)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.HILL;
                    }
                    else
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.OCEAN;
                    }
                }
            }

            if (Notify != null && Debug)
            {
                Notify(this, new NotifyEventArgs() { Layer = (int)Civ1MapLayers.TEMPERATURELAYER, Map = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values });
            }
        }

        #region TEMPERATURE-RELATED METHODS

        private int GetTemperatureByLatitude(int i)
        {
            int result = 0;
            result = i;
            result -= 29;
            result += rnd.Next(0, 8);
            result = Math.Abs(result);
            result += (1 - Temperature);
            result /= 6;
            result += 1;

            return result;
        }

        #endregion

        private void AdjustClimate()
        {
            int dimH = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            int rowWetness;
            int rowLatitude;
            int squareWetness;
            int rainfall;
            for (int i = 0; i < dimH; i++)
            {
                rowWetness = 0;
                rowLatitude = 25 - i;
                for (int j = 0; j < dimW; j++)
                {
                    if(resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] == (byte)Civ1MapLandTypes.OCEAN)
                    {
                        squareWetness = GetSquareWetnessFromWest(rowLatitude);
                        if(squareWetness > rowWetness)
                        {
                            rowWetness++;
                        }
                        else if(rowWetness > 0)
                        {
                            rainfall = GetRainfall();
                            rowWetness -= rainfall;
                            switch(resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j])
                            {
                                case (byte)Civ1MapLandTypes.PLAIN:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.GRASSLAND;
                                    break;
                                case (byte)Civ1MapLandTypes.TUNDRA:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.ARCTIC;
                                    break;
                                case (byte)Civ1MapLandTypes.HILL:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.FOREST;
                                    break;
                                case (byte)Civ1MapLandTypes.DESERT:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.PLAIN;
                                    break;
                                case (byte)Civ1MapLandTypes.MOUNTAIN:
                                    rowWetness -= 3;
                                    break;
                            }
                            //try to rainfall
                        }
                    }
                }

                rowWetness = 0;
                for (int j = dimW-1; j >= 0; j--)
                {

                    if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] == (byte)Civ1MapLandTypes.OCEAN)
                    {
                        squareWetness = GetSquareWetnessFromEast(rowLatitude);
                        if (squareWetness > rowWetness)
                        {
                            rowWetness++;
                        }
                        else if (rowWetness > 0)
                        {
                            rainfall = GetRainfall();
                            rowWetness -= rainfall;
                            switch (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j])
                            {
                                case (byte)Civ1MapLandTypes.SWAMP:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.FOREST;
                                    break;
                                case (byte)Civ1MapLandTypes.PLAIN:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.GRASSLAND;
                                    break;
                                case (byte)Civ1MapLandTypes.GRASSLAND:
                                    rowWetness -= 2;
                                    if (rowLatitude < 10)
                                    {
                                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.JUNGLE;
                                    }
                                    else
                                    {
                                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.SWAMP;
                                    }
                                    break;
                                case (byte)Civ1MapLandTypes.HILL:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.FOREST;
                                    break;
                                case (byte)Civ1MapLandTypes.DESERT:
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.PLAIN;
                                    break;
                                case (byte)Civ1MapLandTypes.MOUNTAIN:
                                    rowWetness -= 3;
                                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[i, j] = (byte)Civ1MapLandTypes.FOREST;
                                    break;
                            }
                            //try to rainfall
                        }
                    }
                }
            }

            if (Notify != null && Debug)
            {
                Notify(this, new NotifyEventArgs() { Layer = (int)Civ1MapLayers.CLIMATELAYER, Map = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values });
            }
        }

        #region CLIMATE-RELATED METHODS

        private int GetSquareWetnessFromWest(int i)
        {
            int result = 0;
            result += Math.Abs(i - 12);
            result += Climate * 4;

            return result;
        }

        private int GetSquareWetnessFromEast(int i)
        {
            int result = 0;
            result += i/2;
            result += Climate;

            return result;
        }

        private int GetRainfall()
        {
            int result = 0;
            int highervalue = 7 - Climate * 2;
            result = rnd.Next(0, highervalue);

            return result;
        }

        #endregion

        private void AdjustAge()
        {
            int iterationsNumber = GetIterationsNumber();
            bool isEven = false;
            Point currentPosition = new Point();

            isEven = true;
            for(int i=0; i<iterationsNumber; i++)
            {
                if(isEven)
                {
                    isEven = false;
                    do
                    {
                        currentPosition = SelectRandomPoint();
                    }while(!IsLandSquare(currentPosition));
                }
                else
                {
                    isEven = true;
                    MovePointToARandomNeighbour(ref currentPosition, true);
                }
                ErodePoint(currentPosition);
            }
        }

        private bool IsLandSquare(Point currentPosition)
        {
            bool result = false;
            if(resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] != 0)
            {
                result = true;
            }
            return result;
        }

        #region AGE-RELATED METHODS

        private int GetIterationsNumber()
        {
            int result = 0;
            result = 800 * (1 + Age);

            return result;
        }

        private Point SelectRandomPoint()
        {
            int i = rnd.Next(0, Size.Item1);
            int j = rnd.Next(0, Size.Item2);
            Point result = new Point(i, j);

            return result;
        }

        private void ErodePoint(Point currentPosition)
        {
            switch (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y])
            {
                case (byte)Civ1MapLandTypes.FOREST:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.JUNGLE;
                    break;
                case (byte)Civ1MapLandTypes.SWAMP:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.GRASSLAND;
                    break;
                case (byte)Civ1MapLandTypes.PLAIN:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.HILL;
                    break;
                case (byte)Civ1MapLandTypes.TUNDRA:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.HILL;
                    break;
                case (byte)Civ1MapLandTypes.GRASSLAND:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.FOREST;
                    break;
                case (byte)Civ1MapLandTypes.JUNGLE:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.SWAMP;
                    break;
                case (byte)Civ1MapLandTypes.HILL:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.MOUNTAIN;
                    break;
                case (byte)Civ1MapLandTypes.MOUNTAIN:
                    if (resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X - 1, currentPosition.Y - 1] != (byte)Civ1MapLandTypes.OCEAN &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X - 1, currentPosition.Y + 1] != (byte)Civ1MapLandTypes.OCEAN &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X + 1, currentPosition.Y - 1] != (byte)Civ1MapLandTypes.OCEAN &&
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X + 1, currentPosition.Y + 1] != (byte)Civ1MapLandTypes.OCEAN)
                    {
                        resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                            (byte)Civ1MapLandTypes.OCEAN;
                    }
                    break;
                case (byte)Civ1MapLandTypes.DESERT:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.PLAIN;
                    break;
                case (byte)Civ1MapLandTypes.ARCTIC:
                    resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[currentPosition.X, currentPosition.Y] =
                        (byte)Civ1MapLandTypes.MOUNTAIN;
                    break;
            }
        }

        #endregion

        private void GenerateRivers()
        {
        }

        private void ComputeDataRelatedData()
        {
        }

        private void GeneratePoles()
        {
            SetBasicPoles();
            SetPoleTundra();
        }

        #region POLE-GENERATING-RELATED METHODS

        private void SetBasicPoles()
        {
            int dimH = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            for(int i = 0; i< dimW; i++)
            {
                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[0, i] = (byte)Civ1MapLandTypes.ARCTIC;
                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[dimH - 1, i] = (byte)Civ1MapLandTypes.ARCTIC;
            }
        }

        private void SetPoleTundra()
        {
            int poleSquareChanges = 20;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int dimH = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(0);
            int dimW = resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values.GetLength(1);
            for (int i = 0; i < poleSquareChanges; i++)
            {
                a = rnd.Next(0, dimW - 1);
                b = rnd.Next(0, dimW - 1);
                c = rnd.Next(0, dimW - 1);
                d = rnd.Next(0, dimW - 1);

                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[0, a] = (byte)Civ1MapLandTypes.TUNDRA;
                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[1, b] = (byte)Civ1MapLandTypes.TUNDRA;
                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[dimH-1, c] = (byte)Civ1MapLandTypes.TUNDRA;
                resultMap.Layers[(int)Civ1MapLayers.GEOLAYER].Values[dimH-2, d] = (byte)Civ1MapLandTypes.TUNDRA;
            }
        }

        #endregion

        #endregion

    }
}