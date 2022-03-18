using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubTaskByIdDto : IRequest<ClubTaskDto>
    {
        public int Id { get; }
        public GetClubTaskByIdDto(int id)
        {
            Id = id;
        }
    }
}
