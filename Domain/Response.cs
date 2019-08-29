using System.Collections.Generic;

namespace Domain
{
    public class Response
    {
        public string Id { get; set; }
        public IList< string> Answers { get; set; }
    }
}