using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetDepartmentByIdDto : IRequest<DepartmentDto>
    {
        public int Id { get; }
        public GetDepartmentByIdDto(int id)
        {
            Id = id;
        }
    }
}
