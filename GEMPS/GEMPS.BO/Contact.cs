using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.BO
{
    /// <summary>
    /// Represents an instance of Contact.
    /// </summary>
    [Serializable]
    public class Contact : SystemStoredObject
    {
        /// <summary>
        /// The string containing this Contact phone number(s). It can be about more than one phone number, they just have to be formated as one string.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The string containing this Contact PO Box.
        /// </summary>
        public string POBox { get; set; }
        /// <summary>
        /// The string containing this Contact email(s). It can be about more than one email, they just have to be formated as one string.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The string containing this Contact fax number(s). It can be about more than one fax number, they just have to be formated as one string.
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// This Contact facebook account.
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// Represents an instance of Contact with none-initialized properties.
        /// </summary>
        public Contact() : base()
        {

        }

        /// <summary>
        /// Represents an instance of Contact.
        /// </summary>
        /// <!--<param name="id">The system identifier of this Contact.</param>-->
        /// <param name="phoneNumber">The string containing this Contact phone number(s). It can be about more than one phone number, they just have to be formated as one string.</param>
        /// <param name="pOBox">The string containing this Contact PO Box.</param>
        /// <param name="email">The string containing this Contact email(s). It can be about more than one email, they just have to be formated as one string.</param>
        /// <param name="fax">The string containing this Contact fax number(s). It can be about more than one fax number, they just have to be formated as one string.</param>
        /// <param name="facebook">This Contact facebook account.</param>
        public Contact(string phoneNumber, string pOBox, string email, string fax, string facebook) : base("0")
        {
            PhoneNumber = phoneNumber;
            POBox = pOBox;
            Email = email;
            Fax = fax;
            Facebook = facebook;
        }

        /// <summary>
        /// Represents an instance of Contact having the copy of properties values from another existing Contact instance.
        /// </summary>
        /// <param name="contact">The Contact instance from which the properpies values will be copied.</param>
        public Contact(Contact contact) : base(contact.Id)
        {
            PhoneNumber = contact.PhoneNumber;
            POBox = contact.POBox;
            Email = contact.Email;
            Fax = contact.Fax;
            Facebook = contact.Facebook;
            IsDeleted = contact.IsDeleted;
        }

        /// <summary>
        /// A redefinition of the string.GetHashCode() method.
        /// </summary>
        /// <returns>Returns the hash code for this Contact instance Id value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and another specified Contact object are the same, referring to their Ids values.
        /// </summary>
        /// <param name="obj">The other Contact object to compare with this instance.</param>
        /// <returns>Returns a Boolean (true or false) value.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// A redefinition of the string.ToString() method.
        /// </summary>
        /// <returns>Returns a string that represents the current Contact object.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
