using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.Models
{
    public class Comment : IdEntity
    {
        public string Text { get; set; }
        public string User { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
        public string IdArticle { get; set; }

    }
}
