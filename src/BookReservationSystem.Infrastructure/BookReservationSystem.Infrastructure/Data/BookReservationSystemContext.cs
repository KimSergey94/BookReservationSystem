using BookReservationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Infrastructure.Data
{
    /// <summary>
    /// Class db context of the application as a bridge between entities and database
    /// </summary>
    public class BookReservationSystemContext : DbContext
    {
        public BookReservationSystemContext(DbContextOptions<BookReservationSystemContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
