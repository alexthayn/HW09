using HW09.Commands;
using HW09.Models;
using HW09.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture]
    public class DataServiceTests
    {  
        public static string TestString = null;
        [Test]
        public void TestMyCommand()
        {
            var command = new MyCommand(() => TestString = "Hello!");
            command.Execute(this);
            Assert.AreEqual("Hello!", TestString);
        }

        [Test]
        public void TestVCFFileReading()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(a => a.GetContactsFromFile(It.IsAny<String>())).Returns(new List<Contact>()
            {
                new Contact(){FirstName="SpongeBob", LastName="SquarePants", Email = "Pineapple", MobilePhone="3333333333"}
            });

            var vm = new MainWindowViewModel(dataServiceMock.Object , new Mock<IMapService>().Object);
            vm.VCFFilePath = "vcfPath";

            vm.LoadFile.Execute(this);
            var expectedContacts = new List<Contact>() { new Contact() { FirstName = "SpongeBob", LastName = "SquarePants", Email = "Pineapple", MobilePhone = "3333333333" } };
            Assert.AreEqual(expectedContacts[0].FullName, vm.Contacts[0].FullName);
        }
           
    }    
}
