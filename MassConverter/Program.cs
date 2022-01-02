using System;
using System.Collections.Generic;

namespace MassConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal mass = 0;
            decimal convertedMass;
            MassType startingType = (MassType)0;
            MassType endingType = (MassType)0;
            string userEntry = "abc";

            Console.WriteLine("Hello, and welcome to the Mass Converter (Console Edition)!");
            while (true)
            {
                while (startingType == (MassType)0)
                {
                    Console.WriteLine("Please select a number corresponding to a starting Mass Type from the following list:\n" +
                        "1: Microgram    6: Ounce\n" +
                        "2: Miligram     7: Pound\n" +
                        "3: Gram         8: Stone\n" +
                        "4: Kilogram     9: US Ton\n" +
                        "5: Metric Ton  10: Imperial Ton");
                    userEntry = Console.ReadLine();

                    if ((Int32.TryParse(userEntry, out int i)) && (i >= 1 && i <= 10))
                    {
                        startingType = (MassType)i;
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, I cannot accept that value.");
                    }
                }

                startingType = (MassType)Int32.Parse(userEntry);

                while (mass == 0)
                {
                    Console.WriteLine("Please enter the amount of Mass you want to convert:");
                    userEntry = Console.ReadLine();

                    if (Decimal.TryParse(userEntry, out decimal d))
                    {
                        mass = d;
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, I cannot accept that value.");
                    }
                }

                while (endingType == (MassType)0)
                {
                    Console.WriteLine("Please enter the number corresponding to an ending Mass Type from the following list:\n" +
                        "1: Microgram    6: Ounce\n" +
                        "2: Miligram     7: Pound\n" +
                        "3: Gram         8: Stone\n" +
                        "4: Kilogram     9: US Ton\n" +
                        "5: Metric Ton  10: Imperial Ton");
                    userEntry = Console.ReadLine();

                    if ((Int32.TryParse(userEntry, out int i)) && (i >= 1 && i <= 10))
                    {
                        endingType = (MassType)i;
                    }
                    else
                    {
                        Console.WriteLine("I'm sorry, I cannot accept that value.");
                    }
                }

                convertedMass = MassConverter.MainConverter(mass, startingType, endingType);

                Console.WriteLine("Thank you! Your conversion is as follows:" +
                    $"{mass} {startingType}s is equal to {convertedMass} {endingType}s");

                mass = 0;
                startingType = (MassType)0;
                endingType = (MassType)0;
            }
        }
    }
}
