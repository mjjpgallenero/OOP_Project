using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace OOP_Project
{
    public class Customer : ObservableObject
    {
        public Customer()
        {
            
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public ObservableCollection<LoanTransaction> LoanTransactions { get; set; } = new ObservableCollection<LoanTransaction>();

        public int FullyPaidLoans
        {
            get { return LoanTransactions.Count(c => c.Status); }
        }
    }
}