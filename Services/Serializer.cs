using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Services
{
    public class Serializer
    {
        public object Deserialize(string directory, string filename)
        {
            object returnn = null;
            if (File.Exists(directory + "/" + filename))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(directory + "/" + filename, FileMode.Open, FileAccess.Read);
                returnn = formatter.Deserialize(stream);
                stream.Close();
                stream.Dispose();

            }

            return returnn;

        }
    }
}
