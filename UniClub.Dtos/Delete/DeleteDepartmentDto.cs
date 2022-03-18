using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteDepartmentDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteDepartmentDto(int id)
        {
            Id = id;
        }
    }
}
