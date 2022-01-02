using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassConverterConsole
{
    public enum MassType
    {
        Microgram = 1,
        Miligram = 2,
        Gram = 3,
        Kilogram = 4,
        MetricTon = 5,
        Ounce = 6,
        Pound = 7,
        Stone = 8,
        UsTon = 9,
        ImperialTon = 10
    }

    public class MassConverter
    {
        // ================================================== Metric Methods ==================================================
        // Ascending Metric Conversion Methods:
        private static decimal MicrogramToMiligram(decimal microgram) { return microgram / 1000; }
        private static decimal MiligramToGram(decimal miligram) { return miligram / 1000; }
        private static decimal GramToKilogram(decimal gram) { return gram / 1000; }
        private static decimal KilogramToMetricTon(decimal kilogram) { return kilogram / 1000; }
        // Descending Metric Conversion Methods:
        private static decimal MetricTonToKilogram(decimal metricTon) { return metricTon * 1000; }
        private static decimal KilogramToGram(decimal kilogram) { return kilogram * 1000; }
        private static decimal GramToMiligram(decimal gram) { return gram * 1000; }
        private static decimal MiligramToMicrogram(decimal miligram) { return miligram * 1000; }

        // Main Metric Conversion Method
        private static decimal MetricConversions(decimal mass, MassType startingType, MassType endingType)
        {
            if (startingType is < (MassType)1 or > (MassType)5) { throw new ArgumentOutOfRangeException("[startingType] should be a [MassType] Enum between 1 and 5."); }
            if (endingType is < (MassType)1 or > (MassType)5) { throw new ArgumentOutOfRangeException("[endingType] should be a [MassType] Enum between 1 and 5."); }
            if ((int)startingType == (int)endingType) { return mass; }
            decimal convertedMass = mass;

            if (startingType < endingType)
            {
                switch (startingType)
                {
                    case MassType.Microgram:
                        convertedMass = MicrogramToMiligram(convertedMass);
                        if (endingType == MassType.Miligram) { break; } else { goto case MassType.Miligram; }
                    case MassType.Miligram:
                        convertedMass = MiligramToGram(convertedMass);
                        if (endingType == MassType.Gram) { break; } else { goto case MassType.Gram; }
                    case MassType.Gram:
                        convertedMass = GramToKilogram(convertedMass);
                        if (endingType == MassType.Kilogram) { break; } else { goto case MassType.Kilogram; }
                    case MassType.Kilogram:
                        convertedMass = KilogramToMetricTon(convertedMass);
                        break;
                }
            }
            else
            {
                switch (startingType)
                {
                    case MassType.MetricTon:
                        convertedMass = MetricTonToKilogram(convertedMass);
                        if (endingType == MassType.Kilogram) { break; } else { goto case MassType.Kilogram; }
                    case MassType.Kilogram:
                        convertedMass = KilogramToGram(convertedMass);
                        if (endingType == MassType.Gram) { break; } else { goto case MassType.Gram; }
                    case MassType.Gram:
                        convertedMass = GramToMiligram(convertedMass);
                        if (endingType == MassType.Miligram) { break; } else { goto case MassType.Miligram; }
                    case MassType.Miligram:
                        convertedMass = MiligramToMicrogram(convertedMass);
                        break;
                }
            }

            return convertedMass;
        }

        // ================================================== Imperial Methods ==================================================
        // Ascending Imperial Conversion Methods:
        private static decimal OunceToPound(decimal ounce) { return ounce / (decimal)16; }
        private static decimal PoundToStone(decimal pound) { return pound / (decimal)14; }
        private static decimal StoneToUsTon(decimal stone) { return stone * (decimal)0.007; }
        private static decimal UsTonToImperialTon(decimal usTon) { return usTon / (decimal)1.12; }
        // Descending Imperial Conversion Methods:
        private static decimal ImperialTonToUsTon(decimal imperialTon) { return imperialTon * (decimal)1.12; }
        private static decimal UsTonToStone(decimal usTon) { return usTon / (decimal)0.007; }
        private static decimal StoneToPound(decimal stone) { return stone * (decimal)14; }
        private static decimal PoundToOunce(decimal pound) { return pound * (decimal)16; }

        // Main Imperial Conversion Method
        private static decimal ImperialConversions(decimal mass, MassType startingType, MassType endingType)
        {
            if (startingType is < (MassType)6 or > (MassType)10) { throw new ArgumentOutOfRangeException("[startingType] should be a [MassType] Enum between 6 and 10."); }
            if (endingType is < (MassType)6 or > (MassType)10) { throw new ArgumentOutOfRangeException("[endingType] should be a [MassType] Enum between 6 and 10."); }
            if (startingType == endingType) { return mass; }
            decimal convertedMass = mass;

            if (startingType < endingType)
            {
                switch (startingType)
                {
                    case MassType.Ounce:
                        convertedMass = OunceToPound(convertedMass);
                        if (endingType == MassType.Pound) { break; } else { goto case MassType.Pound; }
                    case MassType.Pound:
                        convertedMass = PoundToStone(convertedMass);
                        if (endingType == MassType.Stone) { break; } else { goto case MassType.Stone; }
                    case MassType.Stone:
                        convertedMass = StoneToUsTon(convertedMass);
                        if (endingType == MassType.UsTon) { break; } else { goto case MassType.UsTon; }
                    case MassType.UsTon:
                        convertedMass = UsTonToImperialTon(convertedMass);
                        break;
                }
            }
            else
            {
                switch (startingType)
                {
                    case MassType.ImperialTon:
                        convertedMass = ImperialTonToUsTon(convertedMass);
                        if (endingType == MassType.UsTon) { break; } else { goto case MassType.UsTon; }
                    case MassType.UsTon:
                        convertedMass = UsTonToStone(convertedMass);
                        if (endingType == MassType.Stone) { break; } else { goto case MassType.Stone; }
                    case MassType.Stone:
                        convertedMass = StoneToPound(convertedMass);
                        if (endingType == MassType.Pound) { break; } else { goto case MassType.Pound; }
                    case MassType.Pound:
                        convertedMass = PoundToOunce(convertedMass);
                        break;
                }
            }

            return convertedMass;
        }

        // System To System Conversion Methods
        private static decimal MetricToImperial(decimal mass, MassType startingType, MassType endingType)
        {
            decimal convertedMass = mass;

            convertedMass = MetricConversions(convertedMass, startingType, MassType.Gram);
            convertedMass /= (decimal)6350.293180000001;
            convertedMass = ImperialConversions(convertedMass, MassType.Stone, endingType);

            return convertedMass;
        }
        private static decimal ImperialToMetric(decimal mass, MassType startingType, MassType endingType)
        {
            decimal convertedMass = mass;

            convertedMass = ImperialConversions(convertedMass, startingType, MassType.Stone);
            convertedMass *= (decimal)6350.293180000001;
            convertedMass = MetricConversions(convertedMass, MassType.Gram, endingType);

            return convertedMass;
        }

        // Main Conversion Method
        public static decimal MainConverter(decimal mass, MassType startingType, MassType endingType)
        {
            if (startingType is < (MassType)1 or > (MassType)10) { throw new ArgumentOutOfRangeException("[startingType] should be a [MassType] Enum between 1 and 10."); }
            if (endingType is < (MassType)1 or > (MassType)10) { throw new ArgumentOutOfRangeException("[endingType] should be a [MassType] Enum between 1 and 10."); }
            if (startingType == endingType) { return mass; }

            decimal convertedMass = mass;

            if (startingType <= MassType.MetricTon)
            {
                if (endingType <= MassType.MetricTon)
                {
                    convertedMass = MetricConversions(mass, startingType, endingType);
                }
                else
                {
                    convertedMass = MetricToImperial(mass, startingType, endingType);
                }
            }
            else
            {
                if (endingType <= MassType.MetricTon)
                {
                    convertedMass = ImperialToMetric(mass, startingType, endingType);
                }
                else
                {
                    convertedMass = ImperialConversions(mass, startingType, endingType);
                }
            }

            return convertedMass;
        }
    }
}
