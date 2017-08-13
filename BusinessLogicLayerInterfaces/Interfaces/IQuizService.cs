using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IQuizService
    {
        /// <summary>
        /// Interface for working with Quiz
        /// </summary>
        void CreateQuiz(QuizDTO quizDto);
        void SendMailResult(QuizDTO quizDto);
        QuizDTO GetQuiz(string Id);
        IEnumerable<QuizDTO> GetQuizs();
        void UpdateQuiz(QuizDTO quizDto);
        void DeleteQuiz(string Id);
    }
}
