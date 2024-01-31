using Microsoft.EntityFrameworkCore;

namespace nightclub.Entities
{
    public class DbNightClubContext : DbContext
    {
        private string _connectionString;

        public DbNightClubContext() : base()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("MemberDBConnectionString");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityCard>()
                .HasOne(ic => ic.Member)
                .WithMany(m => m.IdentityCards)
                .HasForeignKey(ic => ic.MemberId);

            modelBuilder.Entity<IdentityCard>()
            .HasIndex(ic => ic.CardNumber)
            .IsUnique();

            modelBuilder.Entity<MembershipCard>()
                .HasOne(mc => mc.Member)
                .WithMany(m => m.MembershipCards)
                .HasForeignKey(mc => mc.MemberId);

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<IdentityCard> IdentityCards { get; set; }
        public DbSet<MembershipCard> MembershipCards { get; set; }
    }
}
