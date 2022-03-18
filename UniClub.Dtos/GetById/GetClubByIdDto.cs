using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetClubByIdDto : IRequest<ClubDto>
    {
        public int Id { get; }
        public GetClubByIdDto(int id)
        {
            Id = id;
        }
    }
}
