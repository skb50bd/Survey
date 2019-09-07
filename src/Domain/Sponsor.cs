namespace Domain
{
    public class Sponsor: Responder
    {
        public string CompanyName { get; set; }

        public int? ResponseId { get; set; }
        public SponsorResponse Response { get; set; }

        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }

        public int? SummaryId { get; set; }
        public ResponseSummary Summary { get; set; }
    }
}