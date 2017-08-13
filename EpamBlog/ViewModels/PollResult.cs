using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamBlog.ViewModels
{
    public class PollResult
    {
        public Question Question { get; set; }

        public string AnswerId { get; set; }
    }
}