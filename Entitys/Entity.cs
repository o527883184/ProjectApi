using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectApi.Interfaces;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    [BsonIgnoreExtraElements]
    public abstract class Entity : IEntity
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("createuserid")]
        public string CreateUserId { get; set; }
        [BsonElement("createusername")]
        public string CreateUserName { get; set; }
        [BsonElement("createdatetime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateDateTime { get; set; }
        [BsonElement("updateuserid")]
        public string UpdateUserId { get; set; }
        [BsonElement("updateusername")]
        public string UpdateUserName { get; set; }
        [BsonElement("updatedatetime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdateDateTime { get; set; }
    }
}
