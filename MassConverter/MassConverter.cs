using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassConverterConsole
{
    public class MassConverter
    {
        // ================================================== Metric Methods ==================================================
        // Ascending Metric Conversion Methods:
        public static decimal MicrogramToMiligram(decimal microgram) { return microgram / 1000; }
        public static decimal MiligramToGram(decimal miligram) { return miligram / 1000; }
        public static decimal GramToKilogram(decimal gram) { return gram / 1000; }
        public static decimal KilogramToMetricTon(decimal kilogram) { return kilogram / 1000; }
        // Descending Metric Conversion Methods:
        public static decimal MetricTonToKilogram(decimal metricTon) { return metricTon * 1000; }
        public static decimal KilogramToGram(decimal kilogram) { return kilogram * 1000; }
        public static decimal GramToMiligram(decimal gram) { return gram * 1000; }
        public static decimal MiligramToMicrogram(decimal miligram) { return miligram * 1000; }

        // Main Metric Conversion Method
        public static decimal MetricConversions(decimal mass, int startingType, int endingType)
        {
            if (startingType < 1 || startingType > 5) { throw new ArgumentOutOfRangeException("[startingType] should be an integer between 1 and 5."); }
            if (endingType < 1 || endingType > 5) { throw new ArgumentOutOfRangeException("[endingType] should be an integer between 1 and 5."); }
            if (startingType == endingType) { return mass; }
            decimal convertedMass = mass;

            if (startingType > endingType)
            {
                startingType = -startingType;
                endingType = -endingType;
            }

            switch (startingType)
            {

                case 1:
                    convertedMass = MicrogramToMiligram(convertedMass);
                    if (endingType == 2) { break; } else { goto case 2; }
                case 2:
                    convertedMass = MiligramToGram(convertedMass);
                    if (endingType == 3) { break; } else { goto case 3; }
                case 3:
                    convertedMass = GramToKilogram(convertedMass);
                    if (endingType == 4) { break; } else { goto case 4; }
                case 4:
                    convertedMass = KilogramToMetricTon(convertedMass);
                    break;

                case -5:
                    convertedMass = MetricTonToKilogram(convertedMass);
                    if (endingType == -4) { break; } else { goto case -4; }
                case -4:
                    convertedMass = KilogramToGram(convertedMass);
                    if (endingType == -3) { break; } else { goto case -3; }
                case -3:
                    convertedMass = GramToMiligram(convertedMass);
                    if (endingType == -2) { break; } else { goto case -2; }
                case -2:
                    convertedMass = MiligramToMicrogram(convertedMass);
                    break;
            }

            return convertedMass;
        }

        // ================================================== Imperial Methods ==================================================
        // TODO: Create methods to convert different measurements of mass in imperial
            // TODO: Create separate methods for converting between: Ounce <-> Pound <-> Stone <-> US Ton <-> Imperial Ton
            // TODO: Create a control method to simplify user input by chaining multiple methods together to convert between one mass to a significantly larger/smaller one
        public static decimal ImperialConversions(decimal mass, int startingType, int endingType)
        {
            return 0;
        }
        // TODO: Create methods to convert different measurements of mass between metric and imperial
        // TODO: Create a master method to freely convert between any two types of mass
    }
}
