using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class RegistryDbContext
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, string connectString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectString))
                    .AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}
