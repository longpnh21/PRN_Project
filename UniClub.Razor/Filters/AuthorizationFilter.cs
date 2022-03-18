using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Domain.Entities;
using UniClub.Razor.Utils;

namespace UniClub.Razor.Filters
{
    public class AuthorizationFilter : ResultFilterAttribute
    {

        public AuthorizationFilter()
        {

        }

        public string Roles { get; set; } = string.Empty;
        public string Policy { get; set; } = string.Empty;

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var user = SessionHelper.GetObjectFromJson<Person>(context.HttpContext.Session, "user");
            if (user == null)
            {
                context.Result = new RedirectToPageResult("/Permission");
            }
            else if (!string.IsNullOrEmpty(Roles))
            {
                var roles = SessionHelper.GetObjectFromJson<List<string>>(context.HttpContext.Session, "roles");
                if (!roles.Any(r => Roles.ToLower().Contains(r.ToLower())))
                {
                    context.Result = new RedirectToPageResult("/Permission");
                }
            }
            await next();
        }

    }
}
