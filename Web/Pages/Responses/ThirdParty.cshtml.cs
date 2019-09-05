using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages.Responses
{
    public class ThirdPartyModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public ThirdPartyModel(
            ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public ThirdParty Tpr { get; set; }
        public ThirdPartyResponse TprResponse => Tpr.Response;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Tpr = await _ctx.ThirdParties
                                .Include(t => t.Response)
                                .FirstOrDefaultAsync(t => t.Id == id);
            if (Tpr?.Response is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}