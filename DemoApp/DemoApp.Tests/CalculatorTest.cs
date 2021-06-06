using DemoApp.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [DataTestMethod]
        [DataRow(1, 42, 43)]
        [DataRow(0, 0, 0)]
        [DataRow(-67, -3, -70)]
        [DataRow(-23, 20, -3)]
        public void SumIsCorrect(int a, int b, int expectedResult)
        {
            Calculator calculator = new();

            int result = calculator.Sum(a, b);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
