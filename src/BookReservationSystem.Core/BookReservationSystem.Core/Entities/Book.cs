﻿using BookReservationSystem.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Entities
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public IReadOnlyList<ReservationStatus> Books { get; set; } = new List<ReservationStatus>();

        public Book(string title, string author) 
        {
            Title = title;
            Author = author;
        }
    }
}
