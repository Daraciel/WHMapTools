using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Factories.PlateCollision
{
    internal class Plate
    {

        #region CONSTANTS

        #endregion

        #region FIELDS

        private float[] map;
        private uint[] age;
        private uint width;
        private uint height;

        private float mass;
        private float top;
        private float left;

        private PointF center;

        private float velocity;
        private PointF directionVector;
        private PointF accelerationVector;

        #endregion

        #region PROPERTIES

        public float Momentum
        {
            get
            {
                return mass * Velocity;
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

        public float Left
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

        public float Top
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

        public float Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public PointF DirectionVector
        {
            get
            {
                return directionVector;
            }

            set
            {
                directionVector = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return mass <= 0;
            }
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Adds a collision in a continent. It increments the collision counter.
        /// </summary>
        /// <param name="collisionPoint"> Coordinate of the collision</param>
        /// <returns>Surface area of the collided continent</returns>
        public uint addCollision(Point collisionPoint)
        {
            uint result = 0;


            throw new NotImplementedException();
            return result;
        }
        
        /// <summary>
        /// Add crust to a plate
        /// </summary>
        /// <param name="crustLocation">Location of the new crust</param>
        /// <param name="crustAmount">Amount of new crust</param>
        /// <param name="crustTime">Time of creation of new crust</param>
        public void addCrustByCollision(Point crustLocation, float crustAmount, uint crustTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Simulates subduction of oceanic plate under this plate.
        ///
        /// Subduction is simulated by calculating the distance on surface
        /// that subducting sediment will travel under the plate until the
        /// subducting slab has reached certain depth where the heat triggers
        /// the melting and uprising of molten magma. 
        /// </summary>
        /// <param name="crustLocation">Origin of subduction on global world map</param>
        /// <param name="crustAmount">Amount of sediment that subducts.</param>
        /// <param name="crustTime">Time of creation of new crust.</param>
        /// <param name="crustDirection">Direction of the subducting plate.</param>
        public void addCrustBySubduction(Point crustLocation, float crustAmount, uint crustTime, PointF crustDirection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add continental crust from this plate as part of other plate.
        ///
        /// Aggregation of two continents is the event where the collided
        /// pieces of crust fuse together at the point of collision. It is
        /// crucial to merge not only the collided pieces of crust but also
        /// the entire continent that's part of the colliding tad of crust
        /// However, because one plate can contain many islands and pieces of
        /// continents, the merging must be done WITHOUT merging the entire
        /// plate and all those continental pieces that have NOTHING to do with
        /// the collision in question.
        /// </summary>
        /// <param name="recPlate">Pointer to the receiving plate.</param>
        /// <param name="collitionLocation">coordinate of collision point on world map.</param>
        /// <returns>Amount of crust aggregated to destination plate.</returns>
        public float aggregateCrust(ref Plate recPlate, Point collitionLocation)
        {
            float result = 0;

            throw new NotImplementedException();
            return result;
        }

        /// <summary>
        /// Decrease the speed of plate amount relative to its total mass.
        ///
        /// Method decreses the speed of plate due to friction that occurs when
        /// two plates collide. The amount of reduction depends of the amount
        /// of mass that causes friction (i.e. that has collided) compared to
        /// the total mass of the plate. Thus big chunk of crust colliding to
        /// a small plate will halt it but have little effect on a huge plate.
        /// </summary>
        /// <param name="deformingMass">Amount of mass deformed in collision.</param>
        public void applyFriction(float deformingMass)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method collides two plates according to Newton's laws of motion.
        ///
        /// The velocity and direction of both plates are updated using
        /// impulse forces following the collision according to Newton's laws
        /// of motion. Deformations are not applied but energy consumed by the
        /// deformation process is taken away from plate's momentum.
        /// </summary>
        /// <param name="plateToCollide">Plate to test against.</param>
        /// <param name="collisionLocation">Coordinate of collision point on world map.</param>
        /// <param name="collisionMass">Amount of colliding mass from source plate.</param>
        void collide(ref Plate plateToCollide, Point collisionLocation, float collisionMass)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Apply plate wide erosion algorithm.
        ///
        /// Plates total mass and the center of mass are updated.
        /// </summary>
        /// <param name="lowerBound">Sets limit below which there's no erosion.</param>
        public void erode(float lowerBound)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieve collision statistics of continent at given location.
        /// </summary>
        /// <param name="collisionLocation">Coordinate of collision point on world map.</param>
        /// <param name="countCollisions">count Destination for the count of collisions.</param>
        /// <param name="percentageAreaCollided">count Destination for the % of area that collided.</param>
        public void getCollisionInfo(Point collisionLocation,ref uint countCollisions, ref uint percentageAreaCollided)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Retrieve the surface area of continent lying at desired location.
        /// </summary>
        /// <param name="collisionLocation">Coordinate of collision point on world map.</param>
        /// <returns>Area of continent at desired location or 0 if none.</returns>
        public uint getContinentArea(Point collisionLocation)
        {
            uint result = 0;


            throw new NotImplementedException();
            return result;
        }

        /// <summary>
        /// Get the amount of plate's crustal material at some location.
        /// </summary>
        /// <param name="location">Offset on the global world map.</param>
        /// <returns>Amount of crust at requested location.</returns>
        public float getCrust(Point location)
        {
            float result = 0;


            throw new NotImplementedException();
            return result;
        }

        /// <summary>
        /// Get the timestamp of plate's crustal material at some location.
        /// </summary>
        /// <param name="location">Offset on the global world map.</param>
        /// <returns>Timestamp of creation of crust at the location. Zero is returned if location contains no crust.</returns>
        public uint getCrustTimestamp(Point location)
        {
            uint result = 0;


            throw new NotImplementedException();
            return result;
        }

        /// Get pointers to plate's data.
        ///
        /// @param	c	Adress of crust height map is stored here.
        /// @param	t	Adress of crust timestamp map is stored here.
        void getMap(const float** c, const size_t** t) const throw();

        void move() throw(); ///< Moves plate along it's trajectory.

	/// Clear any earlier continental crust partitions.
	///
	/// Plate has an internal bookkeeping of distinct areas of continental
	/// crust for more realistic collision responce. However as the number
	/// of collisions that plate experiences grows, so does the bookkeeping
	/// of a continent become more and more inaccurate. Finally it results
	/// in striking artefacts that cannot overlooked.
	///
	/// To alleviate this problem without the need of per iteration
	/// recalculations plate supplies caller a method to reset its
	/// bookkeeping and start clean.
	void resetSegments() throw();

	/// Remember the currently processed continent's segment number.
	///
	/// @param	coll_x	Origin of collision on global world map (X).
	/// @param	coll_y	Origin of collision on global world map (Y).
	void selectCollisionSegment(size_t coll_x, size_t coll_y) throw();

	/// Set the amount of plate's crustal material at some location.
	///
	/// If amount of crust to be set is negative, it'll be set to zero.
	///
	/// @param	x	Offset on the global world map along X axis.
	/// @param	y	Offset on the global world map along Y axis.
	/// @param	z	Amount of crust at given location.
	/// @param	t	Time of creation of new crust.
	void setCrust(size_t x, size_t y, float z, size_t t) throw();
        #endregion

        #region PRIVATE METHODS

        #endregion


    }
}
