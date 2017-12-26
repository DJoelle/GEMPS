using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.DAL;

namespace GEMPS.BLL
{
    public enum CountryWhere
    {
        Id,
        Name,
        RegionId
    };

    public enum CountryProperty
    {
        Name,
        RegionId
    };

    public class Countries : IBLL<Country, CountryWhere, CountryProperty>
    {
        private CountryDAO countries;
        private object regions;

        public Countries()
        {
            countries = new CountryDAO();
        }

        public void Add(Country item)
        {
            this.countries.Add(item);
        }

        public void Clear()
        {
            this.countries.Clear();
        }

        public List<Country> Find(CountryWhere prefixe, object[] equalsTo)
        {
            List<Country> result = new List<Country>();
            List<Country> l = null;

            switch (prefixe)
            {
                case CountryWhere.Id:
                    foreach(var v in equalsTo)
                    {
                        l = this.countries.Find(x => x.Id == (string)v);
                        result = result.Concat(l).ToList();
                    }
                    break;
                case CountryWhere.Name:
                    foreach(var v in equalsTo)
                    {
                        l = this.countries.Find(x => x.Name == (string)v);
                        result = result.Concat(l).ToList();
                    }
                    break;
                case CountryWhere.RegionId:
                    foreach(var v in equalsTo)
                    {
                        l = this.countries.Find(x => x.RegionId == (string)v);
                        result = result.Concat(l).ToList();
                    }
                    break;
            }
            return result;
        }

        public List<Country> Find(CountryWhere prefixe, object equalsTo)
        {
            List<Country> result = null;

            switch (prefixe)
            {
                case CountryWhere.Id:
                    result = this.countries.Find(x => x.Id == (string)equalsTo);
                    break;
                case CountryWhere.Name:
                    result = this.countries.Find(x => x.Name == (string)equalsTo);
                    break;
                case CountryWhere.RegionId:
                    result = this.countries.Find(x => x.RegionId == (string)equalsTo);
                    break;
            }
            return result;
        }

        public bool Remove(CountryWhere prefixe, object[] equalsTo)
        {
            int i = 0;
            switch (prefixe)
            {
                case CountryWhere.Id:
                    foreach (var v in equalsTo)
                    {
                        if (this.countries.Remove(x => x.Id == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                case CountryWhere.Name:
                    foreach (var v in equalsTo)
                    {
                        if (this.countries.Remove(x => x.Name == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                case CountryWhere.RegionId:
                    foreach (var v in equalsTo)
                    {
                        if (this.countries.Remove(x => x.Name == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                default:
                    break;
            }
            return (i > 0);
        }

        public bool Remove(CountryWhere prefixe, object equalsTo)
        {
            bool result = false;

            switch (prefixe)
            {
                case CountryWhere.Id:
                    result = this.countries.Remove(x => x.Id == (string)equalsTo);
                    break;
                case CountryWhere.Name:
                    result = this.countries.Remove(x => x.Name == (string)equalsTo);
                    break;
                case CountryWhere.RegionId:
                    result = this.countries.Remove(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            return result;
        }

        public void Update(Country oldItem, Country newItem)
        {
            int i = this.countries.IndexOf(oldItem);
            this.countries[i] = newItem;
        }

        public void Update(CountryWhere prefixe, object equalsTo, CountryProperty property, object propertyNewValue)
        {
            List<Country> l = null;

            switch (prefixe)
            {
                case CountryWhere.Id:
                    l = this.countries.Find(x => x.Id == (string)equalsTo);
                    break;
                case CountryWhere.Name:
                    l = this.countries.Find(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            switch (property)
            {
                case CountryProperty.Name:
                    foreach (var oldItem in l)
                    {
                        Country newItem = new Country(oldItem);
                        newItem.Name = (string)propertyNewValue;
                        this.Update(oldItem, newItem);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
