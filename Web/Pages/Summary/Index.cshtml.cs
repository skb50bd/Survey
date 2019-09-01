using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages.Summary
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public string UniqueId { get; set; }
        public ResponseSummary ResponseSummary { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var sponsor = await _ctx.Sponsors
                              .Include(s => s.Response)
                              .Include(s => s.ThirdParty)
                              .ThenInclude(tp => tp.Response)
                              .FirstOrDefaultAsync(s => s.Id == id);

            if (sponsor == null) return NotFound();

            ResponseSummary = new ResponseSummary
            {
                SponsorResponseId    = sponsor.ResponseId,
                SponsorResponse      = sponsor.Response,
                ThirdPartyResponseId = sponsor.ThirdParty.ResponseId,
                ThirdPartyResponse   = sponsor.ThirdParty.Response
            };

            return Page();
        }

        [BindProperty]
        public ResponseSummaryInput Input { get; set; }

    }



    public class ResponseSummaryInput
    {
        public string UniqueIdentifier { get; set; }
        public string D { get; set; }
        public string G4A { get; set; }
        public string G4B { get; set; }
        public string I1 { get; set; }
        public string I2 { get; set; }
        public string I3 { get; set; }
        public string I4 { get; set; }
    }
}