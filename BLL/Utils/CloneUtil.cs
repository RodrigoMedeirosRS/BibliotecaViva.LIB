using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BibliotecaViva.BLL.Utils
{
    public static class CloneUtil
    {
        public static T DeepClone<T>(T objeto) //deve ter [Serializable]
        {
            using (MemoryStream stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, objeto);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
