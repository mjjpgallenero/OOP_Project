using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class MainTransactionWindowViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;

        public MainTransactionWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            SelectedCustomer = _mainWindowViewModel.SelectedCustomer;
        }

        public Customer SelectedCustomer { get; set; }
        public LoanTransaction SelectedLoanTransaction { get; set; }

    }
}