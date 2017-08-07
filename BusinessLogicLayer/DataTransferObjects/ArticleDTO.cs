using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.DataTransferObjects
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public List<string> Tags { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public ArticleDTO()
        {
            Tags = new List<string>();
            Comments = new List<CommentDTO>();
        }
    }
}