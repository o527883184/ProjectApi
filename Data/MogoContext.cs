using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace ProjectApi.Data
{
    /// <summary>
    /// 数据上下文
    /// </summary>
    public class MogoContext
    {
        private readonly IConfiguration _configuration;
        //private readonly IMongoDatabaseSettings _settings;

        private IMongoDatabase Database { get; set; }
        public MogoContext(IConfiguration configuration)
        {
            _configuration = configuration;

            // 数据库的连接池
            var client = new MongoClient(_configuration.GetSection("MongoConnection:ConnectionString").Value);
            // 获取数据库
            Database = client.GetDatabase(_configuration.GetSection("MongoConnection:Database").Value);
        }

        // 获取集合
        public IMongoCollection<T> GetCollection<T>(string name) => Database.GetCollection<T>(name);
    }
}
