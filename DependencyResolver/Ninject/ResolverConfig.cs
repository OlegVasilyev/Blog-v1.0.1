using Ninject;
using System.Data.Entity;
using Ninject.Web.Common;
using BusinessLogicLayer.Service;
using BusinessLogicLayerInterfaces.Interfaces;
using DataAccessLayerSQL.Repositories;
using DataAccessLayerInterfaces.Repository;
using DataAccessLayerSQL.Context;
using AuthenticationLayerDAL.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using Entities.IdentityEnties;
using AuthenticationLayerBLL.Interface.Interfaces;
using AuthenticationLayerBLL.Services;
using AuthenticationLayerDAL.Interface.Interfaces;
using AuthenticationLayerDAL.Repositories;

namespace DependencyResolver.Ninject
{
    static public class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            //context
            kernel.Bind<DbContext>().To<BlogContext>().InRequestScope();
            kernel.Bind<IdentityDbContext<ApplicationUser>>().To<AuthenticationContext>();
            //repository, I know about Generic Repository but I decided to use patter UnitOfWork
            kernel.Bind<IBlogRepository>().To<BlogRepositories>();
            kernel.Bind<IAuthenticationRepository>().To<AuthenticationRepository>();
            //service 
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IQuizService>().To<QuizService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
            kernel.Bind<IReviewService>().To<ReviewService>();
            kernel.Bind<ICommentService>().To<CommentService>();
        }
    }
}
