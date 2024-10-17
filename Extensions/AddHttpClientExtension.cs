
using CarListApp.Services.Core;
using System.Linq;

namespace CarListApp.Extensions
{
    public static class AddHttpClientExtension
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services)
        {
            return services.AddTransient<HttpClient>();
        }
    }
}
