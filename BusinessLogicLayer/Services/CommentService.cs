using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DataTransferObjects;
using DataAccessLayerInterfaces.Interfaces;
using BusinessLogicLayer.Infrastructure;
using AutoMapper;
using Entities.Models;

namespace BusinessLogicLayer.Service
{
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

        public void DeleteComment(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Id is null", "");
            if (!DataBase.Articles.Find(x => x.Id == Id).Any())
                throw new ValidationException("Comment wasn't found", "");

            DataBase.Comments.Delete((int)Id);
            DataBase.Save();
        }

        public IEnumerable<CommentDTO> GetComments(int? Id)
        {
            var article = DataBase.Articles.Get(Id.Value);
            if (article == null)
                return null;

            var mapper = MapperConfig.GetConfigToDTO().CreateMapper();
            return mapper.Map<IEnumerable<CommentDTO>>(article.Comments);

        }

        public void UpdateComment(CommentDTO commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
