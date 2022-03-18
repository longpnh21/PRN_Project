using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteUserDto : IRequest<int>
    {
        public string Id { get; }
        public DeleteUserDto(string id)
        {
            Id = id;
        }
    }
}