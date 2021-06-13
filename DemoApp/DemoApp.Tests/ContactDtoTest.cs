using DemoApp.WebApi.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoApp.Tests
{
    [TestClass]
    public class ContactDtoTest
    {
        [DataTestMethod]
        [DataRow("Aa", "Bb", "Aa Bb")]
        [DataRow("Hello", "World2", "Hello World")]
        [DataRow("123", "456", "123 456")]
        public void GetFullNameIsCorrect(string firstName, string secondName, string expected)
        {
            ContactDto contact = new() {FirstName = firstName, SecondName = secondName};
            
            Assert.AreEqual(expected, contact.FullName);
        }
    }
}
