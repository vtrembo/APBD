using System;
using System.Text.RegularExpressions;


namespace Tutorial_2.Helpers
{
    public static class TextCorrector
    {

        public static string[] CorrectStudent(String[] student)
        {
            student[0] = CorrectName(student[0]);
            student[1] = CorrectName(student[1]);
            student[7] = CorrectName(student[7]);
            student[8] = CorrectName(student[8]);
            if (Regex.IsMatch(student[6], "@pjwstk.edu.pl"))
                student[6] = "s" + student[4] + "@pjwstk.edu.pl";
            else FileParser.omitted = true;
            if (Regex.IsMatch(student[2], FileParser.courseName[1]) || Regex.IsMatch(student[2], "IT"))
            {
                student[2] = FileParser.courseName[1];
                FileParser.courseStudents[1]++;
            }
            else if (Regex.IsMatch(student[2], FileParser.courseName[0]))
            {
                student[2] = FileParser.courseName[0];
                FileParser.courseStudents[0]++;
            }
            else FileParser.omitted = true;
            student[3] = RemoveIntegers(student[3]);
            if ((Regex.IsMatch(student[3], "Dzienne")
                || Regex.IsMatch(student[3], "Zaoczne")
                || Regex.IsMatch(student[3], "Internetowe")) == false)
                FileParser.omitted = true;

                return student;
        }



        public static string CorrectName (string name)
        {
            if (Regex.IsMatch(name, @"[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]+"))
            {
                return RemoveIntegers(name); 
            }

            else
            {
                FileParser.omitted = true;
                return name;
            }
        }
        public static string RemoveIntegers(this string input)
        {
            return Regex.Replace(input, @"[\d-]", string.Empty);
        }
    }
}
