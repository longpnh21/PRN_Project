using System;

namespace UniClub.Dtos.Response
{
    public class ClubDto
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int UniId { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime EstablishedDate { get; set; }
        public int MemberCount { get; set; }
        public string Slogan { get; set; }
        public bool IsDeleted { get; set; }
    }
}
