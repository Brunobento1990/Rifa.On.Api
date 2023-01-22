using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rifa_On.Models;

namespace Rifa_On.Data.Repositorys
{
    public class ApiDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}
