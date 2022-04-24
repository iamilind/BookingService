using CMS.API.Database;
using CMS.API.DBEntities;
using CMS.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CityService : ICityService
    {
        readonly IApplicationDbContext _applicationDbContext;

        public CityService(IApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }
        public async Task<int> AddCityAsync(City city)
        {
            var cityDBO = new CityEntity()
            {
                Name = city.Name,
                IsActive = city.IsActive,
            };

            var entity = await _applicationDbContext.CityEntities.AddAsync(cityDBO);
            await _applicationDbContext.SaveChanges();

            return entity.Entity.Id;
        }

        public async Task<List<City>> GetCityListAsync()
        {
            var dboCities = await _applicationDbContext.CityEntities.ToListAsync<CityEntity>();

            var citites = new List<City>();
            foreach (var dboCity in dboCities)
            {
                if (dboCity.IsActive)
                {
                    var city = new City()
                    {
                        Name = dboCity.Name,
                        IsActive = dboCity.IsActive,
                    };
                    citites.Add(city);
                }

            }
            return citites;
        }

        public async Task<City> GetCityAsync(int cityId)
        {
            var dboCity = await _applicationDbContext.CityEntities.FindAsync(cityId);
            var city = new City()
            {
                Name = dboCity.Name,
                IsActive = dboCity.IsActive,
            };

            return city;
        }

        public async Task<bool> DisableCityAsync(int cityId)
        {
            return await UpdateCityAsync(cityId, new City() { IsActive = false });
        }

        public async Task<bool> EnableCityAsync(int cityId)
        {
           return await UpdateCityAsync(cityId, new City() { IsActive = true });
        }

        public async Task<bool> UpdateCityAsync(int cityId, City city)
        {
            var dboCity = new CityEntity()
            {
                Id = cityId,
                IsActive = city.IsActive
            };


            var entity = await _applicationDbContext.CityEntities.AddAsync(dboCity);
            return await _applicationDbContext.SaveChanges() > 0 ? true :false;
        } 
    }
}
