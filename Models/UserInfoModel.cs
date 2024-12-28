
using CarListApp.Enums;

namespace CarListApp.Models
{
    public class UserInfoModel
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public UserRole Role { get; init; }
        public string EMail { get; init; }
        public bool EMailConfirmed { get; init; }

        public UserInfoModel(string id, string userName, string role, string eMail, bool eMailConfirmed)
        {
            Id = id;
            UserName = userName;
            Role = ConvertUserRole(role);
            EMail = eMail;
            EMailConfirmed = eMailConfirmed;
        }

        public UserInfoModel(string id, string userName, UserRole role, string eMail, bool eMailConfirmed)
        {
            Id = id;
            UserName = userName;
            Role = role;
            EMail = eMail;
            EMailConfirmed = eMailConfirmed;
        }

        private UserRole ConvertUserRole(string role)
        {
            switch (role)
            {
                case "Admin":
                    return UserRole.Admin;
                case "User":
                    return UserRole.User;
                default:
                    throw new ApplicationException("Unidentified user role");
            }
        }
    }
}
