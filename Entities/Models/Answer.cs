namespace Entities.Models
{
    public class Answer : IdEntity
    {
        public int QuestionId { get; set; }
        public string  Text { get; set; }
        public int VotesCount { get; set; }

    }
}