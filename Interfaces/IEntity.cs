using MongoDB.Bson;

namespace ProjectApi.Interfaces
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}
