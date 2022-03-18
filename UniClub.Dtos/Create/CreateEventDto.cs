using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateEventDto : IRequest<int>
    {
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Point { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public IFormFile UploadedImage { get; set; }
        [JsonIgnore]
        public string ImageUrl { get; set; }
        public EventStatus Status { get; set; }
        public bool IsPrivate { get; set; }
    }
}
