using DataAccessLayerSQL.Context;
using DataAccessLayerInterfaces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayerInterfaces.Repository;

namespace DataAccessLayerSQL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogContext context;
        public CommentRepository(BlogContext context)
        {
            this.context = context;
        }
        public void Create(Comment item)
        {
            context.Comments.Add(item);
        }

        public void Delete(int Id)
        {
            var tag = context.Tags.Find(Id);
            context.Tags.Remove(tag);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return context.Comments.Where(predicate).ToList();
        }

        public Comment Get(int Id)
        {
            return context.Comments.Find(Id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments;
        }

        public void Update(Comment item)
        {
            var temp = context.Tags.Find(item.Id);
            if (temp != null)
            {
                context.Entry(temp).CurrentValues.SetValues(item);
                context.SaveChanges();
            }
        }
    }
}