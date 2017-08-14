using BusinessLogicLayerInterfaces.DataTransferObjects;
using BusinessLogicLayerInterfaces.Interfaces;
using EpamBlog.MapperWeb;
using EpamBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ValidationLayer.Infrastructure;

namespace EpamBlog.Controllers
{
    public class ReviewsController : Controller
    {
        readonly IReviewService _reviewService;
        public ReviewsController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
            return View(mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews()));
        }

        [HttpPost]
        public ActionResult Index(Review review)
        {
            
            var mapper = MapperConfigWeb.GetConfigToDTO().CreateMapper();

            try
            {
                review.Id = Guid.NewGuid().ToString();
                review.Date = DateTime.UtcNow;
                var reviewDto = mapper.Map<ReviewDTO>(review);
                _reviewService.CreateReview(reviewDto);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property,ex.Message);
            }
            mapper = MapperConfigWeb.GetConfigFromDTO().CreateMapper();
            var model = mapper.Map<IEnumerable<Review>>(_reviewService.GetReviews());
            return PartialView("Partials/ReviewList", model);
        }
    }
}