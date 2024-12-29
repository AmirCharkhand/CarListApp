using CarListApp.ViewModels;

namespace CarListApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly CarListViewModel _viewModel;
        public MainPage(CarListViewModel carListViewModel)
        {
            BindingContext = carListViewModel;
            _viewModel = carListViewModel;
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.GetCarsCommand.ExecuteAsync(null);
        }
    }

}
