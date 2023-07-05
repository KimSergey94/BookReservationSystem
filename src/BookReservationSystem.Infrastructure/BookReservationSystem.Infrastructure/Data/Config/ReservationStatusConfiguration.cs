using BookReservationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Infrastructure.Data.Config
{
    /// <summary>
    /// ReservationStatus entity configuration for entity framework
    /// </summary>
    public class ReservationStatusConfiguration : IEntityTypeConfiguration<ReservationStatus>
    {
        public void Configure(EntityTypeBuilder<ReservationStatus> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.HasOne(c => c.Book).WithMany().HasForeignKey(p => p.BookId).IsRequired();
        }
    }
}
