using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class LoadingPage : ContentPage
{
	private readonly LoadingPageViewModel _viewModel;
	public LoadingPage(LoadingPageViewModel viewModel)
	{
		_viewModel = viewModel;
		BindingContext = _viewModel;
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		await _viewModel.CheckUserCredentialsCommand.ExecuteAsync(null);
    }
}