using CMS.API.Models;
using CMS.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int bookingId)
        {
            if (bookingId < 0)
                return BadRequest("Booking id is invalid.");
            var id = await bookingService.GetBookingDetails(bookingId);
            return Ok(id);
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookCab bookCab)
        {
            if (bookCab == null)
                return BadRequest("Booking details are invalid");
            var id = await bookingService.CreateBooking(bookCab);
            return Accepted(id);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int bookingId, [FromBody] BookCab bookingDetails)
        {
            if (bookingId < 0)
                return BadRequest("Booking id is invalid.");
            var id = await bookingService.UpdateBooking(bookingId, bookingDetails);
            return Accepted(id);
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int bookingId)
        {
            if (bookingId < 0)
                return BadRequest("Booking id is invalid.");
            var id = await bookingService.CancelBooking(bookingId);
            return Ok(id);
        }
    }
}
