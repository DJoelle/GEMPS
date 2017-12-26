using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.DAL;

namespace GEMPS.BLL
{
    public enum ContactWhere
    {
        Id,
        PhoneNumber,
        POBox,
        Email,
        Fax,
        Facebook
    };

    public enum ContactProperty
    {
        PhoneNumber,
        POBox,
        Email,
        Fax,
        Facebook
    };

    public class Contacts : IBLL<Contact, ContactWhere, ContactProperty>
    {
        private ContactDAO contacts;

        public Contacts()
        {
            contacts = new ContactDAO();
        }

        public void Add(Contact item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public List<Contact> Find(ContactWhere prefixe, object[] equalsTo)
        {
            throw new NotImplementedException();
        }

        public List<Contact> Find(ContactWhere prefixe, object equalsTo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ContactWhere prefixe, object[] equalsTo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ContactWhere prefixe, object equalsTo)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact oldItem, Contact newItem)
        {
            throw new NotImplementedException();
        }

        public void Update(ContactWhere prefixe, object equalsTo, ContactProperty property, object propertyNewValue)
        {
            throw new NotImplementedException();
        }
    }
}
