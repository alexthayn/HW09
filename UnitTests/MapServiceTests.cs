using HW09.Commands;
using HW09.Models;
using HW09.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    class MapServiceTests
    {
        [Test]
        [TestCase("84003", "84627", "Directions from 84003 to 84627")]
        [TestCase(null, "84003", "Please enter a valid origin/destination")]
        public void TestOpenFileCommand(string start, string end, string expectedOutput)
        {
            var mapServiceMock = new Mock<IMapService>();
            mapServiceMock.Setup(a => a.GetDirections(start, end)).Returns(expectedOutput);

            var vm = new MainWindowViewModel(new Mock<IDataService>().Object, mapServiceMock.Object);

            vm.StartLocation = start;
            vm.Destination = end;

            vm.GetDirections.Execute(this);
            Assert.AreEqual(expectedOutput, vm.TextDirections);
        }
    }
}
