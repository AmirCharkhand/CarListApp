
using CarListApp.Models;

namespace CarListApp.Services.Core
{
    public class UserService
    {
        private UserInfoModel? _userInfo;

        public async Task<UserInfoModel> GetUserInfo()
        {
            if (_userInfo != null) return _userInfo;

            var userId = Preferences.Get("UserId", string.Empty);
            var userName = Preferences.Get("UserName", string.Empty);
            var role = await SecureStorage.GetAsync("UserRole");
            var eMail = await SecureStorage.GetAsync("Email");
            var eMailConfirmedString = await SecureStorage.GetAsync("EMailConfirmed");

            if (string.IsNullOrEmpty(eMailConfirmedString) || string.IsNullOrEmpty(eMail) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userId))
                throw new ApplicationException("User Data not Set");

            _userInfo = new UserInfoModel(userId, userName, role, eMail, bool.Parse(eMailConfirmedString));
            return _userInfo;
        }

        public async Task SetUserDataInStorage(UserInfoModel userInfo)
        {
            await SecureStorage.SetAsync("EMail", userInfo.EMail);
            await SecureStorage.SetAsync("EMailConfirmed", userInfo.EMailConfirmed.ToString());
            await SecureStorage.SetAsync("UserRole", userInfo.Role);
            Preferences.Set("UserId", userInfo.Id);
            Preferences.Set("UserName", userInfo.UserName);

            _userInfo = userInfo;
        }

        public void RemoveUserDataFromStorage()
        {
            SecureStorage.Remove("EMail");
            SecureStorage.Remove("EMailConfirmed");
            SecureStorage.Remove("UserRole");
            Preferences.Remove("UserId");
            Preferences.Remove("UserName");

            _userInfo = null;
        }
    }
}
