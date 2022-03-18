using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.EntityFrameworkCore.Identity.Extensions;

namespace UniClub.EntityFrameworkCore.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Person> _userManager;
        private readonly IUserClaimsPrincipalFactory<Person> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<Person> userManager,
            IUserClaimsPrincipalFactory<Person> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService)
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id.ToString() == userId);

            return user.UserName;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new Person
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id.ToString());
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(Person user, string password)
        {
            if (user.Email != null)
            {
                var u = await _userManager.FindByEmailAsync(user.Email);
                if (u != null)
                {
                    return (Result.Failure(new List<string>() { "User has already existed" }), null);
                }
            }

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id.ToString());
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user != null && await _userManager.IsInRoleAsync(user, role);
        }

        public async Task AddToRoleAsync(string userId, string role)
        {
            if (!await IsInRoleAsync(userId, role))
            {
                var user = await _userManager.FindByIdAsync(userId);
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        public async Task<Result> DeleteUserAsync(Person user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<Result> UpdateUserAsync(string userId, Person updatedUser)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);
            if (user == null)
            {
                return Result.Failure(new List<string>() { "User does not exist" });
            }
            var updated = UpdateEntityWithInDatabase(user, updatedUser);
            return await UpdateUserAsync(updated);
        }

        public async Task<Result> UpdateUserAsync(Person user)
        {
            var result = await _userManager.UpdateAsync(user);

            return result.ToApplicationResult();
        }

        protected virtual Person UpdateEntityWithInDatabase(Person entity, Person updatedEntity)
        {
            foreach (var inDatabaseProperty in entity.GetType().GetProperties())
            {
                if (!inDatabaseProperty.Name.Equals("Id"))
                {
                    var entityValue = updatedEntity.GetType().GetProperty(inDatabaseProperty.Name).GetValue(updatedEntity);
                    {
                        if (entityValue != null && entityValue != default)
                        {
                            updatedEntity.GetType().GetProperty(inDatabaseProperty.Name).SetValue(entity, entityValue);
                        }
                    }
                }
            }
            return entity;
        }
    }
}

