using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.DAL;

namespace GEMPS.BLL
{
    public enum LocationWhere
    {
        Id,
        Name,
        TownId
    };

    public enum LocationProperty
    {
        Name,
        TownId
    };

    public class Locations : IBLL<Location, LocationWhere, LocationProperty>
    {
        private LocationDAO locations;

        public Locations()
        {
            locations = new LocationDAO();
        }

        public void Add(Location item)
        {
            this.locations.Add(item);
        }

        public void Clear()
        {
            this.locations.Clear();
        }

        public List<Location> Find(LocationWhere prefixe, object[] equalsTo)
        {
            List<Location> result = new List<Location>();
            List<Location> l = null;
            
            switch (prefixe)
            {
                case LocationWhere.Id:
                    foreach (var v in equalsTo)
                    {
                        l = this.locations.Find(x => x.Id.Equals((string)v));
                        result = result.Concat(l).ToList();
                    }
                    break;
                case LocationWhere.Name:
                    foreach (var v in equalsTo)
                    {
                        l = this.locations.Find(x => x.Id == (string)v);
                        result = result.Concat(l).ToList();
                    }
                    break;
                case LocationWhere.TownId:
                    foreach (var v in equalsTo)
                    {
                        l = this.locations.Find(x => x.Id == (string)v);
                        result = result.Concat(l).ToList();
                    }
                    break;
            }
            return result; 
        }

        public List<Location> Find(LocationWhere prefixe, object equalsTo)
        {
            List<Location> result = null;

            switch (prefixe)
            {
                case LocationWhere.Id:
                    result= this.locations.Find(x => x.Id == (string)equalsTo);
                    break;
                case LocationWhere.Name:
                    result = this.locations.Find(x => x.Id == (string)equalsTo);
                    break;
                case LocationWhere.TownId:
                    result = this.locations.Find(x => x.Id == (string)equalsTo);
                    break;
            }
            return result;
        }

        public bool Remove(LocationWhere prefixe, object[] equalsTo)
        {
            int i = 0;
            switch (prefixe)
            {
                case LocationWhere.Id:
                    foreach (var v in equalsTo)
                    {
                        if (this.locations.Remove(x => x.Id == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                case LocationWhere.Name:
                    foreach (var v in equalsTo)
                    {
                        if (this.locations.Remove(x => x.Name == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                case LocationWhere.TownId:
                    foreach (var v in equalsTo)
                    {
                        if (this.locations.Remove(x => x.Name == (string)v))
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

        public bool Remove(LocationWhere prefixe, object equalsTo)
        {
            bool result = false;

            switch (prefixe)
            {
                case LocationWhere.Id:
                    result = this.locations.Remove(x => x.Id == (string)equalsTo);
                    break;
                case LocationWhere.Name:
                    result = this.locations.Remove(x => x.Name == (string)equalsTo);
                    break;
                case LocationWhere.TownId:
                    result = this.locations.Remove(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }
            return result;
        }

        public void Update(Location oldItem, Location newItem)
        {
            int i = this.locations.IndexOf(oldItem);
            this.locations[i] = newItem;
        }

        public void Update(LocationWhere prefixe, object equalsTo, LocationProperty property, object propertyNewValue)
        {
            List<Location> l = null;

            switch (prefixe)
            {
                case LocationWhere.Id:
                    l = this.locations.Find(x => x.Id == (string)equalsTo);
                    break;
                case LocationWhere.Name:
                    l = this.locations.Find(x => x.Name == (string)equalsTo);
                    break;
                case LocationWhere.TownId:
                    l = this.locations.Find(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            switch (property)
            {
                case LocationProperty.Name:
                    foreach (var oldItem in l)
                    {
                        Location newItem = new Location(oldItem);
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
