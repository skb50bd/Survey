using Data.Repository;
using LiteDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataConfiguration
    {
        public static IServiceCollection ConfigureData(
            this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    config.GetConnectionString("IdentityDB")));
            services.AddDefaultIdentity<IdentityUser>()
                    .AddDefaultUI(UIFramework.Bootstrap4)
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            BsonMapper.Global.ConfigureMapper();

            return services;
        }

    }
}
