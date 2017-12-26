using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEMPS.BO;
using GEMPS.Setting;
using GEMPS.BLL;

namespace GEMPS.GUIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Region r = new Region("Africa");
            //new Regions().Add(r);

            //Region r1 = new Region("Europe");
            //new Regions().Add(r1);

            //new Regions().Remove(RegionWhere.Id, "1");

            //Console.WriteLine(new Regions().Find(Where.Name, "Africa").First().Id + " " + new Regions().Find(Where.Name, "Africa").First().Name);

            //List<Region> l = new List<Region>();
            //l = new Regions().Find(Where.Name, new object[] { "Africa", "Europe" });

            //foreach (var item in l)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name);
            //}

            //new Regions().Remove(Where.Id, new object[] { "0", "1" });

            //List<Region> l = new List<Region>();
            //l = new Regions().Find(Where.Name, new object[] { "Africa", "Europe" });

            //foreach (var item in l)
            //{
            //    Console.WriteLine(item.Id + " " + item.Name);
            //}

            Console.ReadKey(true);
        }
    }
}
