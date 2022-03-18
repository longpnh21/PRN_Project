using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteClubDto(int id)
        {
            Id = id;
        }
    }
}
