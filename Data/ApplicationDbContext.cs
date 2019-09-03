using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data
{
    public sealed class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            var pm = Database.GetPendingMigrations();
            if (pm.Any())
            {
                Database.Migrate();
            }

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ThirdParty>()
                   .HasIndex(tp => tp.UniqueIdentifier);

            builder.Entity<Sponsor>()
                   .HasIndex(s => s.UniqueIdentifier);
        }

        public DbSet<Sponsor> Sponsors { get; set; }

        public DbSet<ThirdParty> ThirdParties { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<SponsorResponse> SponsorResponses { get; set; }
        public DbSet<ThirdPartyResponse> ThirdPartyResponses { get; set; }
        public DbSet<ResponseSummary> ResponseSummaries { get; set; }

    }
}
