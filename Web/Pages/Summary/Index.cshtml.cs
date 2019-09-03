using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Web.Pages.Summary
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public string UniqueId => 
            Sponsor.UniqueIdentifier.ToString();

        public ResponseSummary ResponseSummary { get; set; }
        public Sponsor Sponsor { get; set; }
        public ThirdParty Tpr => Sponsor.ThirdParty;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Sponsor = await _ctx.Sponsors
                              .Include(s => s.Response)
                              .Include(s => s.ThirdParty)
                              .ThenInclude(tp => tp.Response)
                              .FirstOrDefaultAsync(s => s.Id == id);

            if (Sponsor is null) return NotFound();

            ResponseSummary = new ResponseSummary
            {
                SponsorResponseId = Sponsor.ResponseId,
                SponsorResponse = Sponsor.Response,
                ThirdPartyResponseId = Sponsor.ThirdParty.ResponseId,
                ThirdPartyResponse = Sponsor.ThirdParty.Response
            };


            return Page();
        }


        [BindProperty]
        public ResponseSummaryInput Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            Sponsor = await _ctx.Sponsors
                                .Include(s => s.ThirdParty)
                                .FirstOrDefaultAsync(
                                     s => s.UniqueIdentifier.ToString() == Input.UniqueIdentifier);

            var responseSummary = new ResponseSummary
            {
                D = Input.D,
                G4A = Input.G4A,
                G4B = Input.G4B,
                I1 = Input.I1,
                I2 = Input.I2,
                I3 = Input.I3,
                I4 = Input.I4,
                SponsorResponseId = Sponsor?.ResponseId,
                ThirdPartyResponseId = Tpr?.ResponseId,
            };

            Sponsor.Summary = responseSummary;
            await _ctx.SaveChangesAsync();

            return RedirectPermanent("/Invitations/Index");
        }
    }



    public class ResponseSummaryInput
    {
        public string UniqueIdentifier { get; set; }

        public string D { get; set; }
        public string G4A { get; set; }
        public string G4B { get; set; }
        public string I1 { get; set; }

        [DataType(DataType.Date)]
        public string I2 { get; set; }

        [DataType(DataType.Date)]
        public string I3 { get; set; }
        public string I4 { get; set; }
    }
}