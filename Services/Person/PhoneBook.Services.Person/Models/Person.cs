using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBook.Services.MsPerson.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }

    }
}
