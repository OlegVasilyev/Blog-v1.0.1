using Ninject;
using System;
using System.Collections.Generic;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Service;
using System.Web.Mvc;

namespace EpamBlog.Ninject
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type servicetype)
        {
            return _kernel.TryGet(servicetype);
        }
        private void AddBindings()
        {
            _kernel.Bind<IArticleService>().To<ArticleService>();
            _kernel.Bind<IQuizService>().To<QuizService>();
            _kernel.Bind<IAnswerService>().To<AnswerService>();
            _kernel.Bind<IReviewService>().To<ReviewService>();
            _kernel.Bind<ICommentService>().To<CommentService>();

        }
        public IEnumerable<object> GetServices(Type servicetype)
        {
            return _kernel.GetAll(servicetype);
        }
    }
}