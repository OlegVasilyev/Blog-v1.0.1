using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EpamBlog.ViewModels;
using ValidationLayer.Infrastructure;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.MapperWeb;

namespace EpamBlog.Controllers
{
    public class HomeController : Controller
    {
        IArticleService _articleService;
        public HomeController(IArticleService service)
        {
            this._articleService = service;
        }
       [HttpGet]
       public ActionResult Index()
        {
            var mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
            return View(mapper.Map<IEnumerable<Article>>(_articleService.GetArticles()));
        }
        [HttpGet]
        public ActionResult DisplayArticle(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            try
            {
                var article = _articleService.GetArticle(id);
                var mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
                return View(mapper.Map<Article>(article));
            }
            catch (ValidationException ex)
            {
                return View("Error", ex);
            }

        }

        [HttpGet]
        public ActionResult Search(string tag)
        {
            if (tag == null)
            {
                tag = "";
            }
            try
            {
                var articles = _articleService.GetArticles(tag);
                var mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
                var articlesView = mapper.Map<IEnumerable<Article>>(articles);
                return View(new SearchByTag { Articles = articlesView.ToList(), TagText = tag });
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

        }
    }
}