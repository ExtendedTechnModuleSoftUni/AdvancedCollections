namespace _01E.Shellbound
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Shellbound
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split().ToArray();

            var regions = new Dictionary<string, HashSet<int>>();

            while (inputLine[0] != "Aggregate")
            {
                AddingRegionsAndShells(inputLine, regions);

                inputLine = Console.ReadLine().Split().ToArray();
            }

            PrintResult(regions);
        }

        private static void PrintResult(Dictionary<string, HashSet<int>> regions)
        {
            foreach (var region in regions)
            {
                int shellsSum = region.Value.Sum();
                int average = shellsSum / region.Value.Count;
                int shellsCount = shellsSum - average;

                if (region.Value.Count < 2)
                {
                    average = region.Value.Sum();
                }

                Console.WriteLine($"{region.Key} -> {string.Join(", ", region.Value)} ({shellsCount})");
            }
        }

        private static void AddingRegionsAndShells(string[] inputLine, Dictionary<string, HashSet<int>> regions)
        {
            var region = inputLine[0];
            var shellSize = int.Parse(inputLine[1]);

            if (!regions.ContainsKey(region))
            {
                regions[region] = new HashSet<int>();
            }

            regions[region].Add(shellSize);
        }
    }
}
