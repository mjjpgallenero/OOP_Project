using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace OOP_Project.ViewModels
{
    public class AddNewLoanTransactionViewModel : ObservableObject
    {
        private MainTransactionWindowViewModel _mainTransactionWindowViewModel;
        private string _newJewelryType;
        private string _newJewelryQuality;
        private double? _newJewelryWeight;
        private double? _newJewelryCrystalWeight;
        private string _newJewelryDescription;
        private double _newJewelryTotalValue;

        public AddNewLoanTransactionViewModel(MainTransactionWindowViewModel mainTransactionWindowViewModel)
        {
            _mainTransactionWindowViewModel = mainTransactionWindowViewModel;
        }

        public string[] JewelryQualities { get; } = { "10k", "18k", "21k" };
        public string[] JewelryTypes { get; } = {"Ring", "Bracelet", "Necklace", "Earring"};

        public string NewJewelryType
        {
            get { return _newJewelryType; }
            set
            {
                _newJewelryType = value;
                RaisePropertyChanged(nameof(NewJewelryType));
            }
        }

        public string NewJewelryQuality
        {
            get { return _newJewelryQuality; }
            set
            {
                _newJewelryQuality = value;
                RaisePropertyChanged(nameof(NewJewelryQuality));
            }
        }

        public double? NewJewelryWeight
        {
            get { return _newJewelryWeight; }
            set
            {
                _newJewelryWeight = value;
                RaisePropertyChanged(nameof(NewJewelryWeight));
            }
        }

        public double? NewJewelryCrystalWeight
        {
            get { return _newJewelryCrystalWeight; }
            set
            {
                _newJewelryCrystalWeight = value;
                RaisePropertyChanged(nameof(NewJewelryCrystalWeight));
            }
        }

        public string NewJewelryDescription
        {
            get { return _newJewelryDescription; }
            set
            {
                _newJewelryDescription = value;
                RaisePropertyChanged(nameof(NewJewelryDescription));
            }
        }

        public ICommand AddNewLoanTransactionCommand => new RelayCommand(AddNewLoanTransactionProc, AddNewLoanTransactionCondition);

        private void AddNewLoanTransactionProc()
        {
            if (NewJewelryCrystalWeight >= NewJewelryWeight)
                MessageBox.Show("The crystal's weight cannot be more than the jewelry's weight.", "Error",
                    MessageBoxButton.OK);
            else
            {
                var newJewelry = new Jewelry();
                newJewelry.JewelryId =
                    $"0000000{(int.Parse(_mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions.LastOrDefault().JewelryCollateral.JewelryId) + 1)}";
                newJewelry.JewelryQuality = NewJewelryQuality;
                newJewelry.JewelryType = NewJewelryType;
                if (NewJewelryCrystalWeight != null) newJewelry.CrystalWeight = (double) NewJewelryCrystalWeight;
                if (NewJewelryWeight != null) newJewelry.Weight = (double) NewJewelryWeight;
                newJewelry.Description = NewJewelryDescription;
                var newLoanTransaction = new LoanTransaction();
                newLoanTransaction.JewelryCollateral = newJewelry;
                newLoanTransaction.Customer = _mainTransactionWindowViewModel.SelectedCustomer;
                newLoanTransaction.TransactionDate = DateTime.UtcNow;
                newLoanTransaction.RemainingBalance = newLoanTransaction.ToBePaid;
                _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions.Add(newLoanTransaction);
                MessageBox.Show("Loan Successful!", "Transaction Alert", MessageBoxButton.OK);
                NewJewelryType = null;
                NewJewelryQuality = null;
                NewJewelryWeight = null;
                NewJewelryCrystalWeight = null;
                NewJewelryDescription = null;
            }
        }

        private bool AddNewLoanTransactionCondition()
        {
            if (NewJewelryType == null || NewJewelryQuality == null || NewJewelryWeight == null ||
                NewJewelryCrystalWeight == null)
            {
                return false;
            }

            return true;
        }
    }
}