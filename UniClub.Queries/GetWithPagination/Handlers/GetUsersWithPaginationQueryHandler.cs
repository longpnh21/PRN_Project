using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common;
using UniClub.Domain.Common.Enums;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Response;
using UniClub.Queries.GetWithPagination.Specifications;
using UniClub.Repositories.Interfaces;
using UniClub.Specifications;

namespace UniClub.Queries.GetWithPagination.Handlers
{
    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationDto, PaginatedList<UserDto>>
    {
        private readonly UserManager<Person> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetUsersWithPaginationQueryHandler(UserManager<Person> userManager, IUserRepository userRepository, IMapper mapper, IApplicationDbContext context)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;

        }

        public async Task<PaginatedList<UserDto>> Handle(GetUsersWithPaginationDto request, CancellationToken cancellationToken)
        {
            var result = new List<UserDto>();
            int count = 0;
            List<Person> joinResult = new List<Person>();
            switch (request.GetRole())
            {
                case Role.Student:
                    var usersInStudent = await _userManager.GetUsersInRoleAsync(request.GetRole().ToString());

                    var students = await SpecificationEvaluator<Person>.GetQuery(_context.People.AsQueryable(), new GetStudentsWithPaginationSpecification(request)).ToListAsync();

                    joinResult = (from student in students
                                  join user in usersInStudent on student.Id equals user.Id
                                  select student).ToList();

                    result = joinResult.Select(e => _mapper.Map<UserDto>(e)).ToList();
                    count = joinResult.Count();
                    break;
                case Role.SystemAdministrator:
                    var usersInSystemAdministrator = await _userManager.GetUsersInRoleAsync(request.GetRole().ToString());

                    var systemAdministrators = await SpecificationEvaluator<Person>.GetQuery(_context.People.AsQueryable(), new GetStudentsWithPaginationSpecification(request)).ToListAsync();

                    joinResult = (from systemAdministrator in systemAdministrators
                                  join user in usersInSystemAdministrator on systemAdministrator.Id equals user.Id
                                  select systemAdministrator).ToList();

                    result = joinResult.Select(e => _mapper.Map<UserDto>(e)).ToList();
                    count = joinResult.Count();
                    break;
                case Role.SchoolAdmin:
                    var usersInSchoolAdmin = await _userManager.GetUsersInRoleAsync(request.GetRole().ToString());

                    var schoolAdmins = await SpecificationEvaluator<Person>.GetQuery(_context.People.AsQueryable(), new GetStudentsWithPaginationSpecification(request)).ToListAsync();

                    joinResult = (from schoolAdmin in schoolAdmins
                                  join user in usersInSchoolAdmin on schoolAdmin.Id equals user.Id
                                  select schoolAdmin).ToList();

                    result = joinResult.Select(e => _mapper.Map<UserDto>(e)).ToList();
                    count = joinResult.Count();
                    break;
                default:
                    var users = await _userRepository.GetListAsync(cancellationToken, new GetUsersWithPaginationQuerySpecification(request));
                    result = users.Items.Select(e => _mapper.Map<UserDto>(e)).ToList();
                    count = users.Count;
                    break;
            }

            return new PaginatedList<UserDto>(result, count, request.PageNumber, request.PageSize);
        }
    }
}
