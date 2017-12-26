using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GEMPS.BO;

namespace GEMPS.DAL
{
    public class RegionDAO : IDAL<Region>
    {
        private string bigDataFile = @"Data/regions" + RsDAL.bigDataFileExtension;
        private string smallDataFile = @"Data/regions" + RsDAL.smallDataFileExtension;
        private List<Region> smallList;
        private List<Region> bigList;

        public int Count
        {
            get
            {
                return this.smallList.Count();
            }
        }

        public string NextId
        {
            get
            {
                return (Convert.ToInt32(bigList?.LastOrDefault()?.Id ?? "-1") + 1).ToString();
            }
        }

        public RegionDAO()
        {
            if (!File.Exists(smallDataFile) && !File.Exists(bigDataFile))
            {
                FileInfo sf = new FileInfo(smallDataFile);
                FileInfo bf = new FileInfo(bigDataFile);

                if (!Directory.Exists(sf.DirectoryName))
                {
                    Directory.CreateDirectory(sf.DirectoryName);
                }
                if (!Directory.Exists(bf.DirectoryName))
                {
                    Directory.CreateDirectory(bf.DirectoryName);
                }

                File.Create(smallDataFile).Dispose();
                File.Create(bigDataFile).Dispose();

                smallList = new List<Region>();
                bigList = new List<Region>();

                new Formatter<List<Region>>(smallList, smallDataFile).Serialize(Format.xml);
                new Formatter<List<Region>>(bigList, bigDataFile).Serialize(Format.binary);
            }
            else if(File.Exists(smallDataFile) && File.Exists(bigDataFile))
            {
                smallList = new Formatter<List<Region>>(smallDataFile).Deserialize(Format.xml);
                bigList = new Formatter<List<Region>>(bigDataFile).Deserialize(Format.binary);
            }
            else
            {

            }
        }

        public Region this[int index]
        {
            get
            {
                return this.smallList[index];
            }

            set
            {
                if (index >= 0 && index < this.smallList.Count)
                {
                    if (this.smallList[index].IsDeleted == false)
                    {
                        if (value == null)
                        {
                            throw new ArgumentNullException();
                        }

                        if ((this.Find(x => x.Name == value.Name)).Count > 0)
                        {
                            throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.region));
                        }

                        value.Id = smallList[index].Id;
                        smallList[index] = value;
                        new Formatter<List<Region>>(smallList, dataFile).Serialize(Format.xml);
                    }
                    else
                    {
                        throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.region));
                    }
                }
                else
                {
                    throw new Exception(RsDAL.indexNotAvailable);
                }
            }
        }

        public void Add(Region item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if ((this.Find(x => x.Name == item.Name)).Count > 0)
            {
                throw new Exception(string.Format(RsDAL.alreadyExists, RsDAL.region));
            }

            item.Id = NextId;
            smallList.Add(item);
            new Formatter<List<Region>>(smallList, dataFile).Serialize(Format.xml);
        }

        public void Clear()
        {
            foreach(var v in this.smallList)
            {
                this.RemoveAt(this.smallList.IndexOf(v));
            }
        }

        public bool Contains(Region item)
        {
            return this.smallList.Contains(item);
        }

        public List<Region> Find(Func<Region, bool> condition)
        {
            List<Region> l = this.smallList.Where(condition).ToList();
            List<Region> results = new List<Region>();
            foreach (var v in l)
            {
                if(v.IsDeleted==false)
                {
                    results.Add(v);
                }
            }

            return results;
        }

        public int IndexOf(Region item)
        {
            return this.smallList.IndexOf(item);
        }

        public bool Remove(Func<Region, bool> condition)
        {
            int i = 0;
            foreach(var v in this.smallList)
            {
                if(condition(v))
                {
                    this.RemoveAt(this.smallList.IndexOf(v));
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
            if (this.smallList.Contains(this.smallList[index]))
            {
                this.smallList[index].IsDeleted = true;
                new Formatter<List<Region>>(smallList, dataFile).Serialize(Format.xml);
                return true;
            }
            else
            {
                throw new Exception(string.Format(RsDAL.doesntExist, RsDAL.region));
            }
        }
    }
}