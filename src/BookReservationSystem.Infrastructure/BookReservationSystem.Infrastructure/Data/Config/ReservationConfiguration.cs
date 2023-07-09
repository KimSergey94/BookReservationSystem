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
    /// Reservation entity configuration for entity framework
    /// </summary>
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ReservationStatusId).IsRequired();
        }
    }
}
