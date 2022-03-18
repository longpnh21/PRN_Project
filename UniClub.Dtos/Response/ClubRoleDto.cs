namespace UniClub.Dtos.Response
{
    public class ClubRoleDto
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public int? ReportToRoleId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
