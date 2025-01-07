using CarListApp.ViewModels;

namespace CarListApp.Views
{
    public partial class CarListPage : ContentPage
    {
        private readonly CarListViewModel _viewModel;

        public CarListPage(CarListViewModel carListViewModel)
        {
            BindingContext = carListViewModel;
            _viewModel = carListViewModel;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await _viewModel.SetFlyoutMenuCommand.ExecuteAsync(null);
            await _viewModel.GetCarsCommand.ExecuteAsync(null);
            base.OnAppearing();
        }
    }

}
