using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Utilities
{
    public class JsonUtils
    {
        public static string ReadJsonFile(string path)
        {
            path = Path.Combine(DirectorUtils.GetCurrentDirectoryPath(), path);
            if (!File.Exists(path))
            {
                throw new Exception("Can't file path " + path);
            }
            return File.ReadAllText(path);
        }
        public static T ReadDictionaryJson<T>(string filepath)
        {
            filepath = Path.Combine(DirectorUtils.GetCurrentDirectoryPath(), filepath);
            if (!File.Exists(filepath))
            {
                throw new Exception("Can't file filepath " + filepath);
            }
            var jsonData = File.ReadAllText(filepath);
            var data = JsonConvert.DeserializeObject<T>(jsonData);
            return data;
        }


        // public static T ReadAndParse<T>(string path) where T : class
        // {
        //     var jsonContent = ReadJsonFile(path);
        //     return JsonConvert.DeserializeObject<T>(jsonContent);
        // }

    }
}