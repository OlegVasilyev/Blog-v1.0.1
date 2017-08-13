using AutoMapper;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using DataAccessLayerInterfaces.Repository;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationLayer.Infrastructure;

namespace BusinessLogicLayer.Service
{
    public class PollService : IPollService
    {
        IBlogRepository DataBase { get; }

        public PollService(IBlogRepository uow)
        {
            DataBase = uow;
        }
        public QuestionDTO GetQuestion(string id)
        {
            if (id == null)
                throw new ValidationException("Question's id wasn't set", "");
            var question = DataBase.Questions.Get(id);
            if (question == null)
                throw new ValidationException("Question wasn't found", "");

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Question, QuestionDTO>();
                cfg.CreateMap<Answer, AnswerDTO>();
            });
            var mapper = config.CreateMapper();
            return mapper.Map<Question, QuestionDTO>(question);
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
