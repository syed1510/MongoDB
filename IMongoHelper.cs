using System;
using System.Collections.Generic;
using MongoDB.Driver;


namespace EventManagement.DataLayer
{
	public interface IMongoHelper
	{
        Task<List<T>> GetAllDocuments<T>(string collectionName);
//        Task<List<T>> GetFilteredDocuments<T>(string dbName, string collectionName, FilterDefinition<T> filter);
//​		Task UpdateDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> document);
		Task<T> CreateDocument<T>(string collectionName, T document);
//​		Task DeleteDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter);

    }
}

