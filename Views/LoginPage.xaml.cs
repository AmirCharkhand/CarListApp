using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewmodel viewmodel)
	{
		BindingContext = viewmodel;
		InitializeComponent();
	}
}