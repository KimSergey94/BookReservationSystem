using BookReservationSystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Entities
{
    public class ReservationStatus : EntityBase
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public Reservation Reservation { get; set; }

        public ReservationStatus(int bookId, string status, string comment)
        {
            BookId = bookId;
            Status = status;
            Comment = comment;
        }
    }
}
