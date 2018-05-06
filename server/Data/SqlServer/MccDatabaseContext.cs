using LPCS.Server.Data.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace LPCS.Server.Data.SqlServer
{
    public class MccDatabaseContext : DbContext
    {
        public MccDatabaseContext(DbContextOptions<MccDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Lender> Lenders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lender>().ToTable("Lender");
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<State>().ToTable("State");

            modelBuilder.Entity<Lender>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Lender);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.State)
                .WithOne(b => b.Address);
        }
    }
}
