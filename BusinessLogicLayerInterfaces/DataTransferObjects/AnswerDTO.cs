using System.ComponentModel;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string  Text { get; set; }
        [DisplayName("Votes Count")]
        public int VotesCount { get; set; }

    }
}