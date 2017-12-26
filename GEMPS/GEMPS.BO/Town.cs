using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of Town.
    /// </summary>
    [Serializable]
    public class Town : GeographicErea
    {
        private string countryId;
        
        /// <summary>
        /// The system identifier of the Country in which this Town is located.
        /// </summary>
        public string CountryId
        {
            get
            {
                return this.countryId;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.countryId = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Represents an instance of Town with none-initialized properties.
        /// </summary>
        public Town() : base()
        {

        }

        /// <summary>
        /// Represents an instance of Town.
        /// </summary>
        ///<param name="countryId">The system identifier of the Country in which this Town is located.</param>
        /// <param name="name">This Town name.</param>
        public Town(string countryId, string name) : base("0", name)
        {
            CountryId = countryId;
        }

        /// <summary>
        /// Represents an instance of Town having the copy of properties values from another existing Town instance.
        /// </summary>
        ///<param name="town">The Town instance from which the properpies values will be copied.</param>
        public Town(Town town) : base(town.Id, town.Name)
        {
            IsDeleted = town.IsDeleted;
            CountryId = town.CountryId;
        }

        /// <summary>
        /// A redefinition of the string.GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this Town instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified Town object are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other Town object to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the string.ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current Town object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
