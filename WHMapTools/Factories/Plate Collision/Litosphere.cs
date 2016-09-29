using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Factories.PlateCollision
{
    internal class Litosphere
    {

        #region CONSTANTS

        private const uint BOOL_REGENERATE_CRUST = 1;
        private const float CONTINENTAL_BASE = 1.0f;
        private const float OCEANIC_BASE = 1.0f;

        #endregion

        #region CONSTRUCTORS

        public Litosphere(  uint mapSideLength, float seaLevel,
                            uint erosionPeriod, float foldingRatio,
                            uint aggrRatioAbs, float aggrRatioRel,
                            uint numCycles)
        {
            this.mapSide = mapSideLength;
            this.erosionPeriod = erosionPeriod;
            this.foldingRatio = foldingRatio;
            this.aggregationCount = aggrRatioAbs;
            this.aggregationPercentage = aggrRatioRel;
            this.maxCycles = numCycles;

            throw new NotImplementedException();
        }

        #endregion

        #region FIELDS

        private float[,] heightMap;
        private uint[,] plateMap;
        private Plate[,] plates;

        private uint aggregationCount;
        private float aggregationPercentage;
        private uint cycleCount;
        private uint erosionPeriod;
        private float foldingRatio;
        private uint iterationCount;
        private uint mapSide;
        private uint maxCycles;
        private uint numPlates;

        private List<List<PlateCollision>> collisions;
        private List<List<PlateCollision>> subductions;

        private float peakEk;
        private uint lastCollisionCount;

        #endregion

        #region PROPERTIES

        public uint CycleCount
        {
            get
            {
                return cycleCount;
            }
        }

        public uint IterationCount
        {
            get
            {
                return iterationCount;
            }
        }

        public uint NumPlates
        {
            get
            {
                return numPlates;
            }
        }

        public float[,] HeightMap
        {
            get
            {
                return heightMap;
            }
        }

        #endregion

        #region PUBLIC METHODS

        private void createPlates(uint numPlates)
        {
            throw new NotImplementedException();
        }

        private void update()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region PRIVATE METHODS

        private void restart()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
