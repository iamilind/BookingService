using CMS.API.Database;
using CMS.API.DBEntities;
using CMS.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class BookingService : IBookingService
    {
        readonly IApplicationDbContext _applicationDbContext;

        private readonly ILogger _logger;

        public BookingService(IApplicationDbContext _applicationDbContext, ILoggerFactory loggerFactory)
        {
            this._applicationDbContext = _applicationDbContext;
            this._logger = loggerFactory.CreateLogger("BookingService");
        }
        public Task<BookCabResponse> GetBookingDetails(int bookingId)
        {
            throw new NotImplementedException();
            
        }

        public Task<bool> CancelBooking(int bookingId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BookCabResponse> CreateBooking(BookCab bookCab)
        {
            try
            {  
                var bookingEntity = new BookingEntity()
                {
                    Category = bookCab.Category,
                    CityId = bookCab.CityId,
                    CreatedAt = DateTime.UtcNow,
                    UserId = bookCab.CustomerId,
                    Status = (int)Status.INITIATED,
                };

                var entity = await _applicationDbContext.BookingEntities.AddAsync(bookingEntity);
                await _applicationDbContext.SaveChanges();

                return new BookCabResponse() { BookingId = entity.Entity.Id, BookingStatus = (Status)entity.Entity.Status};
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception($"Exception:{ex.Message}");
            }

        }

        public Task<bool> UpdateBooking(int bookingId, BookCab bookingDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}
