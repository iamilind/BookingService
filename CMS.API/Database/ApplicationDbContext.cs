using CMS.API.DBEntities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CMS.API.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<CityEntity> CityEntities { get; set; }
        public DbSet<CabEntity> CabEntities { get; set; }
        public DbSet<BookingEntity> BookingEntities { get; set; }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<TripEntity> TripEntities { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CityEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<CabEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.CityId).IsRequired();
                entity.Property(e => e.Number).IsRequired();
                entity.Property(e => e.DriverId).IsRequired();
            });

            modelBuilder.Entity<BookingEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CityId).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Status).IsRequired();
            });


        }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
