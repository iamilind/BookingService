using CMS.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProcessBookingController : ControllerBase
    {
        private IProcessBookingService _processBookingService;

        public ProcessBookingController(IProcessBookingService processBookingService)
        {
            this._processBookingService = processBookingService;
        }


        // POST api/<ProcessBookingController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int bookingId)
        {
            if (bookingId <= 0)
                BadRequest("Booking Id i invalid");
            var bookingDetails = await _processBookingService.ProcessBooking(bookingId);
            return Ok(bookingDetails);
        }

        // PUT api/<ProcessBookingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string bookingStatus)
        {
            if (id <= 0 || string.IsNullOrWhiteSpace(bookingStatus))
                BadRequest("Booking Id or status is invalid or ");
            var bookingDetails = await _processBookingService.EndBooking(id, bookingStatus);
            return Ok(bookingDetails);
        }
    }
}
