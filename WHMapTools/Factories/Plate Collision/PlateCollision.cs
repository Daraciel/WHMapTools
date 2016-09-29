using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Factories.PlateCollision
{
    internal class PlateCollision
    {

        #region CONSTANTS

        #endregion

        #region CONSTRUCTORS

        public PlateCollision(uint index, Point location, float amount)
        {
            this.index = index;
            this.collisionPoint = location;
            this.crustAmount = amount;
        }

        #endregion

        #region FIELDS

        private uint index;
        private Point collisionPoint;
        private float crustAmount;

        #endregion

        #region PROPERTIES

        public uint Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public Point CollisionPoint
        {
            get
            {
                return collisionPoint;
            }

            set
            {
                collisionPoint = value;
            }
        }

        public float CrustAmount
        {
            get
            {
                return crustAmount;
            }

            set
            {
                crustAmount = value;
            }
        }

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}
