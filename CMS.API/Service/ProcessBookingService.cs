using CMS.API.Database;
using CMS.API.DBEntities;
using CMS.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class ProcessBookingService : IProcessBookingService
    {
        readonly IApplicationDbContext _applicationDbContext;

        private readonly ILogger _logger;

        public ProcessBookingService(IApplicationDbContext _applicationDbContext, ILoggerFactory loggerFactory)
        {
            this._applicationDbContext = _applicationDbContext;
            this._logger = loggerFactory.CreateLogger("ProcessBookingService");
        }

        public async Task<BookingDetails> EndBooking(int bookingId, string status)
        {
            var currentDateTime = System.DateTime.UtcNow;
            Enum.TryParse(status, out Status currentStatus);
            var bookingDetails = new BookingDetails();
            BookingEntity booking = await _applicationDbContext.BookingEntities.FindAsync(bookingId);
            var cabDetails = await _applicationDbContext.CabEntities.FindAsync(booking.CabId);

            
            var tripDetails = await _applicationDbContext.TripEntities.Where(x => x.BookingId.Equals(bookingId) && x.CabId.Equals(cabDetails.Id)).FirstAsync();
            cabDetails.Status = (int)CabStatus.IDLE;
            cabDetails.LastTripEndedAt = currentDateTime;
            booking.Status = (int)currentStatus;
            tripDetails.EndedAt = currentDateTime;
            await _applicationDbContext.SaveChanges();
            bookingDetails.Status = currentStatus;
            bookingDetails.BookingId = bookingId;
            return bookingDetails;
        }

        public async Task<BookingDetails> ProcessBooking(int bookingId)
        {
            var bookingDetails = new BookingDetails();
            BookingEntity booking = await _applicationDbContext.BookingEntities.FindAsync(bookingId);
            var location = booking.CityId;
            var category = booking.Category;
            var mostIdleCabs = await _applicationDbContext.CabEntities
                .Where(x => x.CityId.Equals(location)
                && x.Category.Equals(category)
                && x.Status.Equals((int)CabStatus.IDLE))
                .OrderBy(x => x.LastTripEndedAt).ToListAsync();

            if (mostIdleCabs.Any())
            {
                var assignedCab = mostIdleCabs.FirstOrDefault();
                booking.CabId = assignedCab.Id;
                booking.Status = (int)Status.BOOKED;
                assignedCab.Status = (int)CabStatus.ON_TRIP;

                var tripEntity = new TripEntity()
                {
                    BookingId = bookingId,
                    CabId = assignedCab.Id,
                    StartedAt = System.DateTime.UtcNow,
                };

                await _applicationDbContext.TripEntities.AddAsync(tripEntity);

                await _applicationDbContext.SaveChanges();
                bookingDetails.Status = Status.BOOKED;
                bookingDetails.CabDetails = new Cab() { Name = assignedCab.Name, Number = assignedCab.Number };
                bookingDetails.BookingId = bookingId;
            }
           
            return bookingDetails;
        }
    }
}
