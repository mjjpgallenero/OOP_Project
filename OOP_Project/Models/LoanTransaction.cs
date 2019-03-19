using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class LoanTransaction : ObservableObject
    {
        private Jewelry _jewelryCollateral;
        private double _loanAmount;
        private DateTime _transactionDate;
        private double _remainingBalance;
        private Customer _customer;

        public LoanTransaction()
        {
            
        }

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                RaisePropertyChanged(nameof(Customer));
            }
        }

        public Jewelry JewelryCollateral
        {
            get { return _jewelryCollateral; }
            set
            {
                _jewelryCollateral = value; 
                RaisePropertyChanged(nameof(JewelryCollateral));
                RaisePropertyChanged(nameof(LoanAmount));
            }
        }

        public double LoanAmount
        {
            get { return Math.Round(JewelryCollateral.TotalValue); }
        }

        public DateTime TransactionDate
        {
            get { return _transactionDate; }
            set
            {
                _transactionDate = value;
                RaisePropertyChanged(nameof(TransactionDate));
            }
        }

        public double RemainingBalance
        {
            get
            {
                foreach (var paymentTransaction in PaymentTransactions)
                {
                    _remainingBalance = paymentTransaction.AccumulatedAmountOfLoan - paymentTransaction.PaymentAmount;
                }
                return _remainingBalance;
            }

        }

        public ObservableCollection<PaymentTransaction> PaymentTransactions { get; } = new ObservableCollection<PaymentTransaction>();


    }
}