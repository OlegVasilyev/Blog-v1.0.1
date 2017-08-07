using Ninject;
using System.Data.Entity;
using Ninject.Web.Common;
using BusinessLogicLayer.Service;
using BusinessLogicLayerInterfaces.Interfaces;
using DataAccessLayerSQL.Repositories;
using Entities.Models;
using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;

namespace DependencyResolver
{
    static public class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            //repository
            kernel.Bind<DbContext>().To<BlogContext>().InRequestScope();
            kernel.Bind<DbContext>().To<BlogContext>().InRequestScope();
            kernel.Bind<IBlogRepository>().To<BlogRepositories>().InRequestScope();
            //service 
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IQuizService>().To<QuizService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IReviewService>().To<ReviewService>();
            kernel.Bind<ICommentService>().To<CommentService>();
        }
    }
}
