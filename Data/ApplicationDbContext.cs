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

            
        }

        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<ThirdParty> ThirdParties { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SponsorResponse> SponsorResponses { get; set; }
        public DbSet<ThirdPartyResponse> ThirdPartyResponses { get; set; }
    }
}
