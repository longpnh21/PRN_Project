using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetUniversityByIdDto : IRequest<UniversityDto>
    {
        public int Id { get; }
        public GetUniversityByIdDto(int id)
        {
            Id = id;
        }
    }
}
