using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Company_Users
{
    class Program
    {
        static void Main()
        {
            var companyUsers = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                var inputData = input.Split(" -> ").ToList();
                string company = inputData[0];
                string employeeID = inputData[1];

                if (!companyUsers.ContainsKey(company))
                {
                    companyUsers[company] = new List<string>();
                }
                if (!companyUsers[company].Contains(employeeID))
                {
                    companyUsers[company].Add(employeeID);
                }
                input = Console.ReadLine();
            }
            foreach (var user in companyUsers.OrderBy(x=> x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
