using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Client.Pages
{
    public class ThirdPartyModel : PageModel
    {
        [BindProperty]
        public ThirdPartyResponseInput Answers { get; set; }

        public string UniqueId { get; set; }
    }
    public class ThirdPartyResponseInput
    {
        public string UniqueIdentifier { get; set; }

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
        public string B2E { get; set; }
        public string B2F { get; set; }

        public string B2Oa { get; set; }
        public string B2Ob { get; set; }
        public string B2Oc { get; set; }
        public string B2Od { get; set; }

        public IFormFile B3File { get; set; }
        public string B3A { get; set; }
        public string B3B1 { get; set; }
        public string B3B2 { get; set; }
        public string B3C { get; set; }
        public string B3D1A { get; set; }
        public string B3D1B { get; set; }
        public string B3D2 { get; set; }

        public IFormFile B4File { get; set; }
        public string B4A { get; set; }
        public string B4B { get; set; }
        public string B4C { get; set; }

        public string B5 { get; set; }
        public IFormFile B5File { get; set; }
        #endregion

        #region Reference Information
        public string C1A { get; set; }
        public string C1B { get; set; }
        public string C1C { get; set; }
        public string C1D { get; set; }
        public string C1E { get; set; }
        public string C1F1 { get; set; }
        public string C1F2 { get; set; }

        public string C2A { get; set; }
        public string C2B { get; set; }
        public string C2C { get; set; }
        public string C2D { get; set; }
        public string C2E { get; set; }
        public string C2F1 { get; set; }
        public string C2F2 { get; set; }

        public string C3A { get; set; }
        public string C3B { get; set; }
        public string C3C { get; set; }
        public string C3D { get; set; }
        public string C3E { get; set; }
        public string C3F1 { get; set; }
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
        public string E1 { get; set; }
        public IList<string> E1A { get; set; }
        public string E2 { get; set; }
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
        public string H1 { get; set; }
        public string H2 { get; set; }
        public string H3 { get; set; }
        public string H4 { get; set; }
        public string H5 { get; set; }
        #endregion
    }

}