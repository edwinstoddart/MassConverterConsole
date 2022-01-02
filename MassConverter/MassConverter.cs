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
        // Ascending Imperial Conversion Methods:
        public static decimal OunceToPound(decimal ounce) { return ounce / (decimal)16; }
        public static decimal PoundToStone(decimal pound) { return pound / (decimal)14; }
        public static decimal StoneToUsTon(decimal stone) { return stone / (decimal)142.8571428571; }
        public static decimal UsTonToImperialTon(decimal usTon) { return usTon / (decimal)1.12; }
        // Descending Imperial Conversion Methods:
        public static decimal ImperialTonToUsTon(decimal imperialTon) { return imperialTon * (decimal)1.12; }
        public static decimal UsTonToStone(decimal usTon) { return usTon * (decimal)142.8571428571; }
        public static decimal StoneToPound(decimal stone) { return stone * (decimal)14; }
        public static decimal PoundToOunce(decimal pound) { return pound * (decimal)16; }

        // Main Imperial Conversion Method
        public static decimal ImperialConversions(decimal mass, int startingType, int endingType)
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
                    convertedMass = OunceToPound(convertedMass);
                    if (endingType == 2) { break; } else { goto case 2; }
                case 2:
                    convertedMass = PoundToStone(convertedMass);
                    if (endingType == 3) { break; } else { goto case 3; }
                case 3:
                    convertedMass = StoneToUsTon(convertedMass);
                    if (endingType == 4) { break; } else { goto case 4; }
                case 4:
                    convertedMass = UsTonToImperialTon(convertedMass);
                    break;

                case -5:
                    convertedMass = ImperialTonToUsTon(convertedMass);
                    if (endingType == -4) { break; } else { goto case -4; }
                case -4:
                    convertedMass = UsTonToStone(convertedMass);
                    if (endingType == -3) { break; } else { goto case -3; }
                case -3:
                    convertedMass = StoneToPound(convertedMass);
                    if (endingType == -2) { break; } else { goto case -2; }
                case -2:
                    convertedMass = PoundToOunce(convertedMass);
                    break;
            }

            return convertedMass;
        }
        // TODO: Create methods to convert different measurements of mass between metric and imperial
        // TODO: Create a master method to freely convert between any two types of mass
    }
}
