using BusinessLogicLayer.Infrastructure;
using Entities.Models;
using BusinessLogicLayerInterfaces.Interfaces;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using DataAccessLayerInterfaces.Repository;
using ValidationLayer.Infrastructure;

namespace BusinessLogicLayer.Service
{
    public class AnswerService : IAnswerService
    {
        IBlogRepository DataBase { get; }
        public AnswerService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void UpdateAnswer(AnswerDTO answer)
        {
            if (DataBase.Answers.Get(answer.Id) == null)
                throw new ValidationException("Answer wasn't found", "");

            var mapper = MapperConfig.GetConfigFromDTO().CreateMapper();
            var answerTemp = mapper.Map<Answer>(answer);

            DataBase.Answers.Update(answerTemp);

            DataBase.Save();
        }
    }
}
