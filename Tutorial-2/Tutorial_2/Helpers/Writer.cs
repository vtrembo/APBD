using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Tutorial_2.Models;

namespace Tutorial_2.Helpers
{
    class Writer
    {
        private static String pathToFile = "log.txt";

        public static void SaveFile(HashSet<Student> saveData)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(Student)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            //lines.Add(header);
            var valueLines = saveData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
                File.WriteAllLines(pathToFile, lines.ToArray());
        }
    }
}
