using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubRoleByIdDto : IRequest<ClubRoleDto>
    {
        public int Id { get; }
        public GetClubRoleByIdDto(int id)
        {
            Id = id;
        }
    }
}
