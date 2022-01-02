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
        public void MainConverter_WhenConvertingOneMicrogramToMiligrams_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Microgram, MassType.Miligram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMiligramToGrams_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Miligram, MassType.Gram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneGramToKilograms_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Gram, MassType.Kilogram);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneKilogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Kilogram, MassType.MetricTon);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMicrogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Microgram, MassType.MetricTon);

            Assert.AreEqual(expectedMin, actual);
        }

        // Metric Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToKilograms_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.MetricTon, MassType.Kilogram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneKilogramToGrams_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Kilogram, MassType.Gram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneGramToMiligrams_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Gram, MassType.Miligram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMiligramToMicrograms_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Miligram, MassType.Microgram);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToMicrograms_Returns1000000000000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.MetricTon, MassType.Microgram);

            Assert.AreEqual(expectedMax, actual);
        }
    }

    [TestClass]
    public class ImperialConversionsTests
    {
        // Variable Library
        double delta = 0.00001;

        // Imperial Conversion Tests: Ascending Unit Conversion
        [TestMethod]
        public void MainConverter_WhenConvertingOneOunceToPounds_Returns0Point06250()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Ounce, MassType.Pound);

            Assert.AreEqual(0.06250, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOnePoundToStone_Returns0Point07142()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Pound, MassType.Stone);

            Assert.AreEqual(0.07142, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneStoneToUsTons_Returns0Point007()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Stone, MassType.UsTon);

            Assert.AreEqual(0.007, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneUsTonToImperialTons_Returns0Point89285()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.UsTon, MassType.ImperialTon);

            Assert.AreEqual(0.89285, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneOunceToImperialTons_Returns0Point00002()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Ounce, MassType.ImperialTon);

            Assert.AreEqual(0.00002, (double)actual, delta);
        }

        // Imperial Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToUsTons_Returns1Point12()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTon, MassType.UsTon);

            Assert.AreEqual(1.12, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneUsTonToStone_Returns142Point85714()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.UsTon, MassType.Stone);

            Assert.AreEqual(142.85714, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneStoneToPounds_Returns14()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Stone, MassType.Pound);

            Assert.AreEqual(14, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOnePoundToOunces_Returns16()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Pound, MassType.Ounce);

            Assert.AreEqual(16, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToOunces_Returns35840()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTon, MassType.Ounce);

            Assert.AreEqual(35840, (double)actual, delta);
        }
    }

    [TestClass]
    public class SystemToSystemConversionTests
    {
        // Variable Library
        double delta = 0.00001;

        // Metric to/from Imperial Conversion Tests: Ascending Unit Conversions
        [TestMethod]
        public void MainConverter_WhenConvertingOneMicrogramToImperialTons_Returns9Point84EMinus13()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Microgram, MassType.ImperialTon);

            Assert.AreEqual(9.84E-13, (double)actual, 1E-15);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneOunceToMetricTons_Returns0Point00002()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Ounce, MassType.MetricTon);

            Assert.AreEqual(0.00002, (double)actual, delta);
        }

        // Metric to/from Imperial Conversion Tests: Descending Unit Conversions
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToOunces_Returns35273Point96195()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.MetricTon, MassType.Ounce);

            Assert.AreEqual(35273.96194, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToMicrograms_Returns1016046908800()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTon, MassType.Microgram);

            Assert.AreEqual(1016046908800, (double)actual, delta);
        }

        // MainConverter Tests: Outliers
        [TestMethod]
        public void MainConverter_WhenConvertingOneOfACertainTypeToItself_Returns1()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Gram, MassType.Gram);

            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MainConverter_WhenStartingTypeIsNotMassTypeEnumBetween1And10_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.MainConverter(1, (MassType)0, (MassType)1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MainConverter_WhenEndingTypeIsNotMassTypeEnumBetween6And10_ReturnArgumentOutOfBoundsException()
        {
            MassConverter.MainConverter(1, (MassType)10, (MassType)11);
        }
    }
}
