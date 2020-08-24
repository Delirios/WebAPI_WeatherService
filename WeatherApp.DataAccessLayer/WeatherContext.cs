using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Domain;

namespace WeatherApp.DataAccessLayer
{
    public class WeatherContext : DbContext
    {

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public  DbSet<Clouds> Clouds { get; set; }
        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Main> Mains { get; set; }
        public DbSet<Root> Roots { get; set; }
        public DbSet<Domain.System> Systems { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Wind> Winds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
            //Property Configurations

            modelBuilder.Entity<Weather>()
                .Property(w => w.request_date)
                .HasDefaultValueSql("getdate()");
        }
    }
}
