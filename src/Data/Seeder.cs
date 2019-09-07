using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public static class Seeder
    {
        public static async Task Seed(this UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByIdAsync("admin");
            if (user != null)
                return;

            var admin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@thermon.com",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, "Thermon=12");
        }
    }
}
