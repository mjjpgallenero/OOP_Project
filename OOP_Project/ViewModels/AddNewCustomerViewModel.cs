using System.CodeDom;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using OOP_Project.Views;

namespace OOP_Project.ViewModels
{
    public class AddNewCustomerViewModel : ObservableObject
    {

        private string _newCustomerName;
        private string _newCustomerAddress;
        private string _newCustomerContactNumber;
        private MainWindowViewModel _mainWindowViewModel;

        public AddNewCustomerViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public string NewCustomerName
        {
            get { return _newCustomerName; }
            set
            {
                _newCustomerName = value;
                RaisePropertyChanged(nameof(NewCustomerName));
            }
        }

        public string NewCustomerAddress
        {
            get { return _newCustomerAddress; }
            set
            {
                _newCustomerAddress = value;
                RaisePropertyChanged(nameof(NewCustomerAddress));
            }
        }

        public string NewCustomerContactNumber
        {
            get { return _newCustomerContactNumber; }
            set
            {
                _newCustomerContactNumber = value;
                RaisePropertyChanged(nameof(NewCustomerContactNumber));

                int num;
                bool flag = int.TryParse(_newCustomerContactNumber, out num);

                if (flag)
                {
                    _newCustomerContactNumber = value;
                    RaisePropertyChanged(nameof(NewCustomerContactNumber));
                }
                else
                {
                    MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButton.OK);
                    _newCustomerContactNumber = null;
                    RaisePropertyChanged(nameof(NewCustomerContactNumber));
                }
            }
        }

        public ICommand AddNewCustomerCommand => new RelayCommand(AddNewCustomerProc);

        private void AddNewCustomerProc()
        {
            if (NewCustomerName == null || NewCustomerAddress == null || NewCustomerContactNumber == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK);
            }
            else
            {
                var newCustomer = new Customer();
                newCustomer.Name = NewCustomerName;
                newCustomer.Address = NewCustomerAddress;
                newCustomer.ContactNumber = NewCustomerContactNumber;

                _mainWindowViewModel.CustomerList.Add(newCustomer);
            }
        }

    }
}