using CarListApp.Models;
using CarListApp.Services.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;

namespace CarListApp.Services.Core
{
    public class AuthService(UriBuilderService uriBuilder, IHttpClientFactory httpClientFactory, UserService user)
    {
        private readonly UriBuilderService _uriBuilder = uriBuilder;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly UserService _user = user;

        private HttpClient HttpClient => _httpClientFactory.CreateClient("UnAuthorized");

        public async Task Login(LoginModel login)
        {
            var response = await HttpClient.PostAsJsonAsync<LoginModel>(_uriBuilder.GetLoginUri(), login);
            response.EnsureSuccessStatusCode();
            var userAuth = await response.Content.ReadFromJsonAsync<UserAuthModel>() ?? throw new NullReferenceException();
            EnsureIdCorrect(userAuth);
            await Task.WhenAll(SetJwtInSorage(userAuth), SetUserInfoInStorage(userAuth));
        }

        public void Logout()
        {
            SecureStorage.Remove("Jwt");
            Preferences.Remove("JwtExpiery");
            _user.RemoveUserDataFromStorage();
        }

        public async Task<bool> IsJwtValid()
        {
            var jwt = await SecureStorage.GetAsync("Jwt");
            var jwtExpiery = Preferences.Get("JwtExpiery", DateTime.MinValue);

            var isJwtValid = !(string.IsNullOrEmpty(jwt));
            var isJwtNotExpierd = (jwtExpiery - DateTime.UtcNow) > TimeSpan.FromMinutes(1);

            if (isJwtValid && isJwtNotExpierd) return true;

            Logout();
            return false;
        }

        private void EnsureIdCorrect(UserAuthModel userAuth)
        {
            var jwtId = userAuth.JwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;
            if (!string.Equals(userAuth.UserId, jwtId))
                throw new Exception("Invalid JWT");
        }

        private async Task SetJwtInSorage(UserAuthModel authModel)
        {
            await SecureStorage.SetAsync("Jwt", authModel.Jwt);
            Preferences.Set("JwtExpiery", authModel.JwtToken.ValidTo);
        }

        private async Task SetUserInfoInStorage(UserAuthModel userAuth)
        {
            var role = userAuth.JwtToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
            var eMail = userAuth.JwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
            var eMailConfirmed = bool.Parse(userAuth.JwtToken.Claims.First(claim => string.Equals(claim.Type, "email-confirmed")).Value);
            var userInfo = new UserInfoModel(userAuth.UserId, userAuth.UserName, role, eMail, eMailConfirmed);
            await _user.SetUserDataInStorage(userInfo);
        }
    }
}
