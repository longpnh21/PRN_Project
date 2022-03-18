using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteUniversityDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteUniversityDto(int id)
        {
            Id = id;
        }
    }
}
