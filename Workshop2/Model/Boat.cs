using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{

    /// <summary>
    /// Class that represents a boat.
    /// </summary>

    class Boat
    {
        private BoatType type;
        private int length;

        private int Length
        {
            set
            {
                if (value > 0)
                    length = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
            get{
                return length;
            }

        }

        /// <summary>
        /// Constructor for a boat.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>

        public Boat(BoatType type, int length)
        {
            this.type = type;
            Length = length;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.type, Length);
        }
    }
}
