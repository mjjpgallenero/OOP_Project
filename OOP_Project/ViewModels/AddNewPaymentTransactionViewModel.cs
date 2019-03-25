using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class AddNewPaymentTransactionViewModel : ObservableObject
    {
        private MainTransactionWindowViewModel _mainTransactionWindowViewModel;

        public AddNewPaymentTransactionViewModel(MainTransactionWindowViewModel mainTransactionWindowViewModel)
        {
            _mainTransactionWindowViewModel = mainTransactionWindowViewModel;
            var unpaidLoans =
                _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions.Where(c => c.Status == false);
            LoanTransactions = _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions;
        }

        public ObservableCollection<LoanTransaction> LoanTransactions { get; }


    }
}