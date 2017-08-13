using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class IdEntity
    {
       
        [Key]
        [ScaffoldColumn(false)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
