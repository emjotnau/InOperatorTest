using InOperatorTest.Dto;
using InOperatorTest.Repositories;
using InOperatorTest.Storage;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<CountryRepository>();
//builder.Services.AddDbContext<CountryDbContext>();
builder.Services.AddControllers()
.AddOData(o =>
 {
     o.Select().Filter().OrderBy().Count().Expand().SetMaxTop(100);
     o.TimeZone = TimeZoneInfo.Utc;
     var modelBuilder = new ODataConventionModelBuilder();
     modelBuilder.EntitySet<CountryListDto>("countries");
     modelBuilder.EnableLowerCamelCase();
     var model = modelBuilder.GetEdmModel();
     o.AddRouteComponents("cr", model);
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
