using CarListApp.ViewModels;

namespace CarListApp.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}