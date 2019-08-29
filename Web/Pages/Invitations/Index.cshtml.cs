using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages.Invitations
{
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