using AutoMapper;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using EpamBlog.ViewModels;

namespace EpamBlog.MapperWeb
{
    public class MapperConfigWeb
    {
        public static MapperConfiguration GetConfigToDTO()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<Quiz, QuizDTO>();
                cfg.CreateMap<Answer, AnswerDTO>();
                cfg.CreateMap<Review, ReviewDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
        }

        public static MapperConfiguration GetConfigFromDTO()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<QuizDTO, Quiz>();
                cfg.CreateMap<AnswerDTO, Answer>();
                cfg.CreateMap<ReviewDTO, Review>();
                cfg.CreateMap<CommentDTO, Comment>();
            });
        }
    }
}
