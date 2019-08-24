using System.Collections.Generic;

namespace Domain
{
    public class ThirdPartyResponse : Survey
    {
        public int ThirdPartyId { get; set; }
        public ThirdParty ThirdParty { get; set; }


        public int SurveyId { get; set; }
        public Survey Survey { get; set; }


        public IEnumerable<Response> Responses { get; set; }

        public int SponsorSurveyId { get; set; }
        public SponsorResponse SponsorResponse { get; set; }
    }
}