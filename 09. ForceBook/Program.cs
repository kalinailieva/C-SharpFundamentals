using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._ForceBook
{
    class Program
    {
        static void Main()
        {
            var forceBook = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    var inputLine = input.Split(" | ").ToList();
                    string side = inputLine[0];
                    string user = inputLine[1];
                    if (!forceBook.ContainsKey(side))
                    {
                        forceBook[side] = new List<string>();
                    }
                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            break;
                        }
                    }
                    forceBook[side].Add(user);
                }
                else if(input.Contains("->"))
                {
                    var inputLine = input.Split(" -> ").ToList();
                    string user = inputLine[0];
                    string side = inputLine[1];

                    foreach (var kvp in forceBook)
                    {
                        if (kvp.Value.Contains(user))
                        {
                            kvp.Value.Remove(user);
                        }
                    }
                    forceBook[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
                input = Console.ReadLine();
            }
            foreach (var kvp in forceBook.Where(x => x.Value.Count>0)
                .OrderByDescending(x => x.Value.Count).ThenBy(x =>x.Key))
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {item}");
                }
            }
        }
    }
}
        