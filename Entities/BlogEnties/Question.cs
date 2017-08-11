using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Question : IdEntity
    {
        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
