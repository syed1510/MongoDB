using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EventManagement.Models
{
	public class Event
	{

		[BsonId]
		public ObjectId _id { get; set; }
		public int EventId { get; set; }
		public string Name { get; set; }



	}
}

