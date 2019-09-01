using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace Web.Pages.Invitations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IList<Sponsor> Sponsors { get; set; }

        public string ClientBase { get; set; }

        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            ClientBase = config["ClientBase"];
        }

        public void OnGet()
        {
            Sponsors = _ctx.Sponsors.Include(s => s.ThirdParty).ToList();
        }
    }
}