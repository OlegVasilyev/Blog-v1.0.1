using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace BusinessLogicLayerInterfaces.DataTransferObjects
{
    public class AnswerDTO
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int QuestionId { get; set; }
        public string  Text { get; set; }
        [DisplayName("Votes Count")]
        public int VotesCount { get; set; }

    }
}