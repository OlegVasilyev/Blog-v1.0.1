using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Article : IdEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Tagg> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public Article()
        {
            Tags = new List<Tagg>();
            Comments = new List<Comment>();
        }
    }
}