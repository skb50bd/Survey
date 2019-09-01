namespace Domain
{
    public class ResponseSummary
    {
        public int Id { get; set; }

        public int? SponsorResponseId { get; set; }
        public SponsorResponse SponsorResponse { get; set; }

        public int? ThirdPartyResponseId { get; set; }
        public ThirdPartyResponse ThirdPartyResponse { get; set; }

        #region Business Information
        public string A1 => SponsorResponse?.A1;
        public string A2 => SponsorResponse?.B1;
        public string A3 => SponsorResponse?.B2;
        public string A4 => SponsorResponse?.B3;
        #endregion

        #region Date Sponsor Form Submitted
        public string C => SponsorResponse?.G2;
        #endregion

        #region Status of Form 
        public string D { get; set; }
        #endregion

        #region Third Party
        public string E1 => ThirdPartyResponse?.B1;
        public string E2 => ThirdPartyResponse?.B2A;
        public string E3 => ThirdPartyResponse?.B2B;
        public string E4 => SponsorResponse?.C2;
        public string E5 => ThirdPartyResponse?.B2F;
        public string E6 => SponsorResponse?.C3;
        public string E7 => SponsorResponse?.D1;
        public string E8 => SponsorResponse?.D2;
        public string E9 => SponsorResponse?.D3;
        public string E10 => ThirdPartyResponse?.B3D1A;
        public string E11 => ThirdPartyResponse?.B3D2;
        public string E12 => ThirdPartyResponse?.D4;
        public string E13 =>
            ThirdPartyResponse?.E1A == "Yes"
            || ThirdPartyResponse?.E2A == "Yes"
            || ThirdPartyResponse?.E2B == "Yes"
                ? "Yes"
                : "No";

        public string E14 =>
            SponsorResponse?.B3 == "Yes"
            || SponsorResponse?.E1 == "Yes"
            || SponsorResponse?.E2 == "Yes"
            || SponsorResponse?.E3 == "Yes"
                ? "Yes"
                : "No";
        public string E15 => ThirdPartyResponse?.G1;
        #endregion

        #region Internal Information
        public string G1 => SponsorResponse?.F1;
        public string G2 => SponsorResponse?.F2;
        public string G3 => SponsorResponse?.F3;
        public string G4A { get; set; }
        public string G4B { get; set; }
        #endregion

        #region Supporting Documentation
        public File H1 => ThirdPartyResponse.DocumentA;
        public File H2 => ThirdPartyResponse.DocumentB;
        public File H3 => ThirdPartyResponse.DocumentC;
        public File H4 => ThirdPartyResponse.DocumentD;
        public File H5 => ThirdPartyResponse.DocumentE;
        #endregion

        #region Compliance Approval
        public string I1 { get; set; }
        public string I2 { get; set; }
        public string I3 { get; set; }
        public string I4 { get; set; }
        #endregion
    }
}
