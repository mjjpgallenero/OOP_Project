using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class LoanTransaction : ObservableObject
    {
        private Jewelry _jewelryCollateral;
        private DateTime _transactionDate;
        private Customer _customer;
        private double _remainingBalance;

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

        public double ToBePaid
        {
            get { return CalculateInterest(LoanAmount); }
        }

        public double RemainingBalance
        {
            get { return _remainingBalance; }
            set
            {
                _remainingBalance = value;
                RaisePropertyChanged(nameof(RemainingBalance));
            }
        }

        public bool Status
        {
            get
            {
                if (PaymentTransactions.Count == 0) return false;
                else
                {
                    //var balance = PaymentTransactions.LastOrDefault().RemainingBalance;
                    if (Math.Abs(RemainingBalance) > 0) return false;
                    else return true;
                }
            }
        }

        public string LoanStatus
        {
            get
            {
                if (Status) return "Fully paid";
                else return "Pending";
            }
        }

        public ObservableCollection<PaymentTransaction> PaymentTransactions { get; } = new ObservableCollection<PaymentTransaction>();

        //public static double CalculateDays(string endDate)
        //{
        //    DateTime end = Convert.ToDateTime(endDate);
        //    DateTime start = DateTime.UtcNow;

        //    var months = 12 * (end.Year - start.Year) + (end.Month - start.Month);

        //    return months * 30;
        //}

        public static double CalculateInterest(double amount)
        {
            return amount + (amount * 0.01 * (1 / 12));
        }
    }
}