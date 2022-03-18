using MediatR;

namespace UniClub.Dtos.Delete
{
    public class DeleteClubPeriodDto : IRequest<int>
    {
        public int Id { get; }
        public DeleteClubPeriodDto(int id)
        {
            Id = id;
        }
    }
}
