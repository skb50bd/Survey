using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Invitation
{
    public class SendModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        [BindProperty]
        public InputModel Input { get; set; }
        


        public SendModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            var thirdParty = new ThirdParty
            {
                Name    = Input.ThirdPartyName,
                Email   = Input.ThirdPartyEmail,
            };

            var sponsor = new Sponsor
            {
                Name  = Input.SponsorName,
                Email = Input.SponsorEmail,
                ThirdParty = thirdParty
            };
            
            await _ctx.Sponsors.AddAsync(sponsor);
            await _ctx.ThirdParties.AddAsync(thirdParty);
            await _ctx.SaveChangesAsync();

            thirdParty.SponsorId = sponsor.Id;
            await _ctx.SaveChangesAsync();

            // TODO - SEND EMAIL INVITATIONS

            return RedirectToPage("./Index");
        }

        public class InputModel
        {
            [Required]
            public string SponsorName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string SponsorEmail { get; set; }

            [Required]
            public string ThirdPartyName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string ThirdPartyEmail { get; set; }
        }
    }
}