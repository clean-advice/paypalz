using NUnit.Framework;

namespace Devlin.PayPalz.Domain.UnitTests.ObjectMother
{
    internal class CalculationFactoryTestData
    {
        internal static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData("7441");
                yield return new TestCaseData("1000");
            }
        }
    }
}
