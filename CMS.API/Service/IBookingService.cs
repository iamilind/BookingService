using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public interface IBookingService
    {
        Task<BookCabResponse> CreateBooking(BookCab bookCab);

        Task<bool> CancelBooking(int bookingId);

        Task<bool> UpdateBooking(int bookingId, BookCab bookingDetails);

        Task<BookCabResponse> GetBookingDetails(int bookingId);

    }
}
