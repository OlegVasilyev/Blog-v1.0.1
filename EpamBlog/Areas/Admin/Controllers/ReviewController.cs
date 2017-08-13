using AutoMapper;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using ValidationLayer.Infrastructure;

namespace EpamBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReviewController : Controller
    {
        readonly IReviewService _reviewService;
        public ReviewController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ReviewDTO, Review>();
            });
            var mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }

        [HttpPost]
        public ActionResult DeleteReview(string id)
        {
            try
            {
                _reviewService.DeleteReview(id);
            }
            catch (ValidationException) { }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = config.CreateMapper();
            return PartialView("Partials/ReviewList", mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }
    }
}