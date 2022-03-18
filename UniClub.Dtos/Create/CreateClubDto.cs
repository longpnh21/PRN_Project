using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Create
{
    public class CreateClubDto : IRequest<int>
    {
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        [Required]
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        public IFormFile UploadedAvatar { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }
    }
}
