using System;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class PaymentTransaction : ObservableObject
    {
        public PaymentTransaction()
        {
            
        }

        public LoanTransaction Loan { get; set; }
        public string Status { get; set; }
        public Jewelry JewelryCollateral { get; set; }
        public double AccumulatedAmount { get; set; }
        public double Payment { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}