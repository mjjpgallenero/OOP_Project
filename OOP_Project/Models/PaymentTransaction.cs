using System;
using System.Globalization;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class PaymentTransaction : ObservableObject
    {
        private LoanTransaction _loan;
        private string _status;
        private Jewelry _jewelryCollateral;
        private double _accumulatedAmountOfLoan;
        private double _paymentAmount;
        private DateTime _paymentDate;

        public PaymentTransaction()
        {
            
        }

        public LoanTransaction Loan
        {
            get { return _loan; }
            set
            {
                _loan = value; 
                RaisePropertyChanged(nameof(Loan));
                RaisePropertyChanged(nameof(AccumulatedAmountOfLoan));
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                if (Loan.RemainingBalance == 0) _status = "Fully Paid";
                else _status = "Partial";
                RaisePropertyChanged(nameof(Status));
            }
        }

        public Jewelry JewelryCollateral
        {
            get { return _jewelryCollateral; }
            set
            {
                _jewelryCollateral = value;
                RaisePropertyChanged(nameof(JewelryCollateral));
            }
        }

        public double AccumulatedAmountOfLoan
        {
            get
            {
                _accumulatedAmountOfLoan = Loan.LoanAmount +
                                           (Loan.LoanAmount * 0.01 * (CalculateDays(PaymentDate.ToShortDateString())) / 30);
                return _accumulatedAmountOfLoan;
            }

        }

        public double PaymentAmount
        {
            get { return _paymentAmount; }
            set
            {
                _paymentAmount = value; 
                RaisePropertyChanged(nameof(PaymentAmount));
            }
        }

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set
            {
                _paymentDate = value;
                RaisePropertyChanged(nameof(PaymentDate));
            }
        }

        public static double CalculateDays(string endDate)
        {
            DateTime end = Convert.ToDateTime(endDate);
            DateTime start = DateTime.UtcNow;

            var months = 12 * (end.Year - start.Year) + (end.Month - start.Month);

            return months * 30;
        }
    }
}