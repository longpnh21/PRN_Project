using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UniClub.Domain.Common.Enums;

namespace UniClub.Dtos.Create
{
    public class CreateUserDto : IRequest<string>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? DepId { get; set; }
        public string Password { get; set; }
        public IFormFile UploadedImage { get; set; }
        [JsonIgnore]
        public string ImageUrl { get; set; }
        public Role Role { get; set; }
    }
}
