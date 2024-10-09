
namespace CarListApp.Extensions
{
    public static class AddHttpClientExtension
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services)
        {
            var baseAddress = new Uri("http://carlist.somee.com");
            return services.AddTransient(hc => new HttpClient()
            { 
                BaseAddress = baseAddress
            });
        }
    }
}
