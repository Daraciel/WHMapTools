using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Factories.PlateCollision
{
    internal class PlateArea
    {

        #region CONSTANTS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region FIELDS

        private List<uint> border;
        private uint bottom;
        private uint left;
        private uint right;
        private uint top;
        private uint width;
        private uint height;

        #endregion

        #region PROPERTIES

        public List<uint> Border
        {
            get
            {
                return border;
            }

            set
            {
                border = value;
            }
        }

        public uint Bottom
        {
            get
            {
                return bottom;
            }

            set
            {
                bottom = value;
            }
        }

        public uint Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        public uint Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        public uint Top
        {
            get
            {
                return top;
            }

            set
            {
                top = value;
            }
        }

        public uint Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public uint Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}
