using Microsoft.EntityFrameworkCore;

namespace PourCombien.Database
{
    public class PourCombienContext : DbContext
    {
        public DbSet<Defi> Defis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost;Database=pourcombien;Uid=root;Pwd=;";

            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Defi>(i =>
            {
                i.HasKey(o => o.Id);
                i.Property(o => o.Question);
                i.Property(o => o.Max);
                i.Property(o => o.Choix1);
                i.Property(o => o.Choix2);
            });
        }
    }
}
