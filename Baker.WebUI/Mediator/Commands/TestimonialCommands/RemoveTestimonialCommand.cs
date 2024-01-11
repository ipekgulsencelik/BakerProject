﻿using MediatR;

namespace Baker.WebUI.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveTestimonialCommand(string id)
        {
            Id = id;
        }
    }
}