﻿using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.WebUI.Mediator.Commands.TestimonialCommands
{
    public class UpdateTestimonialCommand : IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string? TestimonialFullName { get; set; }
        public string? TestimonialComment { get; set; }
        public string? TestimonialImageURL { get; set; }
        public string? TestimonialTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}