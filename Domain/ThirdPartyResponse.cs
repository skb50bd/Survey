using System.Collections.Generic;

namespace Domain
{
    public class ThirdPartyResponse : Survey
    {
        public ThirdParty ThirdParty { get; set; }
        public Survey Survey { get; set; }

        public IEnumerable<string> Responses { get; set; }

        public SponsorResponse SponsorResponse { get; set; }
    }
}