using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReservationSystem.Core.Entities;

namespace BookReservationSystem.Infrastructure.Data.Config
{
    /// <summary>
    /// Book entity configuration for entity framework
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Author).IsRequired();
            builder.HasMany(c => c.ReservationHistory).WithOne(x=>x.Book).HasForeignKey(x=>x.BookId);
            builder.HasOne(c => c.Reservation).WithOne(x => x.Book).HasForeignKey<Reservation>(x=> x.BookId);
        }
    }
}
