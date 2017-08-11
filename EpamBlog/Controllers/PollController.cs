using AutoMapper;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamBlog.Controllers
{
    public class PollController : Controller
    {
        readonly IPollService _pollService;

        public PollController(IPollService serv)
        {
            _pollService = serv;
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionDTO, Question>();
                cfg.CreateMap<AnswerDTO, Answer>();
            });
            var mapper = config.CreateMapper();
            var questionView = mapper.Map<QuestionDTO, Question>(_pollService.GetQuestion(id));
            return PartialView("_PollBox", questionView);
        }

        [HttpPost]
        public ActionResult Index(int questionId, int answerId)
        {
            var questionDto = _pollService.GetQuestion(questionId);

            var answerDto = questionDto.Answers.First(x => x.Id == answerId);
            answerDto.VotesCount++;
            _pollService.UpdateAnswer(answerDto);

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<QuestionDTO, Question>();
                cfg.CreateMap<AnswerDTO, Answer>();
            });
            var mapper = config.CreateMapper();
            var pollResult = new PollResult
            {
                Question = mapper.Map<QuestionDTO, Question>(questionDto),
                AnswerId = answerId
            };

            return PartialView("_PollResult", pollResult);
        }
    }
}