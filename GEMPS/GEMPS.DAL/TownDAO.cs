using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GEMPS.BO;

namespace GEMPS.DAL
{
    public class TownDAO : IDAL<Town>
    {
        private string dataFile = @"Data/towns" + RsDAL.smallDataFileExtension;
        private List<Town> list;

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

        public TownDAO()
        {
            if (!File.Exists(dataFile))
            {
                FileInfo f = new FileInfo(dataFile);

                if (!Directory.Exists(f.DirectoryName))
                {
                    Directory.CreateDirectory(f.DirectoryName);
                }

                File.Create(dataFile).Dispose();
                list = new List<Town>();
                new Formatter<List<Town>>(list, dataFile).Serialize(Format.xml);
            }
            else
            {
                list = new Formatter<List<Town>>(dataFile).Deserialize(Format.xml);
            }
        }

        public Town this[int index]
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

                        List<Town> l = this.Find(x => x.Name == value.Name);
                        if (l.Count > 0)
                        {
                            if (l.First().IsDeleted == false)
                            {
                                throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.town));
                            }
                        }

                        value.Id = list[index].Id;
                        list[index] = value;
                        new Formatter<List<Town>>(list, dataFile).Serialize(Format.xml);
                    }
                }
            }
        }

        public void Add(Town item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            List<Town> l = this.Find(x => x.Name == item.Name);
            if (l.Count > 0)
            {
                if (l.First().IsDeleted == false)
                {
                    throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.town));
                }
            }

            item.Id = NextId;
            list.Add(item);
            new Formatter<List<Town>>(list, dataFile).Serialize(Format.xml);
        }

        public void Clear()
        {
            foreach (var v in this.list)
            {
                this.RemoveAt(this.list.IndexOf(v));
            }
        }

        public bool Contains(Town item)
        {
            List<Town> l = this.Find(x => x.Name == item.Name);
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

        public List<Town> Find(Func<Town, bool> condition)
        {
            List<Town> l = this.list.Where(condition).ToList();
            List<Town> results = new List<Town>();

            foreach (var v in l)
            {
                if (v.IsDeleted == false)
                {
                    results.Add(v);
                }
            }

            return results;
        }

        public int IndexOf(Town item)
        {
            List<Town> l = this.Find(x => x.Name == item.Name);
            if (l.Count > 0)
            {
                if (l.First().IsDeleted == false)
                {
                    return this.list.IndexOf(l.First());
                }
            }
            throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.town));
        }

        public bool Remove(Func<Town, bool> condition)
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
                new Formatter<List<Town>>(list, dataFile).Serialize(Format.xml);
                return true;
            }
            else
            {
                throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.town));
            }
        }
    }
}
