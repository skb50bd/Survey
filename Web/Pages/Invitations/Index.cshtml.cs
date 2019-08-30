using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Web.Pages.Invitations
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public IList<Sponsor> Sponsors { get; set; }

        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnGet()
        {
            Sponsors = _ctx.Sponsors.Include(s => s.ThirdParty).ToList();
        }
    }
}