using BusinessLogicLayerInterfaces.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IPollService
    {
        QuestionDTO GetQuestion(string id);
        void UpdateAnswer(AnswerDTO answer);
    }
}
