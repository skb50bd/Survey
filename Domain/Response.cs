namespace Domain
{
    public class Response
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public string Answer { get; set; }
    }
}
