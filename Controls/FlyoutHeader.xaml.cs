
using CarListApp.Models;

namespace CarListApp.Controls;

public partial class FlyoutHeader : StackLayout
{
	private readonly UserInfoModel _userInfo;
	public FlyoutHeader(UserInfoModel userInfo)
	{
        _userInfo = userInfo;
		InitializeComponent();
		SetValues();
	}

	private void SetValues()
	{
		lblWelcomeMessage.Text = $"Welcome {_userInfo.UserName}";
		lblUserRole.Text = $"Signed in as {_userInfo.Role}";
	}
}