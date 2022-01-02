using MassConverterConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MassConverterConsoleTests
{
    [TestClass]
    public class MetricConversionTests
    {
        // Variable Library
        decimal testMass = 1;
        readonly decimal expectedMin = (decimal)0.000000000001;
        readonly decimal expectedAscendingConversion = (decimal)0.001;
        readonly decimal expectedDescendingConversion = 1000;
        readonly decimal expectedMax = 1000000000000;

        // Metric Conversion Tests: Ascending Unit Conversion
        [TestMethod]
        public void MetricConversions_ConvertingOneMicrogramToMiligrams_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Microgram, MassType.Miligram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMiligramToGrams_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Miligram, MassType.Gram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneGramToKilograms_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Gram, MassType.Kilogram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneKilogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Kilogram, MassType.MetricTon);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMicrogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Microgram, MassType.MetricTon);

            Assert.AreEqual(expectedMin, actual);
        }

        // Metric Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MetricConversions_ConvertingOneMetricTonToKilograms_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.MetricTon, MassType.Kilogram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneKilogramToGrams_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Kilogram, MassType.Gram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneGramToMiligrams_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Gram, MassType.Miligram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMiligramToMicrograms_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Miligram, MassType.Microgram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMetricTonToMicrograms_Returns1000000000000()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.MetricTon, MassType.Microgram);

            Assert.AreEqual(expectedMax, actual);
        }

        // Metric Conversion Tests: Outliers
        [TestMethod]
        public void MetricConversions_ConvertingOneOfACertainTypeToItself_Returns1()
        {
            decimal actual = MassConverter.MetricConversions(testMass, MassType.Microgram, MassType.Microgram);

            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MetricConversions_WhenStartingTypeIsNotMassTypeEnumBetween1And5_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.MetricConversions(testMass, (MassType)0, (MassType)1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MetricConversions_WhenEndingTypeIsNotMassTypeEnumBetween1And5_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.MetricConversions(testMass, (MassType)5, (MassType)6);
        }
    }

    [TestClass]
    public class ImperialConversionsTests
    {
        // Variable Library
        double delta = 0.00001;

        // Imperial Conversion Tests: Ascending Unit Conversion
        [TestMethod]
        public void ImperialConversions_ConvertingOneOunceToPounds_Returns0Point06250()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Ounce, MassType.Pound);

            Assert.AreEqual(0.06250, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOnePoundToStone_Returns0Point07142()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Pound, MassType.Stone);

            Assert.AreEqual(0.07142, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneStoneToUsTons_Returns0Point00700()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Stone, MassType.UsTon);

            Assert.AreEqual(0.00700, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneUsTonToImperialTons_Returns0Point89285()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.UsTon, MassType.ImperialTon);

            Assert.AreEqual(0.89285, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneOunceToImperialTons_Returns0Point00002()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Ounce, MassType.ImperialTon);

            Assert.AreEqual(0.00002, (double)actual, delta);
        }

        // Imperial Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void ImperialConversions_ConvertingOneImperialTonToUsTons_Returns1Point12()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.ImperialTon, MassType.UsTon);

            Assert.AreEqual(1.12, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneUsTonToStone_Returns142Point85714()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.UsTon, MassType.Stone);

            Assert.AreEqual(142.85714, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneStoneToPounds_Returns14()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Stone, MassType.Pound);

            Assert.AreEqual(14, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOnePoundToOunces_Returns16()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Pound, MassType.Ounce);

            Assert.AreEqual(16, (double)actual, delta);
        }
        [TestMethod]
        public void ImperialConversions_ConvertingOneImperialTonToOunces_Returns35839Point99999()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.ImperialTon, MassType.Ounce);

            Assert.AreEqual(35839.99999, (double)actual, delta);
        }

        // Imperial Conversion Tests: Outliers
        [TestMethod]
        public void ImperialConversions_ConvertingOneOfACertainTypeToItself_Returns1()
        {
            decimal actual = MassConverter.ImperialConversions(1, MassType.Ounce, MassType.Ounce);

            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ImperialConversions_WhenStartingTypeIsNotMassTypeEnumBetween6And10_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.ImperialConversions(1, (MassType)5, (MassType)6);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ImperialConversions_WhenEndingTypeIsNotMassTypeEnumBetween6And10_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.ImperialConversions(1, (MassType)10, (MassType)11);
        }
    }
}
