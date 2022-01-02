using MassConverterConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MassConverterConsoleTests
{
    [TestClass]
    public class MetricConversionTests
    {
        // Variable Library
        readonly decimal expectedMin =                  (decimal)0.000000000001;
        readonly decimal expectedAscendingConversion =  (decimal)0.001;
        readonly decimal expectedDescendingConversion = 1000;
        readonly decimal expectedMax =                  1000000000000;

        // Metric Conversion Tests: Ascending Unit Conversion
        [TestMethod]
        public void MetricConversions_ConvertingOneMicrogramToMiligrams_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(1, 1, 2);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMiligramToGrams_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(1, 2, 3);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneGramToKilograms_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(1, 3, 4);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneKilogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(1, 4, 5);

            Assert.AreEqual(expectedAscendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMicrogramToMetricTons_Returns0Point001()
        {
            decimal actual = MassConverter.MetricConversions(1, 1, 5);

            Assert.AreEqual(expectedMin, actual);
        }

        // Metric Conversion Tests: Descending Unit Conversion
        [TestMethod]
        public void MetricConversions_ConvertingOneMetricTonToKilograms_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(1, 5, 4);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneKilogramToGrams_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(1, 4, 3);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneGramToMiligrams_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(1, 3, 2);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMiligramToMicrograms_Returns1000()
        {
            decimal actual = MassConverter.MetricConversions(1, 2, 1);

            Assert.AreEqual(expectedDescendingConversion, actual);
        }
        [TestMethod]
        public void MetricConversions_ConvertingOneMetricTonToMicrograms_Returns1000000000000()
        {
            decimal actual = MassConverter.MetricConversions(1, 5, 1);

            Assert.AreEqual(expectedMax, actual);
        }

        // Metric Conversion Tests: Outliers
        [TestMethod]
        public void MetricConversions_ConvertingOneOfACertainTypeToItself_Returns1()
        {
            decimal actual = MassConverter.MetricConversions(1, 1, 1);

            Assert.AreEqual(1, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MetricConversions_WhenStartingTypeIsNotBetween1And5_ReturnOutOfBoundsException()
        {
            MassConverter.MetricConversions(1, 0, 1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MetricConversions_WhenEndingTypeIsNotBetween1And5_ReturnOutOfBoundsException()
        {
            MassConverter.MetricConversions(1, 5, 6);
        }
    }
}
