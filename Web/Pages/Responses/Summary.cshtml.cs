using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web.Pages.Responses
{
    public class SummaryModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public SummaryModel(
            ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Sponsor Sponsor { get; set; }
        public ResponseSummary ResponseSummary => Sponsor.Summary;
        public ThirdParty Tpr => Sponsor.ThirdParty;
        
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Sponsor = 
                await _ctx.Sponsors
                          .Include(s => s.ThirdParty)
                          .Include(s => s.Summary)
                          .FirstOrDefaultAsync(s => s.Id == id);

            if (Sponsor?.Summary is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}