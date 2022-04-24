using CMS.API.Database;
using CMS.API.DBEntities;
using CMS.API.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CMS.API.Service
{
    public class CabService : ICabService
    {
        readonly IApplicationDbContext _applicationDbContext;

        private readonly ILogger _logger;

        public CabService(IApplicationDbContext _applicationDbContext, ILoggerFactory loggerFactory)
        {
            this._applicationDbContext = _applicationDbContext;
            this._logger = loggerFactory.CreateLogger("CabService");
        }

        public async Task<int> AddCabAsync(Cab cab)
        {
            try
            {
                Enum.TryParse(cab.Category, out Categoty categoty);
                Enum.TryParse(cab.Status.ToString(), out CabStatus status);
                var cabDBO = new CabEntity()
                {
                    Name = cab.Name,
                    DriverId = 1,
                    CityId = cab.CityId,
                    Category = (int)categoty,
                    Status = (int)status,
               
                    Number = cab.Number,
                };

                var entity = await _applicationDbContext.CabEntities.AddAsync(cabDBO);
                await _applicationDbContext.SaveChanges();

                return entity.Entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception($"Exception:{ex.Message}");
            }
           
        }

        public async Task<bool> DisableCabAsync(int cabId)
        {
            return await UpdateCabDetailsAsync(cabId, new Cab() { Status= (int)CabStatus.IN_ACTIVE});
        }

        public async Task<bool> EnableCabAsync(int cabId)
        {
            return await UpdateCabDetailsAsync(cabId, new Cab() { Status = (int)CabStatus.IDLE });
        }

        public async Task<Cab> GetCabAsync(int cabId)
        {

            var dboCab = await _applicationDbContext.CabEntities.FindAsync(cabId);
            if (dboCab == null)
            {
                return null;
            }

            
            var city = new Cab()
            {
                Name = dboCab.Name,
                DriverId = dboCab.DriverId,
                CityId = dboCab.CityId,
                Category = ((Categoty)dboCab.Category).ToString(),
                Status = dboCab.Status,
                Number = dboCab.Number,
            };
                    
            return city;
        }

        public async Task<bool> UpdateCabDetailsAsync(int cabId, Cab cabDetails)
        {
            Enum.TryParse(cabDetails.Category, out Categoty categoty);
            Enum.TryParse(cabDetails.Status.ToString(), out CabStatus status);
            var dboCab = new CabEntity()
            {
                Id = cabId,
                Name = cabDetails.Name,
                DriverId = cabDetails.DriverId,
                CityId = cabDetails.CityId,
                Category = (int)categoty,
                Status = (int)status,
                Number = cabDetails.Number,
            };


            var entity = await _applicationDbContext.CabEntities.AddAsync(dboCab);
            return await _applicationDbContext.SaveChanges() > 0 ? true : false;
        }
    }
}
