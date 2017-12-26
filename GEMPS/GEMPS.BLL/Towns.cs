using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.DAL;

namespace GEMPS.BLL
{
    public enum TownWhere
    {
        Id,
        Name,
        CountryId
    };

    public enum TownProperty
    {
        Name,
        CountryId
    };

    public class Towns : IBLL<Town, TownWhere, TownProperty>
    {
        private TownDAO towns;

        public Towns()
        {
            towns = new TownDAO();
        }

        public void Add(Town item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public List<Town> Find(TownWhere prefixe, object[] equalsTo)
        {
            throw new NotImplementedException();
        }

        public List<Town> Find(TownWhere prefixe, object equalsTo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TownWhere prefixe, object[] equalsTo)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TownWhere prefixe, object equalsTo)
        {
            throw new NotImplementedException();
        }

        public void Update(Town oldItem, Town newItem)
        {
            throw new NotImplementedException();
        }

        public void Update(TownWhere prefixe, object equalsTo, TownProperty property, object propertyNewValue)
        {
            throw new NotImplementedException();
        }
    }
}
