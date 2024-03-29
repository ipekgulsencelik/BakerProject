﻿using Baker.EntityLayer.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Concrete
{
    public class Service : IMongoBaseEntity
    {
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsHome { get; set; }

        public string? OfferID { get; set; }

        [BsonIgnore]
        public Offer? Offer { get; set; }
    }
}