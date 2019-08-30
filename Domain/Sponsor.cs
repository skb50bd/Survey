namespace Domain
{
    public class Sponsor: Responder
    {
        public int? ResponseId { get; set; }
        public SponsorResponse Response { get; set; }

        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }
    }
}