namespace _01L.AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AverageStudentGrades
    {
        static void Main()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            var studentsAndGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                var inputLine = Console.ReadLine().Split().ToArray();
                AddingStudentsAndGrades(studentsAndGrades, inputLine);
            }

            PrintResult(studentsAndGrades);
        }

        private static void PrintResult(Dictionary<string, List<double>> studentsAndGrades)
        {
            foreach (var kvp in studentsAndGrades)
            {
                string name = kvp.Key;
                var grades = kvp.Value;
                var average = grades.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {average:f2})");
            }
        }

        private static void AddingStudentsAndGrades(Dictionary<string, List<double>> studentsAndGrades, string[] inputLine)
        {
            string name = inputLine[0];
            double grade = double.Parse(inputLine[1]);
            if (!studentsAndGrades.ContainsKey(name))
            {
                studentsAndGrades[name] = new List<double>();
            }

            studentsAndGrades[name].Add(grade);
        }
    }
}
