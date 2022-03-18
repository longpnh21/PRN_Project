using System;

namespace UniClub.Dtos.Response
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public int? DepId { get; set; }
        public string DepName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
