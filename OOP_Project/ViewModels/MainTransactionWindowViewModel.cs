using System;
using System.Linq;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class MainTransactionWindowViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowViewModel;
        private Customer _selectedCustomer;
        private LoanTransaction _selectedLoanTransactionToView;

        public MainTransactionWindowViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            SelectedCustomer = _mainWindowViewModel.SelectedCustomer;
            GenerateMockData();
        }

        private void GenerateMockData()
        {
            var jewelry = new Jewelry();
            jewelry.JewelryId = "00000001";
            jewelry.JewelryType = "Ring";
            jewelry.JewelryQuality = "10k";
            jewelry.CrystalWeight = 1.5;
            jewelry.Weight = 6;
            jewelry.Description = "Few scratches, slightly used";

            var loanTransaction = new LoanTransaction();
            loanTransaction.Customer = SelectedCustomer;
            loanTransaction.JewelryCollateral = jewelry;
            loanTransaction.TransactionDate = DateTime.UtcNow;
            SelectedCustomer.LoanTransactions.Add(loanTransaction);

            var paymentTransaction = new PaymentTransaction();
            paymentTransaction.Loan = loanTransaction;
            paymentTransaction.JewelryCollateral = jewelry;
            paymentTransaction.PaymentDate = new DateTime(2019, 04, 19);
            paymentTransaction.PaymentAmount = 1000;
            loanTransaction.PaymentTransactions.Add(paymentTransaction);

            double payments = 0;
            foreach (var p in loanTransaction.PaymentTransactions)
            {
                payments = payments + p.PaymentAmount;
            }

            loanTransaction.RemainingBalance = loanTransaction.ToBePaid - payments;
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

        public LoanTransaction SelectedLoanTransactionToView
        {
            get { return _selectedLoanTransactionToView; }
            set
            {
                _selectedLoanTransactionToView = value; 
                RaisePropertyChanged(nameof(SelectedLoanTransactionToView));
            }
        }

        
    }
}