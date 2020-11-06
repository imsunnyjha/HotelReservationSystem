﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class UserInterface
    {
        public static void UserInput(HotelSystem hotelSystem)
        {
            try
            {
                Console.WriteLine("...................................");
                Console.WriteLine("Enter dates in dd-mm--yyyy format");
                string[] dates = Console.ReadLine().Split(",");

                Console.WriteLine("...................................");
                Console.WriteLine("1.Get Cheapest Hotel\n2.Get Cheapest Best Rated Hotel\n3.Get Best Rated Hotel");

                Console.WriteLine("...................................");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("...................................");

                switch (choice)
                {
                    case 1:
                        List<Hotel> cheapestHotels = hotelSystem.GetCheapestHotel(dates);
                        hotelSystem.DisplayHotels(cheapestHotels);
                        break;
                    case 2:
                        List<Hotel> cheapestBestRatedHotels = hotelSystem.GetCheapestBestRatedHotel(dates);
                        hotelSystem.DisplayHotels(cheapestBestRatedHotels);
                        break;
                    case 3:
                        List<Hotel> bestRatedHotels = hotelSystem.GetBestRatedHotel(dates);
                        hotelSystem.DisplayHotels(bestRatedHotels);
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
            }
            catch (HotelReservationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
