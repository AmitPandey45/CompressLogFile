using Newtonsoft.Json;
using System.IO;

namespace Melissa.ArchiveLog.Extension
{
    public static class JsonReader
    {
        /// <summary>
        /// Read the json file and convert to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path of the json file</param>
        /// <returns>Return the object equivalent to json object</returns>
        public static T GetObjectFromJsonFile<T>(string path)
        {
            T obj;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                obj = JsonConvert.DeserializeObject<T>(json);
            }
            return obj;
        }
    }
}
