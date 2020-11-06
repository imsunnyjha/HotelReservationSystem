using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        HotelSystem hotelSystem = new HotelSystem();
        [TestMethod]
        public void Given_NameAndRegularRates_AddHotelToList()
        {
            string hotelName = "Lakewood";
            int weekdayRatesForRegularCustomer = 110;
            int weekendRatesForRegularCustomer = 90;

            hotelSystem.AddHotel(new Hotel(hotelName, weekdayRatesForRegularCustomer, weekendRatesForRegularCustomer));

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }
        [TestMethod]
        public void Given_ValidDate_Should_Return_CheapestHotel()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = "13Nov2020,14Nov2020".Split(",");

            Hotel cheapestHotel = hotelSystem.GetCheapestHotel(dates);

            Assert.AreEqual("Lakewood", cheapestHotel.name);
        }

        [TestMethod]
        public void Given_NullDates_Should_Return_HotelReservationException()
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = null;

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.NULL_DATES, exception.type);
        }

        [TestMethod]
        [DataRow("112020,12Nov2020")]
        [DataRow("")]
        [DataRow(",12Nov2020")]
        public void Given_InvalidDateFormat_Should_Return_HotelReservationException(string date)
        {
            hotelSystem.AddHotel(new Hotel("Lakewood", 110, 90));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150, 50));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220, 150));
            string[] dates = date.Split(",");

            var exception = Assert.ThrowsException<HotelReservationException>(() => hotelSystem.GetCheapestHotel(dates));

            Assert.AreEqual(HotelReservationException.ExceptionType.INVALID_DATE_FORMAT, exception.type);
        }
    }
}
