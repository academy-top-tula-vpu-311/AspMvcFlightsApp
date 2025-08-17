using Microsoft.EntityFrameworkCore;

namespace AspMvcFlightsApp.Models
{
    public class DataModelDbContext : DbContext
    {
        public DbSet<CityData> Cities { get; set; }
        public DbSet<AirportData> Airports { get; set; }
        public DbSet<AirlineData> Airlines { get; set; }
        public DbSet<FlightData> Flights { get; set; }

        public DataModelDbContext(DbContextOptions<DataModelDbContext> options) 
            : base(options) { }
    }
}
