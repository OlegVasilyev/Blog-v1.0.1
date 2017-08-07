using BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDTO> GetComments(int? Id);
        void CreateComment(CommentDTO commentDto);
        void UpdateComment(CommentDTO commentDto);
        void DeleteComment(int? Id);
    }
}
