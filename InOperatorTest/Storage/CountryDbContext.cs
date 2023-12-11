using Ewl.Platform.Geo.Storage.Entities;
using Microsoft.EntityFrameworkCore;

namespace InOperatorTest.Storage
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<CountryTranslation> CountryTranslations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
          //  options.UseSqlServer("Server=SQLEXPRESS;Database=c1;Trusted_Connection=True; trustServerCertificate = true;",
            //     x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Country"));
        }

    }
}
