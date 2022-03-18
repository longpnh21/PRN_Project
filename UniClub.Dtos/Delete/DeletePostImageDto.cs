using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeletePostImageDto : IRequest<int>
    {
        public int Id { get; }
        public DeletePostImageDto(int id)
        {
            Id = id;
        }
    }
}
