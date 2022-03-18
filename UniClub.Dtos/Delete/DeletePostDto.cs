using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeletePostDto : IRequest<int>
    {
        public int Id { get; }
        public DeletePostDto(int id)
        {
            Id = id;
        }
    }
}
