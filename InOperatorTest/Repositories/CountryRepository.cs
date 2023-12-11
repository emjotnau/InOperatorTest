using Ewl.Platform.Geo.Storage.Entities;
using InOperatorTest.Dto;
using InOperatorTest.Storage;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace InOperatorTest.Repositories;

public class CountryRepository
{
    private readonly CountryDbContext _dbContext;
    private SqliteConnection? _connection;

    public CountryRepository()
    {
        _dbContext = PrepareContext();
    }

    public IQueryable<CountryListDto> GetCountries()
    {
        return _dbContext.Countries.Select(e => new CountryListDto
        {
            Id = e.Id,
            Name = e.Translations.First().Name
        });
    }

    private CountryDbContext PrepareContext()
    {
        var options = PrepareSqlLiteContextOptions();
        var contextMock = new Mock<CountryDbContext>(options);
        contextMock.CallBase = true;


        var context = contextMock.Object;

        context!.Database.EnsureDeleted();
        context!.Database.EnsureCreated();

        var countryId = new Guid("aa5fa428-dfc2-463a-9a0f-b304969aa968");
        context.Countries.Add(new Country
        {
            Id = countryId,
            Translations = new List<CountryTranslation>()
            {
                new CountryTranslation
                {
                    Id = Guid.NewGuid(),
                    CountryId = countryId,
                    Name = "name1"
                },
                 new CountryTranslation
                {
                    Id = Guid.NewGuid(),
                    CountryId = countryId,
                    Name = "name2"
                }
            }
        });
        context.SaveChanges();
        context.ChangeTracker.Clear();

        return context;
    }

    private DbContextOptions<CountryDbContext> PrepareSqlLiteContextOptions()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<CountryDbContext>()
              .UseSqlite(_connection)
              .Options;
        var serviceProviderMock = new Mock<IServiceProvider>();

        return options;
    }
}


