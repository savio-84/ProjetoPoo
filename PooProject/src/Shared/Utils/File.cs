using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

namespace PooProject
{
    public class File<T>
    {
        public T Open(string file)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            StreamReader f = new StreamReader(file, Encoding.Default);
            T obj = (T)xml.Deserialize(f);
            f.Close();
            return obj;
            
        }

        public void Save(string file, T obj)
        {
            
            XmlSerializer xml = new XmlSerializer(typeof(T));
            StreamWriter f = new StreamWriter(file, false, Encoding.Default);
            xml.Serialize(f, obj);
            f.Close();
        
        }


    }
}
