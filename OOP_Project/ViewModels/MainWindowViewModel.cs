using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using GalaSoft.MvvmLight;

namespace OOP_Project.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            GenerateRandomCustomers();
        }

        private void GenerateRandomCustomers()
        {
            var random = new Random();
            string[] RandomNames = new[] {"Jonathan", "Joseph", "Jolyne", "Jolly", "Jona", "Jonnie"};
            string[] RandomAddresses = new[] {"123 Telstar St.", "Gem Village", "Morioh Town", "Palmetto Place", "Venezia", "432 Champaca"};
            string[] RandomNumbers = new[] {"123-4567", "299-1234", "+639177001234", "303-2187", "09158410825"};

            while (CustomerList.Count < 3)
            {
                int r1 = random.Next(RandomNames.Length);
                int r2 = random.Next(RandomAddresses.Length);
                int r3 = random.Next(RandomNumbers.Length);
                var randomName = RandomNames[random.Next(RandomNames.Length)];
                var randomAddress = RandomAddresses[random.Next(RandomAddresses.Length)];
                var randomNumber = RandomNumbers[random.Next(RandomNumbers.Length)];
                foreach (var customer in CustomerList)
                {
                    if (customer.Name != randomName || customer.Address != randomAddress ||
                        customer.ContactNumber != randomNumber)
                        CustomerList.Add(new Customer{Name = randomName, Address = randomAddress, ContactNumber = randomNumber});
                    
                }
            }
        }

        public ObservableCollection<Customer> CustomerList { get; } = new ObservableCollection<Customer>();

        public Customer SelectedCustomer { get; set; }
    }
}