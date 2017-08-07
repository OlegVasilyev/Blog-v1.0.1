using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviews();
        void CreateReview(ReviewDTO reviewDto);
        void DeleteReview(int? Id);
    }
}
