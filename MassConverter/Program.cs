using System;
using System.Collections.Generic;

namespace MassConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create a text-based interface for using either sets of calculations

            // Test Code:
            // Variable Library
            double startingAmount = 1000;   // Altering this amount will change the value being converted in the tests
            int measurementSystem = 0;      // Altering this amount will change the system of conversion from metric (0) to imperial (anything else)
            List<Dictionary<string, int>> testCases = new List<Dictionary<string, int>>();

            // Add statements for populating the Dictionary
            for (int i = 1; i < 5; i++)
            {
                testCases.Add(new Dictionary<string, int>
                {
                    { "startingMassType", i },
                    { "endingMassType", i + 1 }
                });
            }
            for (int i = 5; i > 1; i--)
            {
                testCases.Add(new Dictionary<string, int>
                {
                    { "startingMassType", i },
                    { "endingMassType", i - 1 }
                });
            }
            testCases.Add(new Dictionary<string, int>
            {
                { "startingMassType", 1 },
                { "endingMassType", 5 }
            });
            testCases.Add(new Dictionary<string, int>
            {
                { "startingMassType", 5 },
                { "endingMassType", 1 }
            });

            // Using the test cases to display various tests in a user friendly way.
            foreach (Dictionary<string, int> test in testCases)
            {
                Console.WriteLine($"{startingAmount} {massTypeMetric(test["startingMassType"])} is: " +
                    $"{(measurementSystem == 0 ? MassConverter.MetricConversions(startingAmount, test["startingMassType"], test["endingMassType"]) : MassConverter.ImperialConversions(startingAmount, test["startingMassType"], test["endingMassType"]))} " +
                    $"{(measurementSystem == 0 ? massTypeMetric(test["endingMassType"]) : massTypeImperial(test["endingMassType"]))}s.");
            }

            // Return a string value to determine the type of measurement used in [startingMassType] and [endingMassType]
            string massTypeMetric(int index)
            {
                switch (index)
                {
                    case 1: return "microgram";
                    case 2: return "miligram";
                    case 3: return "gram";
                    case 4: return "kilogram";
                    case 5: return "metric ton";
                    default: return "Error, number outside of range.";
                }
            }
            string massTypeImperial(int index)
            {
                switch (index)
                {
                    case 1: return "ounce";
                    case 2: return "pound";
                    case 3: return "stone";
                    case 4: return "US ton";
                    case 5: return "imperial ton";
                    default: return "Error, number outside of range.";
                }
            }
        }
    }
}
