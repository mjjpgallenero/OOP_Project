using System;
using System.Globalization;
using System.Linq;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class PaymentTransaction : ObservableObject
    {
        private LoanTransaction _loan;
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
    }
}