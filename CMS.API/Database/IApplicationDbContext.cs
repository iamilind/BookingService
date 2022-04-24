using CMS.API.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMS.API.Database
{
    public interface IApplicationDbContext
    {
        DbSet<CityEntity> CityEntities { get; set; }

        DbSet<CabEntity> CabEntities { get; set; }

        DbSet<BookingEntity> BookingEntities { get; set; }

        DbSet<TripEntity> TripEntities { get; set; }

        DbSet<Driver> Drivers { get; set; }

        DbSet<User> Users { get; set; }

        Task<int> SaveChanges();
    }
}
