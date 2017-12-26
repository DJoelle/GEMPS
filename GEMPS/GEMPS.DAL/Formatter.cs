using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GEMPS.DAL
{
    public enum Format
    {
        binary,
        xml
    };

    public class Formatter<T>
    {
        public T Obj { get; set; }
        public string File { get; set; }

        public Formatter()
        {

        }

        public Formatter(string file)
        {
            File = file;
        }

        public Formatter(T obj, string file) : this(file)
        {
            Obj = obj;
        }

        public void Serialize(Format format)
        {
            switch (format)
            {
                case Format.binary:
                    BinaryFormatter bf = new BinaryFormatter();
                    using (StreamWriter wr = new StreamWriter(this.File))
                    {
                        bf.Serialize(wr.BaseStream, this.Obj);
                    }
                    break;

                case Format.xml:
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    using (StreamWriter wr = new StreamWriter(this.File))
                    {
                        xs.Serialize(wr, this.Obj);
                    }
                    break;
            }
        }

        public T Deserialize(Format format)
        {
            switch (format)
            {
                case Format.binary:
                    BinaryFormatter bf = new BinaryFormatter();
                    using (StreamReader sr = new StreamReader(this.File))
                    {
                        return (T)bf.Deserialize(sr.BaseStream);
                    }
                    break;

                case Format.xml:
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    using (StreamReader sr = new StreamReader(this.File))
                    {
                        return (T)xs.Deserialize(sr);
                    }
                    break;

                default:
                    return this.Obj;
                    break;
            }
        }
    }
}
