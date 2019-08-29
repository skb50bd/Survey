namespace Domain
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }
    }
}