using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the hotel 1!");
            Hotel hotel1 = new Hotel(1);
            hotel1.makeReservation(-4,2);
            hotel1.makeReservation(200, 400);

            Console.WriteLine("\nWelcome to the hotel 2!");
            Hotel hotel2 = new Hotel(3);
            hotel2.makeReservation(0, 5);
            hotel2.makeReservation(7, 13);
            hotel2.makeReservation(3, 9);
            hotel2.makeReservation(5, 7);
            hotel2.makeReservation(6, 6);
            hotel2.makeReservation(0, 4);

            Console.WriteLine("\nWelcome to the hotel 3!");
            Hotel hotel3 = new Hotel(3);
            hotel3.makeReservation(1, 3);
            hotel3.makeReservation(2, 5);
            hotel3.makeReservation(1, 9);
            hotel3.makeReservation(0, 15);

            Console.WriteLine("\nWelcome to the hotel 4!");
            Hotel hotel4 = new Hotel(3);
            hotel4.makeReservation(0, 3);
            hotel4.makeReservation(0, 15);
            hotel4.makeReservation(1, 5);
            hotel4.makeReservation(2, 5);
            hotel4.makeReservation(4, 9);

            Console.WriteLine("\nWelcome to the hotel 5!");
            Hotel hotel5 = new Hotel(2);
            hotel5.makeReservation(1, 3);
            hotel5.makeReservation(0, 4);
            hotel5.makeReservation(2, 3);
            hotel5.makeReservation(5, 5);
            hotel5.makeReservation(4, 10);
            hotel5.makeReservation(10, 10);
            hotel5.makeReservation(6, 7);
            hotel5.makeReservation(8, 10);
            hotel5.makeReservation(8, 9);
        }
    }
}
