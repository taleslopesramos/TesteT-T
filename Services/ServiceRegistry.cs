using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services;
public static class ServiceRegistry
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services.AddScoped<IUsuarioService, UsuarioService>();   

    }
}
