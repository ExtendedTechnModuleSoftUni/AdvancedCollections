namespace _03L.RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    class RecordUniqueNames
    {
        static void Main()
        {
            var numberOfNames = int.Parse(Console.ReadLine());
            var uniqueNames = new HashSet<string>();

            AddingUniqueNames(numberOfNames, uniqueNames);

            PrintUniqueNames(uniqueNames);
        }

        private static void PrintUniqueNames(HashSet<string> uniqueNames)
        {
            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void AddingUniqueNames(int numberOfNames, HashSet<string> uniqueNames)
        {
            for (int i = 0; i < numberOfNames; i++)
            {
                var name = Console.ReadLine();

                uniqueNames.Add(name);
            }
        }
    }
}
