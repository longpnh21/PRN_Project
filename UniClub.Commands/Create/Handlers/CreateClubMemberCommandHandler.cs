using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Dtos.Create;
using UniClub.Repositories.Interfaces;

namespace UniClub.Commands.Create.Handlers
{
    public class CreateClubMemberCommandHandler : IRequestHandler<CreateClubMemberDto, int>
    {
        private readonly IMemberRoleRepository _memberRoleRepository;
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;

        public CreateClubMemberCommandHandler(IMemberRoleRepository memberRoleRepository, UserManager<Person> userManager, IMapper mapper)
        {
            _memberRoleRepository = memberRoleRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClubMemberDto request, CancellationToken cancellationToken)
        {
            var result = await _userManager.FindByIdAsync(request.MemberId);
            if (result == null)
            {
                throw new Exception("No student found");
            }
            return await _memberRoleRepository.CreateAsync(_mapper.Map<MemberRole>(request), cancellationToken);
        }
    }
}
