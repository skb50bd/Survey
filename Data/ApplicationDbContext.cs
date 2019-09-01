using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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
    }
}
