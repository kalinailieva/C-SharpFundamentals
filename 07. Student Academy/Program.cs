using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();
            var higherGrades = new Dictionary<string, double>();
            

            for (int i = 0; i < n; i ++)
            {
                string input = Console.ReadLine();
                string student = input;
                double grade = double.Parse(Console.ReadLine());
                if (!studentsGrades.ContainsKey(student))
                {
                    studentsGrades[student] = new List<double>();
                }
                studentsGrades[student].Add(grade);
                if (studentsGrades[student].Average() >= 4.5)
                {
                    double averageGrade = studentsGrades[student].Average();
                    if (!higherGrades.ContainsKey(student))
                    {
                        higherGrades[student] = 0;
                    }
                    higherGrades[student] = averageGrade;
                }
                
            }

            foreach (var studentName in higherGrades.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{studentName.Key} -> {studentName.Value}");
                }
            
        }
    }
}
