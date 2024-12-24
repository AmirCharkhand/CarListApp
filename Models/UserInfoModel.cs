
namespace CarListApp.Models
{
    public class UserInfoModel(string id, string userName, string role, string eMail, bool eMailConfirmed)
    {
        public string Id { get; init; } = id;
        public string UserName { get; init; } = userName;
        public string Role { get; init; } = role;
        public string EMail { get; init; } = eMail;
        public bool EMailConfirmed { get; init; } = eMailConfirmed;
    }
}
