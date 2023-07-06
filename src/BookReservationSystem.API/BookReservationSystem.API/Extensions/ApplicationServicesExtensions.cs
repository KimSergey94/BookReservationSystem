using BookReservationSystem.Core.Common;
using BookReservationSystem.Core.Interfaces.Repositories;
using BookReservationSystem.Core.Interfaces.Services;
using BookReservationSystem.Core.Services;
using BookReservationSystem.Infrastructure.Data;
using BookReservationSystem.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookReservationSystem.API.Extensions
{
    /// <summary>
    /// Extension class to configure dependency injection for services
    /// </summary>
    public static class ApplicationServicesExtensions
    {
        /// <summary>
        /// Configures dependency injection and adds instances to the service collection that called the extension
        /// </summary>
        /// <param name="services">Service collection that calls this extension</param>
        /// <returns>The service collection that called this extension with added services</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<BookReservationSystemContext, BookReservationSystemContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IBookCRUDService, BookCRUDService>();
            services.AddScoped<IBookReservationService, BookReservationService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
