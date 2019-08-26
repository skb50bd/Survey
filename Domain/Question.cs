using System.Collections.Generic;

namespace Domain
{
    public class Question
    {
        public int Id { get; set; }

        public string Statement { get; set; }
        public QuestionType QuestionType { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}