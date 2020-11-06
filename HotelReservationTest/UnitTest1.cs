using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystem;

namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_NameAndRegularRates_AddHotelToList()
        {
            string hotelName = "Lakewood";
            int ratesForRegularCustomer = 110;

            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel(hotelName, ratesForRegularCustomer));

            Assert.AreEqual(1, hotelSystem.hotelList.Count);
        }
    }
}
