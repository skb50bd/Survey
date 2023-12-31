﻿using AutoMapper;
using Data;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using File = Domain.File;

namespace Client.Pages
{
    public class ThirdPartyModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _ctx;

        public ThirdPartyModel(
            IMapper mapper,
            ApplicationDbContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public string UniqueId { get; set; }

        public async Task<IActionResult> OnGetAsync(string uid)
        {
            var page = await CheckValidity(uid);
            if (!(page is null))
                return page;

            UniqueId = uid;

            return Page();
        }



        [BindProperty]
        public ThirdPartyResponseInput Input { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var page = await CheckValidity(Input.UniqueIdentifier);
            if (!(page is null))
                return page;

            var response = _mapper.Map<ThirdPartyResponse>(Input);
            var thirdParty = await _ctx.ThirdParties.FirstOrDefaultAsync(
                s => s.UniqueIdentifier.ToString() ==
                     Input.UniqueIdentifier);

            var fileA = await MakeFile(Input.DocumentA);
            var fileB = await MakeFile(Input.DocumentB);
            var fileC = await MakeFile(Input.DocumentC);
            var fileD = await MakeFile(Input.DocumentD);
            var fileE = await MakeFile(Input.DocumentE);

            response.DocumentA = fileA;
            response.DocumentB = fileB;
            response.DocumentC = fileC;
            response.DocumentD = fileD;
            response.DocumentE = fileE;

            thirdParty.Response = response;
            thirdParty.HasResponded = true;
            await _ctx.SaveChangesAsync();

            return RedirectToPagePermanent(
                "./ThankYou",
                new
                {
                    name = thirdParty.Name
                }
            );
        }

        public async Task<IActionResult> CheckValidity(string uid)
        {
            if (uid == null)
                return NotFound();

            var tpr =
                await _ctx.ThirdParties.FirstOrDefaultAsync(
                    s => s.UniqueIdentifier.ToString() == uid);

            var isExpired = tpr?.HasResponded ?? false;
            if (isExpired)
                return RedirectToPage("/LinkExpired");

            return tpr is null ? NotFound() : null;
        }

        public static async Task<File> MakeFile(IFormFile formFile)
        {
            if (!(formFile?.Length > 0)) return null;

            File file;
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var byteArray = memoryStream.ToArray();
                file = new File
                {
                    Content = byteArray,
                    FileName = formFile.FileName
                };
            }

            return file;
        }
    }

    public class ThirdPartyResponseInput
    {
        public string UniqueIdentifier { get; set; }

        #region Files
        [DataType(DataType.Upload)]
        public IFormFile DocumentA { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile DocumentB { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile DocumentC { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile DocumentD { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile DocumentE { get; set; }
        #endregion

        #region Form Completion Information
        [DataType(DataType.Date)]
        public string A1 { get; set; }

        public string A2A { get; set; }

        [DataType(DataType.EmailAddress)]
        public string A2B { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string A2C1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string A2C2 { get; set; }
        #endregion

        #region Business Information
        public string B1 { get; set; }
        public string B2A { get; set; }
        public string B2B { get; set; }
        public string B2C { get; set; }
        public string B2D1 { get; set; }
        public string B2D2 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string B2E { get; set; }

        [DataType(DataType.Url)]
        public string B2F { get; set; }

        public string B2Oa { get; set; }

        [DataType(DataType.Date)]
        public string B2Ob { get; set; }
        public string B2Oc { get; set; }
        public string B2Od { get; set; }


        public string B3A { get; set; }

        [DataType(DataType.Date)]
        public string B3B1 { get; set; }
        public string B3B2 { get; set; }

        public string B3C { get; set; }
        public string B3D1A { get; set; }
        public string B3D1B { get; set; }
        public string B3D2 { get; set; }

        public string B4A { get; set; }
        public string B4B { get; set; }
        public IList<string> B4C { get; set; }

        public string B5 { get; set; }
        #endregion

        #region Reference Information
        public string C1A { get; set; }
        public string C1B { get; set; }
        public string C1C { get; set; }

        [DataType(DataType.EmailAddress)]
        public string C1D { get; set; }
        public string C1E { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C1F1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C1F2 { get; set; }

        public string C2A { get; set; }
        public string C2B { get; set; }
        public string C2C { get; set; }

        [DataType(DataType.EmailAddress)]
        public string C2D { get; set; }
        public string C2E { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C2F1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C2F2 { get; set; }

        public string C3A { get; set; }
        public string C3B { get; set; }
        public string C3C { get; set; }

        [DataType(DataType.EmailAddress)]
        public string C3D { get; set; }
        public string C3E { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C3F1 { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string C3F2 { get; set; }
        #endregion

        #region Personal Information
        public IList<string> D1 { get; set; }
        public IList<string> D2 { get; set; }
        public string D3 { get; set; }
        public string D4 { get; set; }
        public IList<string> D4A { get; set; }
        public IList<string> D4B { get; set; }
        public IList<string> D4C { get; set; }
        public IList<string> D4D { get; set; }
        public string D5 { get; set; }
        public string D6 { get; set; }
        public IList<string> D6A { get; set; }
        #endregion

        #region Potential Conflicts Information
        public string E1A { get; set; }
        public IList<string> E1B { get; set; }
        public string E2A { get; set; }
        public string E2B { get; set; }
        public string E3 { get; set; }
        #endregion

        #region Compliance Information
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string F6 { get; set; }
        public string F7 { get; set; }
        public string F8 { get; set; }
        public string F9 { get; set; }
        public string F10 { get; set; }
        public string F11 { get; set; }
        public string F12 { get; set; }
        public string F13A { get; set; }
        public string F13B { get; set; }
        public string F13C { get; set; }
        public string F13D { get; set; }
        #endregion

        #region Sub-Agent Information
        public string G1 { get; set; }
        public IList<string> G2A { get; set; }
        public IList<string> G2B { get; set; }
        public IList<string> G2C { get; set; }
        public IList<string> G2D { get; set; }
        #endregion

        #region Signature and Certification
        public bool H0 { get; set; }
        public string H1 { get; set; }

        [DataType(DataType.EmailAddress)]
        public string H2 { get; set; }

        [DataType(DataType.Date)]
        public string H3 { get; set; }
        public string H4 { get; set; }
        public string H5 { get; set; }
        #endregion
    }
}