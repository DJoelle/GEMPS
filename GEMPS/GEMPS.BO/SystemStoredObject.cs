using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of system object that can be stored in the database.
    /// </summary>
    public class SystemStoredObject
    {
        private string id;

        /// <summary>
        /// The system identifier of this SystemStoredObject.
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentNullException("Id");
                }
            }
        }
        /// <summary>
        /// Specifies if the SystemStoredObject should behave as a deleted object or not.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SystemStoredObject()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isDeleted"></param>
        public SystemStoredObject(string id)
        {
            Id = id;
            IsDeleted = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemStoredObject"></param>
        public SystemStoredObject(SystemStoredObject systemStoredObject)
        {
            Id = systemStoredObject.Id;
            IsDeleted = systemStoredObject.IsDeleted;
        }

        /// <summary>
        /// A redefinition of the GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this SystemStoredObject instance Id value.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified SystemStoredObject instance are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other SystemStoredObject instance to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as Region)?.Id, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// A redefinition of the ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current SystemStoredObject instance.</returns>
        public override string ToString()
        {
            return this.Id;
        }
    }
}
