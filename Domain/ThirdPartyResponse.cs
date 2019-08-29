using System.Collections.Generic;

namespace Domain
{
    public class ThirdPartyResponse : Survey
    {
        public ThirdParty ThirdParty { get; set; }
        public IEnumerable<Response> Responses { get; set; }
    }
}