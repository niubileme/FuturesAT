using Infrastructure.Configurations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mongo
{
    public class MongoHelper
    {
        private static readonly object _obj = new object();

        private static MongoHelper _instance;
        public static MongoHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                            _instance = new MongoHelper();
                    }
                }
                return _instance;
            }

        }

        public readonly string _constr;
        public readonly string _dbName;
        private readonly MongoClient _client;

        private MongoHelper()
        {
            _constr = Config.GetStringValue("MongoConnectionString");
            _dbName = Config.GetStringValue("MongoDefaultDBName");

            _client = new MongoClient(_constr);

        }

        public bool TestConnect()
        {
            //测试连接
            try
            {
                var dbs = _client.ListDatabaseNames().ToList();
                if (dbs.Count == 0)
                {
                    throw new Exception("Mongodb Database Count:0");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Mongodb连接失败：{0}\r\n{1}", ex.Message, ex.StackTrace));
            }
        }

        public IMongoDatabase GetDb()
        {
            return GetDb(_dbName);
        }

        public IMongoDatabase GetDb(string dbName)
        {
            return _client.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return GetCollection<T>(_dbName, collectionName);
        }

        public IMongoCollection<T> GetCollection<T>(string dbName, string collectionName)
        {
            return GetDb(dbName).GetCollection<T>(collectionName);
        }


    }
}
