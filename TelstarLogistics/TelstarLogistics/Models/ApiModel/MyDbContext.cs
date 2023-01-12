using Microsoft.EntityFrameworkCore;

namespace TelstarLogistics.Models.ApiModel
{
    public class MyDbContext: DbContext
    {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "TelstarDb");
        }
        public MyDbContext() : base() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<TelstarRoute> Routes { get; set; } = null!;
    }
}
