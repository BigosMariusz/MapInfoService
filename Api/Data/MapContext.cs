using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class MapContext : DbContext
    {
        public MapContext(DbContextOptions<MapContext> options) : base(options) { }
        public DbSet<DbPlace> Places { get; set; }
        public DbSet<DbInformation> Informations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User ID=postgres;Password=toor;Server=Localhost;Port=5432;Database=MapDb;Pooling=true;");
    }
}
