using Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Web.Pages.Invitation
{
    [Authorize]
    public class SendModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IEmailSender _sender;
        private readonly IRazorViewToStringRenderer _renderer;
        private readonly string _clientBase;


        public SendModel(
            ApplicationDbContext ctx,
            IEmailSender sender,
            IConfiguration config,
            IRazorViewToStringRenderer renderer)
        {
            _ctx = ctx;
            _sender = sender;
            _renderer = renderer;
            _clientBase = config["ClientBase"];
        }


        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string Message { get; set; }

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
                CompanyName = Input.CompanyName,
                Name = Input.SponsorName,
                Email = Input.SponsorEmail,
                ThirdParty = thirdParty
            };

            await _ctx.Sponsors.AddAsync(sponsor);
            await _ctx.ThirdParties.AddAsync(thirdParty);
            await _ctx.SaveChangesAsync();

            // https: //@Model.ClientBase/Sponsor/@sp.UniqueIdentifier

            var sponsorBase = $"{_clientBase}/Sponsor/";
            var thirdPartyBase = $"{_clientBase}/ThirdParty/";

            var sponsorInvitation =
                await _renderer.RenderViewToStringAsync(
                    "Invitation",
                    new Domain.Invitation
                    {
                        Email = sponsor.Email,
                        Name = sponsor.Name,
                        Url = sponsorBase + sponsor.UniqueIdentifier
                    });

            var thirdPartyInvitation =
                await _renderer.RenderViewToStringAsync(
                    "Invitation",
                    new Domain.Invitation
                    {
                        Email = thirdParty.Email,
                        Name = thirdParty.Name,
                        Url = thirdPartyBase + thirdParty.UniqueIdentifier
                    });


            try
            {
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

            }
            catch (Exception e)
            {
                Message = e.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }

    public class InputModel
    {
        public string CompanyName { get; set; }

        public string SponsorName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string SponsorEmail { get; set; }

        public string ThirdPartyName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string ThirdPartyEmail { get; set; }
    }
}