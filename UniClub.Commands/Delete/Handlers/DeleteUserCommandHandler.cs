using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Domain.Common.Interfaces;
using UniClub.Domain.Entities;
using UniClub.Dtos.Delete;

namespace UniClub.Commands.Delete.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserDto, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<Person> _userManager;

        public DeleteUserCommandHandler(IApplicationDbContext applicationDbContext, UserManager<Person> userManager)
        {
            _context = applicationDbContext;
            _userManager = userManager;
        }
        public async Task<int> Handle(DeleteUserDto request, CancellationToken cancellationToken)
        {

            var student = await _context.People.FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);
            try
            {
                if (student != null)
                {
                    _context.People.Remove(student);
                }
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
