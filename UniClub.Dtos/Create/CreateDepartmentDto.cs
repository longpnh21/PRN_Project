using MediatR;

namespace UniClub.Dtos.Create
{
    public class CreateDepartmentDto : IRequest<int>
    {
        public int UniId { get; set; }
        public string DepName { get; set; }
        public string ShortName { get; set; }
    }
}
