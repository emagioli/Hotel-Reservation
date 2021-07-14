using System;
using Hotel.Entities.Exceptions;

namespace Hotel.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {
        }
        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("The reservation dates must be future dates.");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("The check-out date must be further than the check-in date");
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int) duration.TotalDays; //totaldays transforma em double, o casting converte para int
            
        }
        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("The reservation dates must be future dates.");
            }
            if (checkOut <= checkIn)
            {
                throw new DomainException("The check-out date must be further than the check-in date");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return $"Room {RoomNumber}, " +
                $"check-in: {CheckIn.ToString("dd/MM/yyyy")}, " +
                $"check-out: {CheckOut.ToString("dd/MM/yyyy")}, " +
                $"{Duration()} nights";
        }
    }
}
