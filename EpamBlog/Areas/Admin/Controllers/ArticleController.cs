using AutoMapper;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ValidationLayer.Infrastructure;

namespace EpamBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        readonly IArticleService _articleService;
        public ArticleController(IArticleService service)
        {
            _articleService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>().ForMember(c => c.Comments, i => i.Ignore());
            });
            var mapper = config.CreateMapper();

            return View(mapper.Map<IEnumerable<Article>>(_articleService.GetArticles()));
        }

        [HttpPost]
        public ActionResult Index(Article article)
        {
            var configView = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>().ForMember(c => c.Comments, i => i.Ignore());
            });
            var configDto = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>().ForMember(c => c.Comments, i => i.Ignore());
            });
            var mapper = configDto.CreateMapper();

            try
            {
                article.Id = Guid.NewGuid().ToString();
                article.Date = DateTime.UtcNow;
                if (article.Tags != null && article.Tags.Count > 0)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var tags = article.Tags.FirstOrDefault().Split(' ');
                    article.Tags.Clear();
                    foreach (var tag in tags)
                    {
                        if (tag.Trim() == string.Empty) continue;
                        article.Tags.Add(tag.Trim());
                    }
                }
                var articleDto = mapper.Map<ArticleDTO>(article);
                _articleService.CreateArticle(articleDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            mapper = configView.CreateMapper();
            var model = mapper.Map<IEnumerable<Article>>(_articleService.GetArticles());
            return PartialView("Partials/ArticleList", model);
        }

        [HttpPost]
        public ActionResult DeleteArticle(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                _articleService.DeleteArticle(id);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ArticleDTO, Article>();
                });
                var mapper = config.CreateMapper();
                return PartialView("Partials/ArticleList",
                    mapper.Map<IEnumerable<Article>>(_articleService.GetArticles()));
            }
            catch (ValidationException ex)
            {
                return PartialView("ErrorPartial", ex);
            }
        }
    }
}