using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetEventByIdDto : IRequest<EventDto>
    {
        public int Id { get; }
        public GetEventByIdDto(int id)
        {
            Id = id;
        }
    }
}
