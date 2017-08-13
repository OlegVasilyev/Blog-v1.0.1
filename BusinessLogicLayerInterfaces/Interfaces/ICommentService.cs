using BusinessLogicLayerInterfaces.DataTransferObjects;
using System.Collections.Generic;

namespace BusinessLogicLayerInterfaces.Interfaces
{
    /// <summary>
    /// Interface for working with Comment
    /// </summary>
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetComments(string Id);
        void CreateComment(CommentDTO commentDto);
        void UpdateComment(CommentDTO commentDto);
        void DeleteComment(string Id);
    }
}
