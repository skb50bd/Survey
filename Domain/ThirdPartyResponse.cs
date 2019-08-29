using System.Collections.Generic;

namespace Domain
{
    public class ThirdPartyResponse
    {
        public int Id { get; set; }

        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }
    }
}