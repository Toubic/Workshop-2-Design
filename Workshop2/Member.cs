using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    class Member
    {
        //Counter for incremented id:
        private static int theCounter = 1;
        public int id;
        public string name;
        public string ssn;
        public List<Boat> boats;

        /// <summary>
        /// Constructor for a member.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ssn"></param>

        public Member(string name, string ssn)
        {
            id = theCounter++;
            this.name = name;
            this.ssn = ssn;
            boats = new List<Boat>();
        }
        public void registerBoat(BoatType type, int length)
        {
            boats.Add(new Boat(type, length));

        }
        public void updateBoat(int i, BoatType type, int length)
        {
            boats[i] = new Boat(type, length);
        }
        public void deleteBoat(int i)
        {
            boats.RemoveAt(i);
        }

        /// <summary>
        /// Format output after compact or verbose output.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format)
        {

            string returnString;
            if (format == "C")
            {
                returnString = string.Format("{0} {1} {2}", name, id, boats.Count());

                return returnString;
            }
            else if (format == "V")
            {
                returnString = string.Format("{0} {1} {2}", name, ssn, id);

                for (int i = 0; i < boats.Count(); i++)
                    returnString += " " + boats[i].ToString();
                return returnString;
            }
            return "";
        }
       
       
    }
}
