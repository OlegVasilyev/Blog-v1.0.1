using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Infrastructure;
using AutoMapper;
using Entities.Models;
using BusinessLogicLayerInterfaces.Interfaces;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using DataAccessLayerInterfaces.Repository;
using ValidationLayer.Infrastructure;

namespace BusinessLogicLayer.Service
{
    /// <summary>
    /// Class for working with Review
    /// </summary>
    public class ReviewService : IReviewService
    {
        IBlogRepository DataBase { get; }
        public ReviewService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void CreateReview(ReviewDTO reviewDto)
        {
            ValidatorBlogModels.ValidateReviewModel(reviewDto);
            Mapper.Initialize(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var reviewNew = Mapper.Map<Review>(reviewDto);
            DataBase.Reviews.Create(reviewNew);
            DataBase.Save();
        }

        public void DeleteReview(string Id)
        {
            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Reviews.Find(x => x.Id == Id).Any())
                throw new ValidationException("Review wasn't found", "");
            DataBase.Reviews.Delete(Id);
            DataBase.Save();
        }

        public IEnumerable<ReviewDTO> GetReviews()
        {
            var mapper = MapperConfig.GetConfigToDTO().CreateMapper();

            return mapper.Map<IEnumerable<ReviewDTO>>(DataBase.Reviews.GetAll());
        }

    }
}
