using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Factories.PlateCollision
{
    internal class SegmentData
    {

        #region CONSTANTS

        #endregion

        #region CONSTRUCTORS

        internal SegmentData(Point tlCorner, Point brCorner, uint a, uint collCount)
        {
            this.topLeftCorner = tlCorner;
            this.bottomRightCorner = brCorner;
            this.area = a;
            this.collisionCount = collCount;
        }

        #endregion

        #region FIELDS

        private Point topLeftCorner;
        private Point bottomRightCorner;
        private uint area;
        private uint collisionCount;

        #endregion

        #region PROPERTIES

        public Point TopLeftCorner
        {
            get
            {
                return topLeftCorner;
            }

            set
            {
                topLeftCorner = value;
            }
        }

        public Point BottomRightCorner
        {
            get
            {
                return bottomRightCorner;
            }

            set
            {
                bottomRightCorner = value;
            }
        }

        public uint Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public uint CollisionCount
        {
            get
            {
                return collisionCount;
            }

            set
            {
                collisionCount = value;
            }
        }

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        #endregion
        
    }
}
