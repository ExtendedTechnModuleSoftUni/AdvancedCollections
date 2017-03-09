namespace _04L.GroupContinentsCountriesCities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupContinentsCountriesCities
    {
        public static void Main()
        {
            var numberOfInputLines = int.Parse(Console.ReadLine());

            var continentCountryCity = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            AddingContinentsCountriesCities(numberOfInputLines, continentCountryCity);

            PrintingAllContinentsCountriesCities(continentCountryCity);
        }

        private static void PrintingAllContinentsCountriesCities(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> continentCountryCity)
        {
            foreach (var continents in continentCountryCity)
            {
                var continent = continents.Key;
                var countries = continents.Value;

                Console.WriteLine($"{continent}:");

                foreach (var country in countries)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }

        private static void AddingContinentsCountriesCities(int numberOfInputLines, SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> continentCountryCity)
        {
            for (int i = 0; i < numberOfInputLines; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();

                var currentContinent = tokens[0];
                var currentCountry = tokens[1];
                var currentCity = tokens[2];

                if (!continentCountryCity.ContainsKey(currentContinent))
                {
                    continentCountryCity[currentContinent] = new SortedDictionary<string, SortedSet<string>>();
                }
                if (!continentCountryCity[currentContinent].ContainsKey(currentCountry))
                {
                    continentCountryCity[currentContinent][currentCountry] = new SortedSet<string>();
                }

                continentCountryCity[currentContinent][currentCountry].Add(currentCity);
            }
        }
    }
}
