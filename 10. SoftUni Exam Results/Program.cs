using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main()
        {
            var userPoints = new Dictionary<string, int>();
            var examSubmission = new Dictionary<string, int>();
            var bannedUsers = new List<string>();
            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                var inputLine = input.Split("-").ToList();
                int inputLength = inputLine.Count();

                if (inputLength == 3)
                {
                    string username = inputLine[0];
                    string language = inputLine[1];
                    int points = int.Parse(inputLine[2]);
                    
                    if (!userPoints.ContainsKey(username))
                    {
                        userPoints[username] = 0;
                    }
                    int previousPoints = userPoints[username];
                    if (points > previousPoints)
                    {
                        userPoints[username] = points;
                    }
                    if (!examSubmission.ContainsKey(language))
                    {
                        examSubmission[language] = 0;
                    }
                    examSubmission[language]++;
                }
                else //input == 2
                {
                    string username = inputLine[0];
                    if (userPoints.ContainsKey(username))
                    {
                        userPoints.Remove(username);
                        bannedUsers.Add(username);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var kvp in userPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                .Where(x=> !bannedUsers.Contains(x.Key)))
            {

                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in examSubmission.OrderByDescending(x =>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
