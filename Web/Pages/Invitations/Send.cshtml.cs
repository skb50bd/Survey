using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI;

namespace Web.Pages.Invitation
{
    public class SendModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IEmailSender _sender;
        private readonly IRazorViewToStringRenderer _renderer;


        public SendModel(
            ApplicationDbContext ctx,
            IEmailSender sender,
            IRazorViewToStringRenderer renderer)
        {
            _ctx = ctx;
            _sender = sender;
            _renderer = renderer;
        }

        public void OnGet()
        {

        }


        [BindProperty]
        public InputModel Input { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            var thirdParty = new ThirdParty
            {
                Name = Input.ThirdPartyName,
                Email = Input.ThirdPartyEmail,
            };

            var sponsor = new Sponsor
            {
                Name = Input.SponsorName,
                Email = Input.SponsorEmail,
                ThirdParty = thirdParty
            };

            await _ctx.Sponsors.AddAsync(sponsor);
            await _ctx.ThirdParties.AddAsync(thirdParty);
            await _ctx.SaveChangesAsync();

            var sponsorInvitation =
                await _renderer.RenderViewToStringAsync(
                    "Invitation",
                    new Domain.Invitation
                    {
                        Email = sponsor.Email,
                        Name = sponsor.Name,
                        Url = Url.Page(
                            "/Survey/Sponsor",
                            new
                            {
                                uid = sponsor.UniqueIdentifier.ToString()
                            })
                    });

            var thirdPartyInvitation =
                await _renderer.RenderViewToStringAsync(
                    "Invitation",
                    new Domain.Invitation
                    {
                        Email = thirdParty.Email,
                        Name = thirdParty.Name,
                        Url = Url.Page(
                            "/Survey/ThirdParty",
                            new
                            {
                                uid = sponsor.UniqueIdentifier.ToString()
                            })
                    });


            await _sender.SendEmailAsync(
                sponsor.Email,
                "Please Respond to the Survey",
                sponsorInvitation
            );

            await _sender.SendEmailAsync(
                thirdParty.Email,
                "Please Respond to the Survey",
                thirdPartyInvitation
                );

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