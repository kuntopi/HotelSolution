using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace HotelReservation
{
    public class Hotel
    {
        public int size { get; set; }
        public bool[,] bookedDates { get; set; }
        public List<List<Tuple<int,int>>> bookings;
        /// <summary>
        /// Initializes a Hotel with specified number of rooms
        /// </summary>
        /// <param name="size">Number of rooms</param>
        public Hotel (int size)
        {
            this.size = size;
            bookedDates = new bool[size,365];
            bookings = new List<List<Tuple<int, int>>>();
            for (int i =0; i < size; i++)
            {
                bookings.Add(new List<Tuple<int, int>>());
            }
        }
        /// <summary>
        /// Performs the entire room booking process for requested dates.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>True if room was successfully booked</returns>
        public bool makeReservation(int startDate,int endDate)
        {
            if( startDate > endDate || startDate < 0 || endDate > 365)
            {
                Console.WriteLine("Booking for days " + startDate + " - " + endDate + " unsuccessful");
                return false;
            }
            int freeRoom = findRoom(startDate, endDate);
            if (freeRoom == -1)
            {
                freeRoom = tryMixing(startDate, endDate);
                if (freeRoom == -1)
                {
                    Console.WriteLine("Booking for days " + startDate + " - " + endDate + " unsuccessful");
                    return false;
                }
            }
            bookRoomForDates(freeRoom, startDate, endDate);
            Console.WriteLine("Booking for days " + startDate + " - " + endDate + " successful");
            return true;
        }
        /// <summary>
        /// Searches for a free room for specified dates.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Number of the free room, -1 if no room is free</returns>
        private int findRoom(int startDate, int endDate)
        {
            for (int i = 0; i < this.size; i++)
            {
                bool free = checkDatesForRoom(i, startDate, endDate);
                if (free)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Checks if the requested room is available for requested dates
        /// </summary>
        /// <param name="room"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>True if room is available</returns>
        private bool checkDatesForRoom(int room, int startDate,int endDate)
        {
            for (int i = startDate; i <= endDate; i++)
            {
                if (bookedDates[room,i])
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Makes a booking for the requested room for requested dates.
        /// </summary>
        /// <param name="room"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void bookRoomForDates(int room, int startDate, int endDate)
        {
            for (int i = startDate; i <= endDate; i++)
            {
                bookedDates[room, i] = true;
            }
            bookings[room].Add(new Tuple<int, int>(startDate, endDate));
        }
        /// <summary>
        /// Attempts to move bookings between rooms so that one room gets freed for requested dates.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Number of the room that is available. -1 if no room is found</returns>
        private int tryMixing(int startDate, int endDate)
        {
            int curRoom = -1;
            foreach (List<Tuple<int,int>> roomBookings in bookings)
            {
                bool flag = true;
                curRoom++;
                foreach (Tuple<int,int> booking in roomBookings)
                {
                    if ((booking.Item1 <= endDate && booking.Item1 >= startDate) || (booking.Item2 <= endDate && booking.Item2 >= startDate) || (booking.Item1 < startDate && booking.Item2 > endDate))
                    {
                        int newRoom = findRoom(booking.Item1, booking.Item2);
                        if (newRoom == -1)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    List<Tuple<int, int>> bookingsToCancel = new List<Tuple<int, int>>();
                    foreach (Tuple<int, int> booking in roomBookings)
                    {
                        if ((booking.Item1 <= endDate && booking.Item1 >= startDate) || (booking.Item2 <= endDate && booking.Item2 >= startDate) || (booking.Item1 < startDate && booking.Item2 > endDate))
                        {
                            int newRoom = findRoom(booking.Item1, booking.Item2);
                            unbookDates(curRoom, booking.Item1, booking.Item2);
                            bookingsToCancel.Add(booking);
                            bookRoomForDates(newRoom, booking.Item1, booking.Item2);
                        }
                    }
                    foreach (Tuple<int, int> booking in bookingsToCancel)
                    {
                        bookings[curRoom].Remove(booking);
                    }
                    return curRoom;
                }
            }
            return -1;
        }
        private void unbookDates(int room, int startDate, int endDate)
        {
            for (int i = startDate; i <= endDate; i++)
            {
                bookedDates[room, i] = false;
            }
        }
    }
}