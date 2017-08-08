using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    /// <summary>
    /// Interface for working with Review
    /// </summary>
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviews();
        void CreateReview(ReviewDTO reviewDto);
        void DeleteReview(int? Id);
    }
}
