using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubPeriodByIdDto : IRequest<ClubPeriodDto>
    {
        public int Id { get; }
        public GetClubPeriodByIdDto(int id)
        {
            Id = id;
        }
    }
}
