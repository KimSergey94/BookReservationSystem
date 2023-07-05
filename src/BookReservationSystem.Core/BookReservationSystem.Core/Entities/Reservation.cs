using BookReservationSystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Entities
{
    public class Reservation : EntityBase
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public Reservation(int bookId, int reservationStatusId) 
        { 
            BookId = bookId;
            ReservationStatusId = reservationStatusId;
        }
    }
}
