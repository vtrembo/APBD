using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Tutorial_3.Models;

namespace Tutorial_3.Services
{
    public  class ManagerCSV 
    {
        private static String pathToFile = "./Data/students.csv";
        public static void SaveToCSV(List<Student> saveData, bool overwrite)
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(Student)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            //lines.Add(header);
            var valueLines = saveData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            if (overwrite == true)
            {
                File.WriteAllLines(pathToFile, lines.ToArray());
            } else
            {
                File.AppendAllLines(pathToFile, lines.ToArray());
            }
        }
        public static void ReadCSV(List<Student> list)
        {
            var lines = System.IO.File.ReadAllLines(pathToFile);
            foreach (string item in lines)
            {
                var values = item.Split(',');
                list.Add(new Student()
                {
                    FirstName = values[0],
                    LastName = values[1],
                    indexNumber = values[2],
                    Birthdate = values[3],
                    Studies = values[4],
                    Mode = values[5],
                    Email = values[6],
                    MothersName = values[7],
                    FathersName = values[8]
                }) ;
            }
        }
        public static void findByIndexNumber(List<Student> list, string indexNumber)
        {
            var lines = System.IO.File.ReadAllLines(pathToFile);
            foreach (string item in lines)
            {
                if (Regex.IsMatch(item, indexNumber))
                {
                    var values = item.Split(',');
                    list.Add(new Student()
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        indexNumber = values[2],
                        Birthdate = values[3],
                        Studies = values[4],
                        Mode = values[5],
                        Email = values[6],
                        MothersName = values[7],
                        FathersName = values[8]
                    });
                }
            }
        }
        public static void DeleteFromCSV(List<Student> list, string indexNumber)
        {
            var lines = System.IO.File.ReadAllLines(pathToFile);
            
            foreach (string item in lines)
            {
                if (!Regex.IsMatch(item, indexNumber))
                {
                    var values = item.Split(',');
                    list.Add(new Student()
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        indexNumber = values[2],
                        Birthdate = values[3],
                        Studies = values[4],
                        Mode = values[5],
                        Email = values[6],
                        MothersName = values[7],
                        FathersName = values[8]
                    });
                }
            }

        }
        public static List<Student> UpdateCSV(Student updatedStudent, string indexNumber)
        {
             List<Student> students = new List<Student>();
        var lines = System.IO.File.ReadAllLines(pathToFile);

            foreach (string item in lines)
            {
                if (!Regex.IsMatch(item, indexNumber))
                {
                    var values = item.Split(',');
                    students.Add(new Student()
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        indexNumber = values[2],
                        Birthdate = values[3],
                        Studies = values[4],
                        Mode = values[5],
                        Email = values[6],
                        MothersName = values[7],
                        FathersName = values[8]
                    });
                }
                else    
                {
                    students.Add(updatedStudent);
                }
            }
            return students;
        }
    }
}