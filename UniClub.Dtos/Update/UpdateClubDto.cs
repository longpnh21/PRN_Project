using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateClubDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public IFormFile UploadedAvatar { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Slogan { get; set; }
    }
}
