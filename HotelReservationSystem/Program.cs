using System;

namespace HotelReservationSystem
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hotel reservation system!");
            HotelSystem hotelSystem = new HotelSystem();
            hotelSystem.AddHotel(new Hotel("Lakewood", 110,90,3));
            hotelSystem.AddHotel(new Hotel("Bridgewood", 150,50,4));
            hotelSystem.AddHotel(new Hotel("Ridgewood", 220,150,5));

            Console.WriteLine("Loading Hotels.........");

            UserInterface.UserInput(hotelSystem);
        }
    }
}