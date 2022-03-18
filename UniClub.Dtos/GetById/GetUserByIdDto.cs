using MediatR;
using UniClub.Dtos.Response;

namespace UniClub.Dtos.GetById
{
    public class GetUserByIdDto : IRequest<UserDto>
    {
        public string Id { get; }
        public GetUserByIdDto(string id)
        {
            Id = id;
        }

    }
}
