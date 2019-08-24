using System.Collections;
using System.Collections.Generic;

namespace Domain
{
    public class Survey
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
