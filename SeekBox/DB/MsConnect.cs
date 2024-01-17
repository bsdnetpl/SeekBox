using Microsoft.EntityFrameworkCore;
using SeekBox.Models;

namespace SeekBox.DB
{
    public class MsConnect : DbContext
    {
        public MsConnect(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Package> packages { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Pos> pos {  get; set; }
        public DbSet<StatusBox> statusBox { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Package>().HasIndex(i => i.packageNumber).IsUnique();
            modelBuilder.Entity<StatusBox>().HasIndex(i => i.boxGuid).IsUnique();
        }
    }
}
