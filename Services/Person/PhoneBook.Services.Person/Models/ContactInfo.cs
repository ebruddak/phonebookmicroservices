using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBook.Services.MsPerson.Models
{
    public class ContactInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string PersonID { get; set; }

        [BsonIgnore]
        public Person Person { get; set; }
        public InfoType Type { get; set; }
        public string Content { get; set; }

    }
}
