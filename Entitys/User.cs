using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{

    [BsonIgnoreExtraElements]
    public class User : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
