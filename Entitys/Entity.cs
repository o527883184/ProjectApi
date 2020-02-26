using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ProjectApi.Interfaces;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    public abstract class Entity : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
