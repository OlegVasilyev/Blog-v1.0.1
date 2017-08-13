using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EpamBlog.ViewModels
{
    public class Answer
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string  Text { get; set; }
        [Required]
        [DisplayName("Votes Count")]
        public int VotesCount { get; set; }

    }
}