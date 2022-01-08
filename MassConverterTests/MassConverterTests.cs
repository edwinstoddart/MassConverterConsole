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
            decimal actual = MassConverter.MainConverter(testMass, MassType.Micrograms, MassType.Miligrams);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMiligramToGrams_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Miligrams, MassType.Grams);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneGramToKilograms_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Grams, MassType.Kilograms);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneKilogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Kilograms, MassType.MetricTons);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMicrogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Micrograms, MassType.MetricTons);

            Assert.AreEqual(expectedMin, actual);
        }

        // Metric Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToKilograms_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.MetricTons, MassType.Kilograms);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneKilogramToGrams_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Kilograms, MassType.Grams);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneGramToMiligrams_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Grams, MassType.Miligrams);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMiligramToMicrograms_Returns1000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.Miligrams, MassType.Micrograms);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToMicrograms_Returns1000000000000()
        {
            decimal actual = MassConverter.MainConverter(testMass, MassType.MetricTons, MassType.Micrograms);

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
            decimal actual = MassConverter.MainConverter(1, MassType.Ounces, MassType.Pounds);

            Assert.AreEqual(0.06250, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOnePoundToStone_Returns0Point07142()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Pounds, MassType.Stone);

            Assert.AreEqual(0.07142, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneStoneToUsTons_Returns0Point007()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Stone, MassType.UsTons);

            Assert.AreEqual(0.007, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneUsTonToImperialTons_Returns0Point89285()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.UsTons, MassType.ImperialTons);

            Assert.AreEqual(0.89285, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneOunceToImperialTons_Returns0Point00002()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Ounces, MassType.ImperialTons);

            Assert.AreEqual(0.00002, (double)actual, delta);
        }

        // Imperial Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToUsTons_Returns1Point12()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTons, MassType.UsTons);

            Assert.AreEqual(1.12, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneUsTonToStone_Returns142Point85714()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.UsTons, MassType.Stone);

            Assert.AreEqual(142.85714, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneStoneToPounds_Returns14()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Stone, MassType.Pounds);

            Assert.AreEqual(14, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOnePoundToOunces_Returns16()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Pounds, MassType.Ounces);

            Assert.AreEqual(16, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToOunces_Returns35840()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTons, MassType.Ounces);

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
            decimal actual = MassConverter.MainConverter(1, MassType.Micrograms, MassType.ImperialTons);

            Assert.AreEqual(9.84E-13, (double)actual, 1E-15);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneOunceToMetricTons_Returns0Point00002()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Ounces, MassType.MetricTons);

            Assert.AreEqual(0.00002, (double)actual, delta);
        }

        // Metric to/from Imperial Conversion Tests: Descending Unit Conversions
        [TestMethod]
        public void MainConverter_WhenConvertingOneMetricTonToOunces_Returns35273Point96195()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.MetricTons, MassType.Ounces);

            Assert.AreEqual(35273.96194, (double)actual, delta);
        }
        [TestMethod]
        public void MainConverter_WhenConvertingOneImperialTonToMicrograms_Returns1016046908800()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.ImperialTons, MassType.Micrograms);

            Assert.AreEqual(1016046908800, (double)actual, delta);
        }

        // MainConverter Tests: Outliers
        [TestMethod]
        public void MainConverter_WhenConvertingOneOfACertainTypeToItself_Returns1()
        {
            decimal actual = MassConverter.MainConverter(1, MassType.Grams, MassType.Grams);

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
