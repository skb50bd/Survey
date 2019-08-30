using System;

namespace Domain
{
    public class ThirdParty: Responder
    {
        public int? ResponseId { get; set; }
        public ThirdPartyResponse Response { get; set; }
    }
}