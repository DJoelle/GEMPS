using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GEMPS.DAL
{
    public class MyMD5
    {
        public string Input { get; set; }

        public MyMD5(string input)
        {
            Input = input;
        }

        public string Hash()
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(this.Input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}
