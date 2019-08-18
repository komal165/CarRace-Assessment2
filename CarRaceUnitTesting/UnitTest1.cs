using System;
using CarRace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRaceUnitTest
{
    [TestClass]
    public class CarRaceUnitTest
    {
        [TestMethod]
        public void PayOutTest()
        {
            // Arrange
            var bet = new Bet();

            // Act
            var actual = bet.PayOut(0);

            // Assert
            Assert.AreEqual(0, actual);

        }

        [TestMethod]
        public void Error_Message_Due_To_Not_Enough_Cash()
        {
            // Arrange
            var guy = new Bettor();

            // Act
            var actual = guy.PlaceBid(100, 0);

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
