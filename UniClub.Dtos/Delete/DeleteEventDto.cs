using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteEventDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteEventDto(int id)
        {
            Id = id;
        }
    }
}
