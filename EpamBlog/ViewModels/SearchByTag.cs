using System.Collections.Generic;

namespace EpamBlog.ViewModels
{
    public class SearchByTag
    {
        public List<Article> Articles { get; set; }

        public string TagText { get; set; }
    }
}