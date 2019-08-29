using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Sponsor>()
                   .HasOne(s => s.ThirdParty)
                   .WithOne(tp => tp.Sponsor)
                   .HasForeignKey<ThirdParty>(s => s.SponsorId)
                   .OnDelete(DeleteBehavior.SetNull);
            }

        public DbSet<Sponsor> Sponsors { get; set; }

        public DbSet<ThirdParty> ThirdParties { get; set; }
    }
}
