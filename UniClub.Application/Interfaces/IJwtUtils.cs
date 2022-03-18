using System.Collections.Generic;
using System.Security.Claims;
using UniClub.Domain.Entities;

namespace UniClub.Application.Interfaces
{
    public interface IJwtUtils
    {
        string GenerateToken(Person user, IList<Claim> claims);
        string ValidateToken(string token);
    }
}
