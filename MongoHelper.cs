using System;
using System.Xml.Linq;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using EventManagement.Models;

namespace EventManagement.DataLayer
{
	public class MongoHelper<T> where T:Event,IMongoHelper
	{
        private readonly IConfiguration _configuration;
        private readonly string _dbName;

        public MongoHelper(IConfiguration config)
        {
            _configuration = config;
            _dbName = _configuration.GetValue<string>("DBName");
        }

        


    public IMongoDatabase GetMongoDbInstance(string _dbName)
        {
            var connString = _configuration.GetConnectionString("MongoDB");
            var client = new MongoClient(connString);
            var db = client.GetDatabase(_dbName);
            return db;
        }

        private IMongoCollection<T> GetCollection<T>(string _dbName,string collectionName)
        {
            
            return GetMongoDbInstance(_dbName).GetCollection<T>(collectionName);
        }



    public async Task<Event> CreateDocument<Event>(string collectionName, Event document)
        {
            var collection = GetCollection<Event>(_dbName, collectionName);
           // var doc=new BsonDocument { {"EventId":document.EventId,"Name":document.Name } }
            await collection.InsertOneAsync(document);
            var Filter = Builders<Event>.Filter.Eq("Name","Developer Day");
            return await collection.Find<Event>(Filter).FirstOrDefaultAsync();
        }

        public Task DeleteDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllDocuments<T>(string collectionName)
        {
            var collection = GetCollection<T>(_dbName, collectionName);
            return await collection.Find(x => true).ToListAsync();
        }

        public Task<List<T>> GetFilteredDocuments<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> document)
        {
            throw new NotImplementedException();
        }
    }
}

