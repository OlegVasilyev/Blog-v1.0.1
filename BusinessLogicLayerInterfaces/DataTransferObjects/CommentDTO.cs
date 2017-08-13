using System;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class CommentDTO
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string IdArticle { get; set; }
    }
}
