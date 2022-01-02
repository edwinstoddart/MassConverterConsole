using System;

namespace MassConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create a text-based interface for using either sets of calculations

            // Test Statements:
            double startingAmount = 1;
            Console.WriteLine(startingAmount + " microgram is: " + MassConverter.MicrogramToMiligram(startingAmount) + " miligrams.");
            Console.WriteLine(startingAmount + " miligram is: " + MassConverter.MiligramToGram(startingAmount) + " grams.");
            Console.WriteLine(startingAmount + " gram is: " + MassConverter.GramToKilogram(startingAmount) + " kilograms.");
            Console.WriteLine(startingAmount + " kilogram is: " + MassConverter.KilogramToMetricTon(startingAmount) + " metric tons.");

            Console.WriteLine(startingAmount + " metric ton is: " + MassConverter.MetricTonToKilogram(startingAmount) + " kilograms.");
            Console.WriteLine(startingAmount + " kilogram is: " + MassConverter.KilogramToGram(startingAmount) + " grams.");
            Console.WriteLine(startingAmount + " gram is: " + MassConverter.GramToMiligram(startingAmount) + " miligrams.");
            Console.WriteLine(startingAmount + " miligram is: " + MassConverter.MiligramToMicrogram(startingAmount) + " micrograms.");

            Console.WriteLine(startingAmount + " microgram is: " + MassConverter.MetricConversions(startingAmount, 1, 5) + " metric tons.");
            Console.WriteLine(startingAmount + " metric ton is: " + MassConverter.MetricConversions(startingAmount, 5, 1) + " micrograms.");
        }
    }
}
