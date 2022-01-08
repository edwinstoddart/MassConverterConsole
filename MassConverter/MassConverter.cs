using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassConverterConsole
{
    public enum MassType
    {
        Micrograms = 1,
        Miligrams = 2,
        Grams = 3,
        Kilograms = 4,
        MetricTons = 5,
        Ounces = 6,
        Pounds = 7,
        Stone = 8,
        UsTons = 9,
        ImperialTons = 10
    }

    public class MassConverter
    {
        static int decimalPlaces = 28;
        // ================================================== Metric Methods ==================================================
        // Ascending Metric Conversion Methods:
        private static decimal MetricUpwardConversion(decimal mass) { return Math.Round(mass / 1000, decimalPlaces); }
        // Descending Metric Conversion Methods:
        private static decimal MetricDownwardConversion(decimal mass) { return Math.Round(mass * 1000, decimalPlaces); }

        // Main Metric Conversion Method
        private static decimal MetricConversions(decimal mass, MassType startingType, MassType endingType)
        {
            if (startingType is < (MassType)1 or > (MassType)5) { throw new ArgumentOutOfRangeException("[startingType] should be a [MassType] Enum between 1 and 5."); }
            if (endingType is < (MassType)1 or > (MassType)5) { throw new ArgumentOutOfRangeException("[endingType] should be a [MassType] Enum between 1 and 5."); }
            if (startingType == endingType) { return mass; }
            decimal convertedMass = mass;

            if (startingType < endingType)
            {
                for (int i = 0; i < endingType - startingType; i++)
                {
                    convertedMass = MetricUpwardConversion(convertedMass);
                }
            }
            else
            {
                for (int i = 0; i < startingType - endingType; i++)
                {
                    convertedMass = MetricDownwardConversion(convertedMass);
                }
            }

            return convertedMass;
        }

        // ================================================== Imperial Methods ==================================================
        // Ascending Imperial Conversion Methods:
        private static decimal OunceToPound(decimal ounce) { return Math.Round(ounce / 16, decimalPlaces); }
        private static decimal PoundToStone(decimal pound) { return Math.Round(pound / 14, decimalPlaces); }
        private static decimal StoneToUsTon(decimal stone) { return Math.Round(stone * (decimal)0.007, decimalPlaces); }
        private static decimal UsTonToImperialTon(decimal usTon) { return Math.Round(usTon / (decimal)1.12, decimalPlaces); }
        // Descending Imperial Conversion Methods:
        private static decimal ImperialTonToUsTon(decimal imperialTon) { return Math.Round(imperialTon * (decimal)1.12, decimalPlaces); }
        private static decimal UsTonToStone(decimal usTon) { return Math.Round(usTon / (decimal)0.007, decimalPlaces); }
        private static decimal StoneToPound(decimal stone) { return Math.Round(stone * 14, decimalPlaces); }
        private static decimal PoundToOunce(decimal pound) { return Math.Round(pound * 16, decimalPlaces); }

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
                    case MassType.Ounces:
                        convertedMass = OunceToPound(convertedMass);
                        if (endingType == MassType.Pounds) { break; } else { goto case MassType.Pounds; }
                    case MassType.Pounds:
                        convertedMass = PoundToStone(convertedMass);
                        if (endingType == MassType.Stone) { break; } else { goto case MassType.Stone; }
                    case MassType.Stone:
                        convertedMass = StoneToUsTon(convertedMass);
                        if (endingType == MassType.UsTons) { break; } else { goto case MassType.UsTons; }
                    case MassType.UsTons:
                        convertedMass = UsTonToImperialTon(convertedMass);
                        break;
                }
            }
            else
            {
                switch (startingType)
                {
                    case MassType.ImperialTons:
                        convertedMass = ImperialTonToUsTon(convertedMass);
                        if (endingType == MassType.UsTons) { break; } else { goto case MassType.UsTons; }
                    case MassType.UsTons:
                        convertedMass = UsTonToStone(convertedMass);
                        if (endingType == MassType.Stone) { break; } else { goto case MassType.Stone; }
                    case MassType.Stone:
                        convertedMass = StoneToPound(convertedMass);
                        if (endingType == MassType.Pounds) { break; } else { goto case MassType.Pounds; }
                    case MassType.Pounds:
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

            convertedMass = MetricConversions(convertedMass, startingType, MassType.Grams);
            convertedMass /= (decimal)6350.293180000001;
            convertedMass = ImperialConversions(convertedMass, MassType.Stone, endingType);

            return convertedMass;
        }
        private static decimal ImperialToMetric(decimal mass, MassType startingType, MassType endingType)
        {
            decimal convertedMass = mass;

            convertedMass = ImperialConversions(convertedMass, startingType, MassType.Stone);
            convertedMass *= (decimal)6350.293180000001;
            convertedMass = MetricConversions(convertedMass, MassType.Grams, endingType);

            return convertedMass;
        }

        // Main Conversion Method
        public static decimal MainConverter(decimal mass, MassType startingType, MassType endingType)
        {
            if (startingType is < (MassType)1 or > (MassType)10) { throw new ArgumentOutOfRangeException("[startingType] should be a [MassType] Enum between 1 and 10."); }
            if (endingType is < (MassType)1 or > (MassType)10) { throw new ArgumentOutOfRangeException("[endingType] should be a [MassType] Enum between 1 and 10."); }
            if (startingType == endingType) { return mass; }

            decimal convertedMass = mass;

            if (startingType <= MassType.MetricTons)
            {
                if (endingType <= MassType.MetricTons)
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
                if (endingType <= MassType.MetricTons)
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
