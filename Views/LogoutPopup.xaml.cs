using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class LogoutPopup : ContentPage
{
	public LogoutPopup(LogoutPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}