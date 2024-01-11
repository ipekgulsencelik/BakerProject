﻿using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.WebUI.Mediator.Commands.TeamCommands
{
    public class UpdateTeamCommand : IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string? TeamFullName { get; set; }
        public string? TeamImageURL { get; set; }
        public string? TeamTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}