using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace OOP_Project.ViewModels
{
    public class AddNewPaymentTransactionViewModel : ObservableObject
    {
        private MainTransactionWindowViewModel _mainTransactionWindowViewModel;
        private LoanTransaction _selectedLoanTransaction;
        private DateTime _dateOfPayment;
        private string _paymentInput;

        public AddNewPaymentTransactionViewModel(MainTransactionWindowViewModel mainTransactionWindowViewModel)
        {
            _mainTransactionWindowViewModel = mainTransactionWindowViewModel;
            LoanTransactions = _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions;
        }

        public ObservableCollection<LoanTransaction> LoanTransactions { get; }

        public DateTime DateToday { get; } = DateTime.UtcNow;

        public double RemainingBalance
        {
            get
            {
                if (SelectedLoanTransaction != null)
                    return SelectedLoanTransaction.RemainingBalance;
                else return 0;
            }
        }

        public LoanTransaction SelectedLoanTransaction
        {
            get { return _selectedLoanTransaction; }
            set
            {
                _selectedLoanTransaction = value;
                RaisePropertyChanged(nameof(SelectedLoanTransaction));
                RaisePropertyChanged(nameof(RemainingBalance));
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

        public string PaymentInput
        {
            get { return _paymentInput; }
            set
            {
                _paymentInput = value;
                RaisePropertyChanged(nameof(PaymentInput));
            }
        }

        public ICommand AddNewPaymentTransactionCommand => new RelayCommand(AddNewPaymentTransactionProc, AddNewPaymentTransactionCondition);

        private void AddNewPaymentTransactionProc()
        {
            var newPaymentTransaction = new PaymentTransaction();

            newPaymentTransaction.JewelryCollateral = SelectedLoanTransaction.JewelryCollateral;
            newPaymentTransaction.Loan = SelectedLoanTransaction;
            var payment = double.Parse(PaymentInput);
            if (payment > SelectedLoanTransaction.RemainingBalance)
            {
                MessageBox.Show("Payment is greater than the remaining balance.", "Error", MessageBoxButton.OK);
            }
            else
            {
                newPaymentTransaction.PaymentAmount = double.Parse(PaymentInput);
            }
            newPaymentTransaction.PaymentDate = DateOfPayment;
            SelectedLoanTransaction.PaymentTransactions.Add(newPaymentTransaction);
            MessageBox.Show("Payment Successful!", "Transaction Alert", MessageBoxButton.OK);
            SelectedLoanTransaction.RemainingBalance -= newPaymentTransaction.PaymentAmount;
            PaymentInput = null;

        }

        private bool AddNewPaymentTransactionCondition()
        {
            if (SelectedLoanTransaction != null)
            {
                if (DateOfPayment >= SelectedLoanTransaction.TransactionDate && PaymentInput != null) return true;
            }
            return false;
        }
    }
}