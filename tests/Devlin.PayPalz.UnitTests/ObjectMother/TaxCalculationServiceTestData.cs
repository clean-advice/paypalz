using NUnit.Framework;

namespace Devlin.PayPalz.Domain.UnitTests.ObjectMother
{
    internal class TaxCalculationServiceTestData
    {
        internal static IEnumerable<TestCaseData> FlatValueTestCases
        {
            get
            {
                yield return new TestCaseData("A100", 0m).Returns(0m);
                yield return new TestCaseData("A100", 10000m).Returns(500m);
                yield return new TestCaseData("A100", 100000m).Returns(5000m);
                yield return new TestCaseData("A100", 300000m).Returns(10000m);
                yield return new TestCaseData("A100", 850000m).Returns(10000m);
                yield return new TestCaseData("A100", 200000m).Returns(10000m);
                yield return new TestCaseData("A100", 199999m).Returns(9999.95m);
            }
        }

        internal static IEnumerable<TestCaseData> FlatRateTestCases
        {
            get
            {
                yield return new TestCaseData("7000", 0m).Returns(0m);
                yield return new TestCaseData("7000", 100000m).Returns(17500m);
                yield return new TestCaseData("7000", 500000m).Returns(87500m);
                yield return new TestCaseData("7000", 1000850m).Returns(175148.75m);
            }
        }

        internal static IEnumerable<TestCaseData> ProgressiveTaxTestCases
        {
            get
            {
                yield return new TestCaseData("7441", 0m).Returns(0m);
                yield return new TestCaseData("1000", 8300m).Returns(830m);
                yield return new TestCaseData("1000", 8349m).Returns(834.90m);
                yield return new TestCaseData("7441", 8350m).Returns(835m);
                yield return new TestCaseData("7441", 8350.10m).Returns(835.015m); // Valid for BHD etc., not for $ and such
                yield return new TestCaseData("1000", 8351m).Returns(835.15m);
                yield return new TestCaseData("1000", 30000m).Returns(4082.50m);
                yield return new TestCaseData("1000", 33949.99m).Returns(4674.9985m); // Probably need to round to 2 decimals
                yield return new TestCaseData("7441", 80000m).Returns(16187.50m);
                yield return new TestCaseData("7441", 82250m).Returns(16750m);
                yield return new TestCaseData("7441", 83000m).Returns(16960m);
                yield return new TestCaseData("1000", 86000m).Returns(17800m);
                yield return new TestCaseData("1000", 171549m).Returns(41753.72m);
                yield return new TestCaseData("1000", 171555m).Returns(41755.40m);
                yield return new TestCaseData("1000", 372950m).Returns(98146m);
                yield return new TestCaseData("1000", 555000m).Returns(149120m);
            }
        }
    }
}
