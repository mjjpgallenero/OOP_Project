using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class AddNewPaymentTransactionViewModel : ObservableObject
    {
        private MainTransactionWindowViewModel _mainTransactionWindowViewModel;
        private LoanTransaction _selectedLoanTransaction;
        private DateTime _dateOfPayment;

        public AddNewPaymentTransactionViewModel(MainTransactionWindowViewModel mainTransactionWindowViewModel)
        {
            _mainTransactionWindowViewModel = mainTransactionWindowViewModel;
            LoanTransactions = _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions;
        }

        public ObservableCollection<LoanTransaction> LoanTransactions { get; }

        public LoanTransaction SelectedLoanTransaction
        {
            get { return _selectedLoanTransaction; }
            set
            {
                _selectedLoanTransaction = value;
                RaisePropertyChanged(nameof(SelectedLoanTransaction));
            }
        }

        public DateTime DateOfPayment
        {
            get { return _dateOfPayment; }
            set
            {
                _dateOfPayment = value; 
                RaisePropertyChanged(nameof(DateOfPayment));
            }
        }
    }
}