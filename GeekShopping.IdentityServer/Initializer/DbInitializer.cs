using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Identity;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<ApplicationUser> __role;

        public DbInitializer(MySQLContext context, UserManager<ApplicationUser> user, RoleManager<ApplicationUser> role)
        {
            _context = context;
            _user = user;
            __role = role;
        }

        public void Initialize()
        {
            if (__role.FindByNameAsync(IdentityConfiguration.Admin).Result != null)
            {
                return;
            }
            __role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            __role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();
        }
    }
}
