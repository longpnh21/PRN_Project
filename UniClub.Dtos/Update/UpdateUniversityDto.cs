using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace UniClub.Dtos.Update
{
    public class UpdateUniversityDto : IRequest<int>
    {
        [Required]
        public int Id { get; set; }
        public string UniName { get; set; }
        public string UniAddress { get; set; }
        public string UniPhone { get; set; }
        public IFormFile UploadedLogo { get; set; }
        public string LogoUrl { get; set; }
        public string Slogan { get; set; }
        public DateTime EstablishedDate { get; set; }
        public string Website { get; set; }
        public string ShortName { get; set; }
    }
}
