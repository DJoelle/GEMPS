using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of Location.
    /// </summary>
    [Serializable]
    public class Location : GeographicErea
    {
        private string townId;

        /// <summary>
        /// The system identifier of the Town in which this Location is.
        /// </summary>
        public string TownId
        {
            get
            {
                return this.townId;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.townId = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Represents an instance of Location with none-initialized properties.
        /// </summary>
        public Location() : base()
        {

        }

        /// <summary>
        /// Represents an instance of Location.
        /// </summary>
        /// <param name="townId">The system identifier of the Town in which this Location is.</param>
        /// <param name="name">This Location description.</param>
        public Location(string townId, string name) : base("0", name)
        {
            TownId = townId;
        }

        /// <summary>
        /// Represents an instance of Location having the copy of properties values from another existing Location instance.
        /// </summary>
        ///<param name="location">The Location instance from which the properpies values will be copied.</param>
        public Location(Location location) : base(location.Id, location.Name)
        {
            IsDeleted = location.IsDeleted;
            TownId = location.TownId;
        }

        /// <summary>
        /// A redefinition of the string.GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this Location instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified Location object are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other Location object to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the string.ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current Location object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
