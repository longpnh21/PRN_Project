using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace UniClub.Dtos.Create
{
    public class CreateUniversityDto : IRequest<int>
    {
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
