namespace _02E.DictRefAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DictRefAdvanced
    {
        static void Main()
        {
            char[] delimeters = new char[] { ' ', '-', '>', ',' };
            var inputLine = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var dict = new Dictionary<string, List<int>>();

            while (inputLine[0] != "end")
            {
                var name = inputLine[0];
                int value;
                bool isDigit = int.TryParse(inputLine[1], out value);

                if (isDigit)
                {
                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = new List<int>();
                    }

                    for (int i = 1; i < inputLine.Length; i++)
                    {
                        isDigit = int.TryParse(inputLine[i], out value);
                        dict[name].Add(value);
                    }
                }
                else
                {
                    if (!dict.ContainsKey(inputLine[1]))
                    {
                        inputLine = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        continue;
                    }

                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = new List<int>();
                    }

                    dict[name].AddRange(dict[inputLine[1]]);
                }

                inputLine = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var name in dict)
            {
                Console.WriteLine($"{name.Key} === {string.Join(", ", name.Value)}");
            }
        }
    }
}
