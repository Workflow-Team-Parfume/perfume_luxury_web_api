using Core;
using Core.Interfaces;
using Infrustructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure
{
    public static class ServiceExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static void AddDbContext(this IServiceCollection services, string connStr)
        {
            services.AddDbContext<RecipeDbContext>(opt => opt.UseSqlServer(connStr));
        }
        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RecipeDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
