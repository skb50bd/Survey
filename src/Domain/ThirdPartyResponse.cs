using System.Collections.Generic;

namespace Domain
{
    public class ThirdPartyResponse
    {
        public int Id { get; set; }

        #region Files
        public int? DocumentAId { get; set; }
        public File DocumentA { get; set; }

        public int? DocumentBId { get; set; }
        public File DocumentB { get; set; }

        public int? DocumentCId { get; set; }
        public File DocumentC { get; set; }

        public int? DocumentDId { get; set; }
        public File DocumentD { get; set; }

        public int? DocumentEId { get; set; }
        public File DocumentE { get; set; }
        #endregion

        #region Form Completion Information
        public string A1 { get; set; }
        public string A2A { get; set; }
        public string A2B { get; set; }
        public string A2C1 { get; set; }
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

        public string B3A { get; set; }
        public string B3B1 { get; set; }
        public string B3B2 { get; set; }
        public string B3C { get; set; }
        public string B3D1A { get; set; }
        public string B3D1B { get; set; }
        public string B3D2 { get; set; }

        public string B4A { get; set; }
        public string B4B { get; set; }
        public string B4C { get; set; }

        public string B5 { get; set; }
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
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        public string D4 { get; set; }
        public string D4A { get; set; }
        public string D4B { get; set; }
        public string D4C { get; set; }
        public string D4D { get; set; }
        public string D5 { get; set; }
        public string D6 { get; set; }
        public string D6A { get; set; }
        #endregion

        #region Potential Conflicts Information
        public string E1A { get; set; }
        public string E1B { get; set; }
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
        public string G2A { get; set; }
        public string G2B { get; set; }
        public string G2C { get; set; }
        public string G2D { get; set; }
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