namespace UniClub.Dtos.Response
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
