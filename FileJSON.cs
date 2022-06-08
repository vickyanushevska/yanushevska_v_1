using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FileJSON
    {
        public static void SafeTo(Triangle num1)
        {
            string objectToSerialize = JsonConvert.SerializeObject(num1);
            File.WriteAllText("D:/1курс_2семестр/Програмування-2/LAB_1/triangles_laba1/file.json", objectToSerialize);
        }

        public static Triangle ReadFrom(string path)
        {
            string json = File.ReadAllText("D:/1курс_2семестр/Програмування-2/LAB_1/triangles_laba1/file.json");
            Triangle num1 = JsonConvert.DeserializeObject<Triangle>(json);
            return num1;
        }
    }
}
