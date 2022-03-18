using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubRoleDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteClubRoleDto(int id)
        {
            Id = id;
        }
    }
}
