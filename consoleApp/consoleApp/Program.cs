using consoleApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create lists of City and Country
            List<City> cities = new List<City>
        {
            new City { Name = "Toronto", Country = "Canada" },
            new City { Name = "Vancouver", Country = "Canada" },
            new City { Name = "New York", Country = "US" },
            new City { Name = "Los Angeles", Country = "US" },
            new City { Name = "Paris", Country = "France" }
        };

            List<Country> counties = new List<Country>
        {
            new Country { Name = "Canada", Code = "CA" },
            new Country { Name = "US", Code = "US" },
            new Country { Name = "France", Code = "FR" }
        };

            // Query to get all cities for Canada
            var citiesInCanada = cities.Where(city => city.Country == "Canada");

            Console.WriteLine("Cities in Canada:");
            foreach (var city in citiesInCanada)
            {
                Console.WriteLine(city.Name);
            }

            // Query method to get the city when the country is US
            var cityInUS = cities.FirstOrDefault(city => city.Country == "US");
            if (cityInUS != null)
            {
                Console.WriteLine("\nCity in the US:");
                Console.WriteLine(cityInUS.Name);
            }

            // Get the list of all distinct cities
            var distinctCities = cities.Select(city => city.Name).Distinct();

            Console.WriteLine("\nDistinct Cities:");
            foreach (var city in distinctCities)
            {
                Console.WriteLine(city);
            }
            Console.ReadKey(); // Wait for a key press before closing the console windowz
        }
    }
}
