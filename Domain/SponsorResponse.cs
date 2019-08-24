using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class SponsorResponse
    {
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }

        public int SurveyId { get; set; }
        public Survey Survey { get; set; }


        public IEnumerable<Response> Responses { get; set; }

        public int ThirdPartySurveyId { get; set; }
        public ThirdPartyResponse ThirdPartyResponse { get; set; }
    }
}