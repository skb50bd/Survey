using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Web.Pages.Responses
{
    public class SponsorModel : PageModel
    {
        public Sponsor Sponsor { get; set; }
        public SponsorResponse SResponse => Sponsor.Response;

        private readonly ApplicationDbContext _ctx;

        public SponsorModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Sponsor = await _ctx.Sponsors
                                .Include(s => s.Response)
                                .FirstOrDefaultAsync(s => s.Id == id);

            if (Sponsor?.Response is null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}