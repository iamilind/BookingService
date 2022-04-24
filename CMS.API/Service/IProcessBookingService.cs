using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public interface IProcessBookingService
    {
        Task<BookingDetails> ProcessBooking(int bookingId);

        Task<BookingDetails> EndBooking(int bookingId, string status);
    }
}
