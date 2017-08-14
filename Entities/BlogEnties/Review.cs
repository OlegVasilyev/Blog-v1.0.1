using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Entities.Models
{
    public class Review : IdEntity
    {
        public string Authorname { get; set; }
        public string Text { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
}