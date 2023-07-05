using AutoMapper;
using BookReservationSystem.Core.DTOs;
using BookReservationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservationSystem.Core.Mappers
{
    public static class MapperUtil
    {
        public static IEnumerable<GetAvailableBooksDTO> MapToGetAvailableBooksDTOList(IEnumerable<Book> books)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, GetAvailableBooksDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<GetAvailableBooksDTO>>(books);
        }

        public static IEnumerable<GetReservedBooksDTO> MapToGetReservedBooksDTOList(IEnumerable<Book> books)
        {
            var mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<Book, GetReservedBooksDTO>()
               .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Reservation.ReservationStatus.Status))
               .ForMember(dest => dest.Comment, act => act.MapFrom(src => src.Reservation.ReservationStatus.Comment));
            }).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<GetReservedBooksDTO>>(books);
        }

        public static IEnumerable<GetReservationHistoryDTO> MapToGetReservationHistoryDTOList(IEnumerable<ReservationStatus> reservationStatuses)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ReservationStatus, GetReservationHistoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ReservationStatus>, List<GetReservationHistoryDTO>>(reservationStatuses);
        }
    }
}
