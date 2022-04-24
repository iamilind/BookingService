using CMS.API.Models;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CityService : ICityService
    {
        public Task<int> AddCityAsync(City city)
        {
            throw new System.NotImplementedException();
        }

        public Task<City> GetCityAsync(int cityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DisableCityAsync(int cityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EnableCityAsync(int cityId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCityAsync(int cityId, City city)
        {
            throw new System.NotImplementedException();
        }
    }
}
