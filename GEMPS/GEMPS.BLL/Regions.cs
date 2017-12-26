using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.DAL;

namespace GEMPS.BLL
{
    public enum RegionWhere
    {
        Id,
        Name
    };

    public enum RegionProperty
    {
        Name
    };

    public class Regions : IBLL<Region, RegionWhere, RegionProperty>
    {
        private RegionDAO regions;

        public Regions()
        {
            regions = new RegionDAO();
        }

        public void Add(Region item)
        {
            this.regions.Add(item);
        }

        public void Clear()
        {
            this.regions.Clear();
        }

        public List<Region> Find(RegionWhere prefixe, object[] equalsTo)
        {
            List<Region> results = new List<Region>();
            List<Region> l = null;

            switch (prefixe)
            {
                case RegionWhere.Id:
                    foreach(var v in equalsTo)
                    {
                        l = this.regions.Find(x => x.Id == (string)v);
                        results = results.Concat(l).ToList();
                    }
                    break;
                case RegionWhere.Name:
                    foreach (var v in equalsTo)
                    {
                        l = this.regions.Find(x => x.Name == (string)v);
                        results = results.Concat(l).ToList();
                    }
                    break;
                default:
                    break;
            }

            return results;
        }

        public List<Region> Find(RegionWhere prefixe, object equalsTo)
        {
            List<Region> results = null;

            switch (prefixe)
            {
                case RegionWhere.Id:
                    results = this.regions.Find(x => x.Id == (string)equalsTo);
                    break;
                case RegionWhere.Name:
                    results = this.regions.Find(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            return results;
        }

        public bool Remove(RegionWhere prefixe, object[] equalsTo)
        {
            int i = 0;
            switch (prefixe)
            {
                case RegionWhere.Id:
                    foreach(var v in equalsTo)
                    {
                        if (this.regions.Remove(x => x.Id == (string)v))
                        {
                            i++;
                        }
                    }
                    break;
                case RegionWhere.Name:
                    foreach (var v in equalsTo)
                    {
                        if (this.regions.Remove(x => x.Name == (string)v))
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

        public bool Remove(RegionWhere prefixe, object equalsTo)
        {
            bool result = false;

            switch (prefixe)
            {
                case RegionWhere.Id:
                    result = this.regions.Remove(x => x.Id == (string)equalsTo);
                    break;
                case RegionWhere.Name:
                    result = this.regions.Remove(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            return result;
        }

        public void Update(Region oldItem, Region newItem)
        {
            int i = this.regions.IndexOf(oldItem);
            this.regions[i] = newItem;
        }

        public void Update(RegionWhere prefixe, object equalsTo, RegionProperty property, object propertyNewValue)
        {
            List<Region> l = null;

            switch (prefixe)
            {
                case RegionWhere.Id:
                    l = this.regions.Find(x => x.Id == (string)equalsTo);
                    break;
                case RegionWhere.Name:
                    l = this.regions.Find(x => x.Name == (string)equalsTo);
                    break;
                default:
                    break;
            }

            switch (property)
            {
                case RegionProperty.Name:
                    foreach (var oldItem in l)
                    {
                        Region newItem = new Region(oldItem);
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
