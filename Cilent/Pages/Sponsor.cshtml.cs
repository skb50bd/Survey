using AutoMapper;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client.Pages
{
    public class SponsorModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _ctx;
        public string UniqueId { get; set; }

        public IList<string> Countries =
            JsonConvert.DeserializeObject<IList<string>>(
                System.IO.File.ReadAllText("countries.json"));

        public SponsorModel(
            IMapper mapper,
            ApplicationDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<IActionResult> OnGetAsync(string uid)
        {
            if (uid == null)
                return NotFound();

            var sponsor =
                await _ctx.Sponsors.FirstOrDefaultAsync(
                    s => s.UniqueIdentifier.ToString() == uid);

            var isValid = !sponsor?.HasResponded ?? false;

            if (!isValid)
                return NotFound();

            UniqueId = uid;

            return Page();
        }


        [BindProperty]
        public SponsorResponseInput Answers { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = _mapper.Map<SponsorResponse>(Answers);
            var sponsor = await _ctx.Sponsors.FirstOrDefaultAsync(
                s => s.UniqueIdentifier.ToString() ==
                     Answers.UniqueIdentifier);

            sponsor.Response = response;
            sponsor.HasResponded = true;
            await _ctx.SaveChangesAsync();

            return RedirectToPagePermanent(
                "./ThankYou",
                new
                {
                    name = sponsor.Name
                }
            );
        }
    }
    public class SponsorResponseInput
    {
        public string UniqueIdentifier { get; set; }

        #region Type of TPR
        public string A1 { get; set; }
        #endregion

        #region Business Information
        public string B1 { get; set; }
        public string B2 { get; set; }
        public string B3 { get; set; }
        #endregion

        #region TPR Representative
        public string C1 { get; set; }
        public IList<string> C2 { get; set; }
        public string C3 { get; set; }

        public string C4 { get; set; }

        [DataType(DataType.Url)]
        public string C5 { get; set; }
        public string C6 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string C7 { get; set; }
        #endregion

        #region Selection of TPR
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        #endregion

        #region Background of the TPR
        public string E1 { get; set; }
        public string E2 { get; set; }
        public string E3 { get; set; }
        #endregion

        #region Internal Information
        public string F1 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string F2 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string F3 { get; set; }
        #endregion

        #region Completed and Confirm as Accurate
        public bool G0 { get; set; }
        public string G1 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string G2 { get; set; }

        [DataType(DataType.Date)]
        public string G3 { get; set; }
        #endregion
    }
}