
using CarListApp.Exceptions;
using CarListApp.Services.Core;

namespace CarListApp.Handlers
{
    public class AuthenticationDelegatingHandler(AuthService authService) : DelegatingHandler
    {
        private readonly AuthService _authService = authService;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!await _authService.IsJwtValid())
                throw new JwtInvalidOrExpierdException();

            var jwt = await SecureStorage.GetAsync("Jwt");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",jwt);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
