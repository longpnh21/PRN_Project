using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UniClub.Domain.Entities;

namespace UniClub.EntityFrameworkCore
{
    public static class UniClubDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("SystemAdministrator");

            var schoolAdmin = new IdentityRole("SchoolAdmin");

            var student = new IdentityRole("Student");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }
            if (roleManager.Roles.All(r => r.Name != schoolAdmin.Name))
            {
                await roleManager.CreateAsync(schoolAdmin);
            }
            if (roleManager.Roles.All(r => r.Name != student.Name))
            {
                await roleManager.CreateAsync(student);
            }

            var administrator = new Person() { UserName = "admin", Email = "administrator@uniclub.com", Name = "admin" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                var result = await userManager.CreateAsync(administrator, "~d[3f6mz)yxx'D=y");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(UniClubContext context)
        {
            // Seed, if necessary

            //await context.SaveChangesAsync();

        }
    }
}
