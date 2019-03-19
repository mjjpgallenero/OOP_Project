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
                //if (value == "10k" || value == "18k" || value == "21k") _newJewelryQuality = value;
                _newJewelryQuality = value;
                RaisePropertyChanged(nameof(NewJewelryQuality));
                //RaisePropertyChanged(nameof(NewJewelryTotalValue));
            }
        }

        public double? NewJewelryWeight
        {
            get { return _newJewelryWeight; }
            set
            {
                _newJewelryWeight = value;
               // _newJewelryWeight -= NewJewelryCrystalWeight;
                RaisePropertyChanged(nameof(NewJewelryWeight));
                //RaisePropertyChanged(nameof(NewJewelryTotalValue));
            }
        }

        public double? NewJewelryCrystalWeight
        {
            get { return _newJewelryCrystalWeight; }
            set
            {
                _newJewelryCrystalWeight = value;
                RaisePropertyChanged(nameof(NewJewelryCrystalWeight));
                //RaisePropertyChanged(nameof(NewJewelryWeight));
                //RaisePropertyChanged(nameof(NewJewelryTotalValue));
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
            _mainTransactionWindowViewModel.SelectedCustomer.LoanTransactions.Add(newLoanTransaction);
            MessageBox.Show("Loan Successful!", "Transaction Alert", MessageBoxButton.OK);
            NewJewelryType = null;
            NewJewelryQuality = null;
            NewJewelryWeight = null;
            NewJewelryCrystalWeight = null;
            NewJewelryDescription = null;
        }

        private bool AddNewLoanTransactionCondition()
        {
            if (NewJewelryType == null || NewJewelryQuality == null || NewJewelryWeight == null ||
                NewJewelryCrystalWeight == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //public double NewJewelryTotalValue
        //{
        //    get
        //    {
        //        if (NewJewelryQuality == "10k") return _newJewelryTotalValue = (NewJewelryWeight * 0.417) * 928.64;
        //        if (NewJewelryQuality == "18k") return _newJewelryTotalValue = (NewJewelryWeight * 0.75) * 1670.75;
        //        if (NewJewelryQuality == "21k") return _newJewelryTotalValue = (NewJewelryWeight * 0.875) * 1949.21;

        //        return 0;
        //    }

        //}
    }
}