using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of Region.
    /// </summary>
    [Serializable]
    public class Region : GeographicErea
    {
        /// <summary>
        /// Represents an instance of Region with none-initialized properties.
        /// </summary>
        public Region() : base()
        {

        }

        /// <summary>
        /// Represents an instance of Region.
        /// </summary>
        /// <!--<param name="id">The system identifier of this Region.</param>-->
        /// <param name="name">This Region name.</param>
        public Region(string name) : base("0", name)
        {

        }

        /// <summary>
        /// Represents an instance of Region having the copy of properties values from another existing Region instance.
        /// </summary>
        /// <param name="region">The Region instance from which the properpies values will be copied.</param>
        public Region(Region region) : base(region.Id, region.Name)
        {
            IsDeleted = region.IsDeleted;
        }

        /// <summary>
        /// A redefinition of the GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this Region instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified Region instance are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other Region object to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current Region instance.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
