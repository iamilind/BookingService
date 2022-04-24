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
                entity.Property(e => e.Model).IsRequired();
                entity.Property(e => e.Category).IsRequired();
                entity.Property(e => e.CityId).IsRequired();
                entity.Property(e => e.Number).IsRequired();
                entity.Property(e => e.DriveName).IsRequired();
            });


        }
    }
}
