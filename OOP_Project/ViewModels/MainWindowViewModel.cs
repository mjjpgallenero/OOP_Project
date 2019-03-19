using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using OOP_Project.Views;

namespace OOP_Project.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private Customer _selectedCustomer;
        private AddNewCustomerView _addNewCustomerView;
        private MainTransactionWindow _mainTransactionWindow;

        public MainWindowViewModel()
        {
            GenerateRandomCustomers();
        }

        private void GenerateRandomCustomers()
        {
            CustomerList.Add(new Customer{Name = "Jonathan", Address = "123 Telstar St.", ContactNumber = "123-4567"});
            CustomerList.Add(new Customer{Name = "Joseph",   Address = "Gem Village",     ContactNumber = "299-1234" });
            CustomerList.Add(new Customer{Name = "Jolyne",   Address = "Morioh Town",     ContactNumber = "+639177001234" });
            CustomerList.Add(new Customer{Name = "Jolly",    Address = "Palmetto Place",  ContactNumber = "303-2187" });
            CustomerList.Add(new Customer{Name = "Jona",     Address = "Venezia",         ContactNumber = "09158410825" });
            CustomerList.Add(new Customer{Name = "Jonnie",   Address = "432 Champaca",    ContactNumber = "+639320425213"});
                
        }

        public ObservableCollection<Customer> CustomerList { get; } = new ObservableCollection<Customer>();

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged(nameof(SelectedCustomer));
            }
        }

        public ICommand OpenAddNewCustomerWindowCommand => new RelayCommand(OpenAddNewCustomerWindowProc);

        private void OpenAddNewCustomerWindowProc()
        {
            _addNewCustomerView = new AddNewCustomerView();
            _addNewCustomerView.Owner = Application.Current.MainWindow;
            _addNewCustomerView.ShowDialog();
        }
        
        public ICommand CloseAddNewCustomerWindowCommand => new RelayCommand(CloseAddNewCustomerWindowProc);

        private void CloseAddNewCustomerWindowProc()
        {
            _addNewCustomerView.Close();
        }

        public ICommand OpenTransactionWindow => new RelayCommand(OpenTransactionProc, OpenTransactionCondition);

        private void OpenTransactionProc()
        {

        }

        private bool OpenTransactionCondition()
        {
            return SelectedCustomer != null;
        }
    }
}