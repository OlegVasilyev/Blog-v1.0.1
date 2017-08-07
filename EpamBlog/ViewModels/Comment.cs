using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class Comment
    {
        public string Text { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public int IdArticle { get; set; }
    }
}