using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Update
{
    public class UpdateEventDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public int Point { get; set; }
        public int MaxParticipants { get; set; }
        public string Description { get; set; }
        public IFormFile UploadedImage { get; set; }
        public string ImageUrl { get; set; }
        public EventStatus Status { get; set; }
        public bool IsPrivate { get; set; }
    }
}
