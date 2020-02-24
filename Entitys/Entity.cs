using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    public abstract class Entity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
