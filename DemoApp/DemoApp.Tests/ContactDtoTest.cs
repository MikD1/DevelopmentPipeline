using DemoApp.WebApi.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests
{
    [TestClass]
    public class ContactDtoTest
    {
        [DataTestMethod]
        [DataRow("Aa", "Bb", "Aa Bb")]
        [DataRow("Hello", "World", "Hello World")]
        public void GetFullNameIsCorrect(string firstName, string secondName, string expected)
        {
            ContactDto contact = new() {FirstName = firstName, SecondName = secondName};
            
            Assert.AreEqual(expected, contact.FullName);
        }
    }
}
