namespace _02L.CitiesByContinentCountry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CitiesByContinentCountry
    {
        static void Main()
        {
            var numberOfContinents = int.Parse(Console.ReadLine());

            var cityByCountryByContinent = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfContinents; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                AddingInformationInDict(cityByCountryByContinent, tokens);
            }
            
            PrintingResult(cityByCountryByContinent);
        }

        private static void PrintingResult(Dictionary<string, Dictionary<string, List<string>>> cityByCountryByContinent)
        {
            foreach (var continentCountry in cityByCountryByContinent)
            {
                var continentName = continentCountry.Key;
                var countries = continentCountry.Value;

                Console.WriteLine($"{continentName}:");

                foreach (var countryTowns in countries)
                {
                    var countryName = countryTowns.Key;
                    var cities = countryTowns.Value;

                    Console.WriteLine($"  {countryName} -> {string.Join(", ", cities)}");
                }
            }
        }

        private static void AddingInformationInDict(Dictionary<string, Dictionary<string, List<string>>> cityByCountryByContinent, string[] tokens)
        {
            string continent = tokens[0];
            string country = tokens[1];
            string city = tokens[2];

            if (!cityByCountryByContinent.ContainsKey(continent))
            {
                cityByCountryByContinent[continent] = new Dictionary<string, List<string>>();
            }
            if (!cityByCountryByContinent[continent].ContainsKey(country))
            {
                cityByCountryByContinent[continent][country] = new List<string>();
            }

            cityByCountryByContinent[continent][country].Add(city);
        }
    }
}
