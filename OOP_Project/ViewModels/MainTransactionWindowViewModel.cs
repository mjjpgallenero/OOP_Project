using System;
using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class MainTransactionWindowViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;
        private Customer _selectedCustomer;
        private LoanTransaction _selectedLoanTransaction;

        public MainTransactionWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            SelectedCustomer = _mainWindowViewModel.SelectedCustomer;
            MockData();
        }

        public void MockData()
        {
            var jewelry = new Jewelry();
            jewelry.JewelryId = "0000-0001";
            jewelry.JewelryType = JewelryTypes.Ring.ToString();
            jewelry.JewelryQuality = "10k";
            jewelry.CrystalWeight = 1.5;
            jewelry.Weight = 6;

            var loanTransaction = new LoanTransaction();
            loanTransaction.Customer = SelectedCustomer;
            loanTransaction.JewelryCollateral = jewelry;
            loanTransaction.TransactionDate = DateTime.UtcNow;
            SelectedCustomer.LoanTransactions.Add(loanTransaction);

            var paymentTransaction = new PaymentTransaction();
            paymentTransaction.JewelryCollateral = jewelry;
            paymentTransaction.PaymentDate = new DateTime(2019, 04, 19);
            paymentTransaction.PaymentAmount = 1000;
            loanTransaction.PaymentTransactions.Add(paymentTransaction);
            paymentTransaction.Loan = loanTransaction;
        }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }

        public LoanTransaction SelectedLoanTransaction
        {
            get { return _selectedLoanTransaction; }
            set
            {
                _selectedLoanTransaction = value; 
                RaisePropertyChanged(nameof(SelectedLoanTransaction));
            }
        }

    }
}