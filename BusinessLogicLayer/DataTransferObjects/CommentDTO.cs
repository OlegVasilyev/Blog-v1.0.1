using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public int IdArticle { get; set; }
    }
}
