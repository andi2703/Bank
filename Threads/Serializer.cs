using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Threads
{
    public static class Serializer<T>
    {
        public static void Save(string path, T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                serializer.Serialize(stream, data);
            }
        }
        public static T Load(string path)
        {
            Type type = typeof(T);
            T value;
            XmlSerializer serializer = new XmlSerializer(type);
            using(FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                value = (T)serializer.Deserialize(stream);
            }
            return value;
        }
    }
}
