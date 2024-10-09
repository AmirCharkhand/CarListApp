using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    public abstract partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = string.Empty;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBuisy))]
        private bool _isBuisy = false;

        public bool IsNotBuisy => !IsBuisy;
    }
}