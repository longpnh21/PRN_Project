using Microsoft.Extensions.Logging;
using Quartz;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;

namespace UniClub.Worker.Jobs
{
    [DisallowConcurrentExecution]
    public class UpdateClubMemberCountJob : IJob
    {
        private readonly ILogger<UpdateClubMemberCountJob> _logger;
        private readonly IClubRepository _clubRepository;

        public UpdateClubMemberCountJob(ILogger<UpdateClubMemberCountJob> logger, IClubRepository repository)
        {
            _logger = logger;
            _clubRepository = repository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogDebug("Executing UpdateClubMemberCountJob");
            CancellationToken cancellationToken = CancellationToken.None;
            var specification = new ClubSpecification();
            var clubs = await _clubRepository.GetListAsync(cancellationToken, specification);

            foreach (var club in clubs.Items)
            {
                var dummy = new Club();
                dummy.MemberCount = club.ClubPeriods.FirstOrDefault(p => !p.IsDeleted && p.IsPresent).MemberRoles.Count;
                await _clubRepository.UpdateAsync(club, dummy, cancellationToken);
            }
            return;
        }
    }

    public class ClubSpecification : BaseSpecification<Club>
    {
        public ClubSpecification() : base()
        {
            SetFilterCondition(e => e.IsDeleted == false);

            AddInclude("ClubPeriods.MemberRoles");
        }
    }
}
