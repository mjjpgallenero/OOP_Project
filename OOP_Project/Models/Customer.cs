using System.Collections.Generic;
using System.Windows.Documents;

namespace OOP_Project
{
    public class Customer
    {
        public Customer()
        {
            
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public List<LoanTransaction> LoanTransactions { get; set; } = new List<LoanTransaction>();
        public List<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();
    }
}