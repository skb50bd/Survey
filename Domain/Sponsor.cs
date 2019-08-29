namespace Domain
{
    public class Sponsor: Responder
    {
        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }
    }
}