namespace Entities.Models
{
    public class Answer : IdEntity
    {
        public string QuestionId { get; set; }
        public string  Text { get; set; }
        public int VotesCount { get; set; }

    }
}