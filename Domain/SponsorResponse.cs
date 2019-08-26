using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class SponsorResponse
    {
        public Sponsor Sponsor { get; set; }
        public Survey Survey { get; set; }


        public IEnumerable<string> Responses { get; set; }

        public ThirdPartyResponse ThirdPartyResponse { get; set; }
    }
}