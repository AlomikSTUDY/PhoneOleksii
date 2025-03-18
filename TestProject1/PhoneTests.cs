using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;

namespace TestProjectPhone
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializePhoneCorrectly()
        {
            var phone = new Phone("Molenda", "123456789");
            Assert.AreEqual("Molenda", phone.Owner);
            Assert.AreEqual("123456789", phone.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShouldThrowExceptionForEmptyOwner()
        {
            new Phone("", "123456789");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_ShouldThrowExceptionForInvalidPhoneNumber()
        {
            new Phone("Molenda", "123");
        }

        [TestMethod]
        public void AddContact_ShouldIncreaseCount()
        {
            var phone = new Phone("Molenda", "123456789");
            phone.AddContact("John", "987654321");
            Assert.AreEqual(1, phone.Count);
        }

        [TestMethod]
        public void AddContact_ShouldReturnTrueForNewContact()
        {
            var phone = new Phone("Molenda", "123456789");
            bool result = phone.AddContact("Alice", "987654321");
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddContact_ShouldThrowExceptionWhenPhonebookIsFull()
        {
            var phone = new Phone("Molenda", "123456789");
            for (int i = 0; i < phone.PhoneBookCapacity; i++)
            {
                phone.AddContact($"Contact{i}", "111111111");
            }
            phone.AddContact("Overflow", "222222222");
        }

        [TestMethod]
        public void Call_ShouldReturnCorrectMessage()
        {
            var phone = new Phone("Molenda", "123456789");
            phone.AddContact("John", "987654321");
            var result = phone.Call("John");
            Assert.AreEqual("Calling 987654321 (John) ...", result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Call_ShouldThrowExceptionForNonExistentContact()
        {
            var phone = new Phone("Molenda", "123456789");
            phone.Call("Nonexistent");
        }
    }
}
