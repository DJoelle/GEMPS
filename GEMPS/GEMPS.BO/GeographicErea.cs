using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// 
    /// </summary>
    public class GeographicErea : SystemStoredObject
    {
        private string name;

        /// <summary>
        /// This Geographic Erea name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GeographicErea() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public GeographicErea(string id, string name) : base(id)
        {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="geographicErea"></param>
        public GeographicErea(GeographicErea geographicErea) : base(geographicErea.Id)
        {
            Name = geographicErea.Name;
            IsDeleted = geographicErea.IsDeleted;
        }

        /// <summary>
        /// A redefinition of the GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this GeographicErea instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified GeographicErea instance are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other GeographicErea instance to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current GeographicErea instance.</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
