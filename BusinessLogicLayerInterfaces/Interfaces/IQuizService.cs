using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IQuizService
    {
        void CreateQuiz(QuizDTO quizDto);
        void SendMailResult(QuizDTO quizDto);
        QuizDTO GetQuiz(int? Id);
        IEnumerable<QuizDTO> GetQuizs();
        void UpdateQuiz(QuizDTO quizDto);
        void DeleteQuiz(int? Id);
    }
}
