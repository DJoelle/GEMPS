using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using System.IO;

namespace GEMPS.DAL
{
    public class LocationDAO : IDAL<Location>
    {
        private string dataFile = @"Data/locations" + RsDAL.smallDataFileExtension;
        private List<Location> list;

        public int Count
        {
            get
            {
                int count = 0;

                foreach (var v in this.list)
                {
                    if (v.IsDeleted == false)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public string NextId
        {
            get
            {
                return (Convert.ToInt32(list?.LastOrDefault()?.Id ?? "-1") + 1).ToString();
            }
        }

        public LocationDAO()
        {
            if (!File.Exists(dataFile))
            {
                FileInfo f = new FileInfo(dataFile);

                if (!Directory.Exists(f.DirectoryName))
                {
                    Directory.CreateDirectory(f.DirectoryName);
                }

                File.Create(dataFile).Dispose();
                list = new List<Location>();
                new Formatter<List<Location>>(list, dataFile).Serialize(Format.xml);
            }
            else
            {
                list = new Formatter<List<Location>>(dataFile).Deserialize(Format.xml);
            }
        }

        public Location this[int index]
        {
            get
            {
                return this.list[index];
            }

            set
            {
                if (index >= 0 && index < this.list.Count)
                {
                    if (this.list[index].IsDeleted == false)
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException();
                        }

                        List<Location> l = this.Find(x => x.Name == value.Name);
                        if (l.Count > 0)
                        {
                            if (l.First().IsDeleted == false)
                            {
                                throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.location));
                            }
                        }

                        value.Id = list[index].Id;
                        list[index] = value;
                        new Formatter<List<Location>>(list, dataFile).Serialize(Format.xml);
                    }
                }
            }
        }

        public void Add(Location item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            List<Location> l = this.Find(x => x.Name == item.Name);
            if (l.Count > 0)
            {
                if (l.First().IsDeleted == false)
                {
                    throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.location));
                }
            }

            item.Id = NextId;
            list.Add(item);
            new Formatter<List<Location>>(list, dataFile).Serialize(Format.xml);
        }

        public void Clear()
        {
            foreach (var v in this.list)
            {
                this.RemoveAt(this.list.IndexOf(v));
            }
        }

        public bool Contains(Location item)
        {
            List<Location> l = this.Find(x => x.Name == item.Name);
            if (l.Count > 0)
            {
                if (l.First().IsDeleted == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Location> Find(Func<Location, bool> condition)
        {
            List<Location> l = this.list.Where(condition).ToList();
            List<Location> results = new List<Location>();

            foreach (var v in l)
            {
                if (v.IsDeleted == false)
                {
                    results.Add(v);
                }
            }

            return results;
        }

        public int IndexOf(Location item)
        {
            List<Location> l = this.Find(x => x.Name == item.Name);
            if (l.Count > 0)
            {
                if (l.First().IsDeleted == false)
                {
                    return this.list.IndexOf(l.First());
                }
            }
            throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.location));
        }

        public bool Remove(Func<Location, bool> condition)
        {
            int i = 0;
            foreach (var v in this.list)
            {
                if (condition(v))
                {
                    this.RemoveAt(this.list.IndexOf(v));
                    i++;
                }
            }

            return (i > 0);

            //if (i > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public bool RemoveAt(int index)
        {
            if (this.Contains(this.list[index]))
            {
                this.list[index].IsDeleted = true;
                new Formatter<List<Location>>(list, dataFile).Serialize(Format.xml);
                return true;
            }
            else
            {
                throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.location));
            }
        }
    }
}
