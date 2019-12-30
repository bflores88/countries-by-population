using System;
using System.Collections.Generic;

namespace countries
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Pop by Largest Final.csv";

            CsvReader reader = new CsvReader(path);

            List<Country> countries = reader.ReadAllCountries();
            reader.RemoveCommaCountries(countries);

            Console.Write("Enter no. of countries to display > ");
            bool inputsIsInt = int.TryParse(Console.ReadLine(), out int userInput);
            if(!inputsIsInt || userInput <= 0)
            {
                System.Console.WriteLine("You must type in a +ve integer.  Exiting");
                return;
            }

            int maxToDisplay = userInput;
            for (int i = 0; i < countries.Count; i++)
            {
                if( i > 0 && (i % maxToDisplay == 0))
                {
                    Console.WriteLine("Hit return to continue, anything else to quit > ");
                    if(Console.ReadLine() != "")
                        break;
                }
                Country country = countries[i];
                Console.WriteLine($"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }

            // foreach (var country in countries)
            // {
            //     Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            // }
            // Console.WriteLine($"{countries.Count} countries");


            /* WITH DICTIONARY

            Dictionary<string, Country> countries = reader.ReadAllCountries();

            Console.WriteLine("Which country code do you want to look up?");
            string userInput = Console.ReadLine();

            bool gotCountry = countries.TryGetValue(userInput.ToUpper(), out Country country);
            if(!gotCountry)
                Console.WriteLine($"Sorry, there is no country with code, {userInput}");
            else
                Console.WriteLine($"{country.Name} has population {PopulationFormatter.FormatPopulation(country.Population)}");

            */
        }
    }
}
