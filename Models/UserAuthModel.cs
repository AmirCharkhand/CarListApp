
using System.IdentityModel.Tokens.Jwt;

namespace CarListApp.Models
{
    public class UserAuthModel
    {
        public JwtSecurityToken JwtToken { get; init; }
        public string UserId { get; init; }
        public string UserName { get; init; }
        public string Jwt { get; init; }

        public UserAuthModel(string userId, string userName, string jwt)
        {
            UserId = userId;
            UserName = userName;
            Jwt = jwt;
            JwtToken = new JwtSecurityTokenHandler().ReadJwtToken(Jwt) ?? throw new NullReferenceException();
        }
    }
}
