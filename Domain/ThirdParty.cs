namespace Domain
{
    public class ThirdParty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}