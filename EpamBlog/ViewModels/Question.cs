using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class Question
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}