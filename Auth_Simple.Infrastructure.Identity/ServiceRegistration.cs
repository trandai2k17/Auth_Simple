using Application.Interfaces;
using Auth_Simple.Infrastructure.Identity.DBContext;
using Auth_Simple.Infrastructure.Identity.Models;
using Auth_Simple.Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Simple.Infrastructure.Identity
{
    public static class ServiceRegistrationExtensions
    {
        public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppConn")));
        }

        public static void AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            })
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();
        }

        public static void AddInfrastructureIdentity(this IServiceCollection services)
        {
            //services.AddScoped<DapperDBContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

        }

    }
}
