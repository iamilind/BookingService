using CMS.API.Filters;
using CMS.API.Models;
using CMS.API.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabController : ControllerBase
    {
        private ICabService cabService;

        public CabController(ICabService cabService)
        {
            this.cabService = cabService;
        }

        // GET api/<CabsController>/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Get(int cabId)
        {
            var id = await cabService.GetCabAsync(cabId);
            return Ok(id);
        }

        // POST api/<CabsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cab cabDetails)
        {
            var id = await cabService.AddCabAsync(cabDetails);
            return Ok(id);
        }

        // PUT api/<CabsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int cabId, [FromBody] Cab cabDetails)
        {
            var id = await cabService.UpdateCabDetailsAsync(cabId, cabDetails);
            return Ok(id);
        }

        // DELETE api/<CabsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int cabId)
        {
            var id = await cabService.DisableCabAsync(cabId);
            return Ok(id);
        }
    }
}
