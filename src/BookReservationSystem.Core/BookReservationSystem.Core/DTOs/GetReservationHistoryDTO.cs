﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.DTOs
{
    public class GetReservationHistoryDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }
}
