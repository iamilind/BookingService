using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CabBookingService : IBookingService
    {
        public Task<BookCabResponse> GetBookingDetails(int bookingId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CancelBooking(int bookingId)
        {
            throw new System.NotImplementedException();
        }

        public Task<BookCabResponse> CreateBooking(BookCab bookCab)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateBooking(int bookingId, BookCab bookingDetails)
        {
            throw new System.NotImplementedException();
        }
    }
}
