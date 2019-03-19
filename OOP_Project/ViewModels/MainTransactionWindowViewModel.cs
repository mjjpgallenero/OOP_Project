using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class MainTransactionWindowViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;
        private string _profile;

        public MainTransactionWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _profile = _mainWindowViewModel.SelectedCustomer.Name;
        }

        public string Profile
        {
            get { return _profile; }
            set
            {
                _profile = value; 
                RaisePropertyChanged(nameof(Profile));
            }
        }
    }
}