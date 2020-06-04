using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation.Tests
{
    [TestClass()]
    public class HotelTests
    {
        [TestMethod()]
        public void makeReservationTest()
        {
            Hotel hotel1 = new Hotel(1);
            Assert.IsFalse(hotel1.makeReservation(-4, 2));
            Assert.IsFalse(hotel1.makeReservation(200, 400));

            Hotel hotel2 = new Hotel(3);
            Assert.IsTrue(hotel2.makeReservation(0, 5));
            Assert.IsTrue(hotel2.makeReservation(7, 13));
            Assert.IsTrue(hotel2.makeReservation(3, 9));
            Assert.IsTrue(hotel2.makeReservation(5, 7));
            Assert.IsTrue(hotel2.makeReservation(6, 6));
            Assert.IsTrue(hotel2.makeReservation(0, 4));

            Hotel hotel3 = new Hotel(3);
            Assert.IsTrue(hotel3.makeReservation(1, 3));
            Assert.IsTrue(hotel3.makeReservation(2, 5));
            Assert.IsTrue(hotel3.makeReservation(1, 9));
            Assert.IsFalse(hotel3.makeReservation(0, 15));

            Hotel hotel4 = new Hotel(3);
            Assert.IsTrue(hotel4.makeReservation(0, 3));
            Assert.IsTrue(hotel4.makeReservation(0, 15));
            Assert.IsTrue(hotel4.makeReservation(1, 5));
            Assert.IsFalse(hotel4.makeReservation(2, 5));
            Assert.IsTrue(hotel4.makeReservation(4, 9));

            Hotel hotel5 = new Hotel(2);
            Assert.IsTrue(hotel5.makeReservation(1, 3));
            Assert.IsTrue(hotel5.makeReservation(0, 4));
            Assert.IsFalse(hotel5.makeReservation(2, 3));
            Assert.IsTrue(hotel5.makeReservation(5, 5));
            Assert.IsTrue(hotel5.makeReservation(4, 10));
            Assert.IsTrue(hotel5.makeReservation(10, 10));
            Assert.IsTrue(hotel5.makeReservation(6, 7));
            Assert.IsFalse(hotel5.makeReservation(8, 10));
            Assert.IsTrue(hotel5.makeReservation(8, 9));
        }
    }
}