using System;
using System.Collections.Generic;
using System.IO;
using Tutorial_2.Models;

namespace Tutorial_2.Helpers
{
    public static class FileParser
    {
        public static bool omitted = false;
        public static int[] courseStudents = new int[2];
        public static string[] courseName = new string[2] { "Sztuka Nowych Mediów", "Informatyka" };

        public static University ParseFileFromCsv(FileInfo file)
        {
            DateTime datetime = DateTime.Now;
            HashSet<ActiveStudies> activeStud = new HashSet<ActiveStudies>();
            HashSet<Student> students = new HashSet<Student>();
            HashSet<Student> omittedStudents = new HashSet<Student>();
            using (StreamReader stream = new StreamReader(file.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');

                    student = TextCorrector.CorrectStudent(student);
                    
                    if (!omitted)
                    {
                        Student st = new Student
                        {

                            FirstName = student[0],
                            LastName = student[1],
                            StudentNumber = "s" + student[4],
                            Birthdate = student[5],
                            Email = student[6],
                            MothersName = student[7],
                            FathersName = student[8],
//                            studies = new Studies
//                            {
                                Course = student[2],
                                Mode = student[3]
//                            }
                        };
                        students.Add(st);
                    } else
                    {
                        Student omittedSt = new Student
                        {
                            FirstName = student[0],
                            LastName = student[1],
                            StudentNumber = "s" + student[4],
                            Birthdate = student[5],
                            Email = student[6],
                            MothersName = student[7],
                            FathersName = student[8],
//                           studies = new Studies
//                           {
                                Course = student[2],
                                Mode = student[3]
//                            }
                        };
                        omittedStudents.Add(omittedSt);
                        omitted = false;
                    }
                }
            }
            for (int i = 0; i < courseStudents.Length; i++) {
                ActiveStudies actstudies = new ActiveStudies
                {
                    Name = courseName[i],
                    numberOfStudents = courseStudents[i]
                };
                activeStud.Add(actstudies);
            }
            University un = new University
            {
                createdAt = datetime.ToString(),
                author = "Jan  Kowalski",
                students = students,
                activeStudies = activeStud
            };
            
                Writer.SaveFile(omittedStudents);
            return un;
        }
    }
}