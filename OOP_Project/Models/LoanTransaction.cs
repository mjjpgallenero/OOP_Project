using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class LoanTransaction : ObservableObject
    {
        public LoanTransaction()
        {
            
        }
        public Customer Customer { get; set; }
        public Jewelry JewelryCollateral { get; set; }
        public double LoanAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public ObservableCollection<PaymentTransaction> PaymentTransactions { get; } = new ObservableCollection<PaymentTransaction>();

    }
}