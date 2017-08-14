using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Infrastructure;
using Entities.Models;
using BusinessLogicLayerInterfaces.Interfaces;
using BusinessLogicLayerInterfaces.DataTransferObjects;
using DataAccessLayerInterfaces.Repository;
using ValidationLayer.Infrastructure;

namespace BusinessLogicLayer.Service
{
    /// <summary>
    /// Class for working with comment
    /// </summary>
    public class CommentService : ICommentService
    {
        IBlogRepository DataBase { get; }
        public CommentService(IBlogRepository database)
        {
            this.DataBase = database;
        }
        public void CreateComment(CommentDTO commentDto)
        {
            ValidatorBlogModels.ValidateCommentModel(commentDto);
            var article = DataBase.Articles.Get(commentDto.IdArticle);
            var mapper = MapperConfig.GetConfigFromDTO().CreateMapper();
            var commentNew = mapper.Map<Comment>(commentDto);
            DataBase.Comments.Create(commentNew);
            DataBase.Save();
        }

        public void DeleteComment(string Id)
        {
            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Articles.Find(x => x.Id == Id).Any())
                throw new ValidationException("Comment wasn't found", "");

            DataBase.Comments.Delete(Id);
            DataBase.Save();
        }

        public IEnumerable<CommentDTO> GetComments(string Id)
        {
            var mapper = MapperConfig.GetConfigToDTO().CreateMapper();
            return mapper.Map<IEnumerable<CommentDTO>>(DataBase.Comments.Find(x=>x.IdArticle==Id));
        }

        public void UpdateComment(CommentDTO commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
