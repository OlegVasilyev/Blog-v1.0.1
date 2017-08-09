using System;

namespace Entities.Models
{
    public class Comment : IdEntity
    {
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public int IdArticle { get; set; }

    }
}
