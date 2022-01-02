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
            string userEntry;

            Console.WriteLine("Hello, and welcome to the Mass Converter (Console Edition)!");
            while (true)
            {
                while (startingType == (MassType)0)
                {
                    Console.WriteLine("Would you please select a number corresponding to the Mass Type you need to convert:\n" +
                        "1: Microgram    6: Ounce\n" +
                        "2: Miligram     7: Pound\n" +
                        "3: Gram         8: Stone\n" +
                        "4: Kilogram     9: US Ton\n" +
                        "5: Metric Ton  10: Imperial Ton");
                    userEntry = Console.ReadLine();
                    Console.Clear();

                    if ((Int32.TryParse(userEntry, out int s)) && (s >= 1 && s <= 10))
                    {
                        startingType = (MassType)s;
                    }
                    else
                    {
                        Console.WriteLine(InvalidEntryMessage());
                    }
                }

                while (mass == 0)
                {
                    Console.WriteLine(StatusBar(mass, startingType, endingType));
                    Console.WriteLine("Would you please enter the amount of Mass you want to convert:");
                    userEntry = Console.ReadLine();
                    Console.Clear();

                    if (Decimal.TryParse(userEntry, out decimal m))
                    {
                        mass = m;
                    }
                    else
                    {
                        Console.WriteLine(InvalidEntryMessage());
                    }
                }

                while (endingType == (MassType)0)
                {
                    Console.WriteLine(StatusBar(mass, startingType, endingType));
                    Console.WriteLine("Would you please select the number corresponding to the Mass Type you want to convert to:\n" +
                        "1: Microgram    6: Ounce\n" +
                        "2: Miligram     7: Pound\n" +
                        "3: Gram         8: Stone\n" +
                        "4: Kilogram     9: US Ton\n" +
                        "5: Metric Ton  10: Imperial Ton");
                    userEntry = Console.ReadLine();
                    Console.Clear();

                    if ((Int32.TryParse(userEntry, out int e)) && (e >= 1 && e <= 10))
                    {
                        endingType = (MassType)e;
                    }
                    else
                    {
                        Console.WriteLine(InvalidEntryMessage());
                    }
                }

                convertedMass = MassConverter.MainConverter(mass, startingType, endingType);

                Console.Write("Thank you! ");

                while (true)
                {
                    Console.WriteLine("Your conversion is as follows: " +
                    $"{mass} {startingType} is equal to {convertedMass} {endingType}");
                    Console.WriteLine("Would you like to convert another body of mass? ( Y / N )");
                    userEntry = Console.ReadLine();

                    if (userEntry.ToLower().Equals("y") || userEntry.ToLower().Equals("n"))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(InvalidEntryMessage());
                }

                Console.Clear();

                if (userEntry.ToLower().Equals("n"))
                {
                    Console.WriteLine("Alright. Thank you for using my services. I hope to see you again!");
                    break;
                }

                Console.WriteLine("Okay, I'm happy to be of service!");

                mass = 0;
                startingType = (MassType)0;
                endingType = (MassType)0;
            }
        }

        private static string StatusBar(decimal mass, MassType startingType, MassType endingType)
        {
            return $"Convert {(mass == 0 ? "???" : mass)} {(startingType == (MassType)0 ? "???" : startingType)} To {(endingType == (MassType)0 ? "???" : endingType)}";
        }

        private static string InvalidEntryMessage()
        {
            return "I'm sorry, I cannot accept that value.";
        }
    }
}
