using System.IO;
using Tutorial_2.Helpers;
using Tutorial_2.Models;

namespace Tutorial_2
{
    class Program
    {
        private static void Main(string[] args)
        {
            string path = args.Length > 0 ? args[0] : "./Data/dane.csv";
            string dataFormat = args.Length > 0 ? args[2] : "json";
            string destinationPath = args.Length > 0 ? args[1] : $"result.{dataFormat}";
            FileInfo fi = new FileInfo(path);
            University university = FileParser.ParseFileFromCsv(fi);
            string jsonString = Serializer.SerializeToJson(university);
            File.WriteAllText(destinationPath, jsonString);
        }
    }
}