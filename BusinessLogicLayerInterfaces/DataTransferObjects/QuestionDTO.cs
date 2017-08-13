using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class QuestionDTO
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerDTO> Answers { get; set; }
    }
}
