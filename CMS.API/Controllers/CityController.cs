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
    public class CityController : ControllerBase
    {
        private ICityService cityService;
        public CityController( ICityService cityService)
        {
            this.cityService = cityService;
        }

        // GET api/<CityController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cities = await cityService.GetCityListAsync();
            return Ok(cities);
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int cityId)
        {
            var id = await cityService.GetCityAsync(cityId);
            return Ok(id);
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            var id = await cityService.AddCityAsync(city);
            return Accepted(id);
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int cityId, [FromBody] City cityDetails)
        {
            if(cityId <= 0)
                return UnprocessableEntity("City id is invalid.");
            var id = await cityService.UpdateCityAsync(cityId, cityDetails);
            return Ok(id);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int cityId)
        {
            var id = await cityService.DisableCityAsync(cityId);
            return Ok(id);
        }
    }
}
