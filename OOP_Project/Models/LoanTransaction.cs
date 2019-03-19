using System;

namespace OOP_Project
{
    public class LoanTransaction
    {
        public LoanTransaction()
        {
            
        }
        public Customer Customer { get; set; }
        public Jewelry JewelryCollateral { get; set; }
        public double LoanAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        
    }
}