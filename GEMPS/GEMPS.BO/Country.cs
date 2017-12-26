using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of Country.
    /// </summary>
    [Serializable]
    public class Country : GeographicErea
    {
        private string regionId;
        
        /// <summary>
        /// The system identifier of the Region in which this Country is located.
        /// </summary>
        public string RegionId
        {
            get
            {
                return this.regionId;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.regionId = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Represents an instance of Country with none-initialized properties.
        /// </summary>
        public Country() : base()
        {

        }

        /// <summary>
        /// Represents an instance of Country.
        /// </summary>
        /// <param name="regionId">The system identifier of the Region in which this Country is located.</param>
        /// <param name="name">This Country name.</param>
        public Country(string regionId, string name) : base("0", name)
        {
            RegionId = regionId;
        }

        /// <summary>
        /// Represents an instance of Country having the copy of properties values from another existing Country instance.
        /// </summary>
        /// <param name="country">The Country instance from which the properpies values will be copied.</param>
        public Country(Country country) : base(country.Id, country.Name)
        {
            IsDeleted = country.IsDeleted;
            RegionId = country.RegionId;
        }

        /// <summary>
        /// A redefinition of the string.GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this Country instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified Country object are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other Country object to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the string.ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current Country object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
