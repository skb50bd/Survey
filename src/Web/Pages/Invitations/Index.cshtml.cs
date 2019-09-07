using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Web.Pages.Invitations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IList<Sponsor> Sponsors { get; set; }

        public string ClientBase { get; set; }

        private readonly ApplicationDbContext _ctx;

        public IndexModel(
            ApplicationDbContext ctx,
            IConfiguration config)
        {
            _ctx = ctx;
            ClientBase = config["ClientBase"];
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Sponsors = await _ctx.Sponsors
                                 .Include(s => s.ThirdParty)
                                 .ToListAsync();
            return Page();
        }
    }
}