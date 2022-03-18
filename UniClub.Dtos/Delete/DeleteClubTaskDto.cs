using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubTaskDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteClubTaskDto(int id)
        {
            Id = id;
        }
    }
}
