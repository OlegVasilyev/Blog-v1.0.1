using System.Collections.Generic;

namespace Entities.Models
{
    public class Tagg : IdEntity
    {
        public string Text { get; set; }
        public virtual ICollection<Article>  Articles { get; set; }
        public Tagg()
        {
            Articles = new List<Article>();
        }
    }
}