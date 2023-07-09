﻿// <auto-generated />
using BookReservationSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookReservationSystem.Infrastructure.Migrations
{
    [DbContext(typeof(BookReservationSystemContext))]
    partial class BookReservationSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookReservationSystem.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("ReservationStatusId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("ReservationStatuses");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.Reservation", b =>
                {
                    b.HasOne("BookReservationSystem.Core.Entities.Book", "Book")
                        .WithOne("Reservation")
                        .HasForeignKey("BookReservationSystem.Core.Entities.Reservation", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookReservationSystem.Core.Entities.ReservationStatus", "ReservationStatus")
                        .WithOne("Reservation")
                        .HasForeignKey("BookReservationSystem.Core.Entities.Reservation", "ReservationStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("ReservationStatus");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.ReservationStatus", b =>
                {
                    b.HasOne("BookReservationSystem.Core.Entities.Book", "Book")
                        .WithMany("ReservationHistory")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.Book", b =>
                {
                    b.Navigation("Reservation");

                    b.Navigation("ReservationHistory");
                });

            modelBuilder.Entity("BookReservationSystem.Core.Entities.ReservationStatus", b =>
                {
                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
