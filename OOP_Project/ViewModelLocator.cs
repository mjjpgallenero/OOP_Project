using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using OOP_Project.ViewModels;
using OOP_Project.Views;

namespace OOP_Project
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(()=> SimpleIoc.Default);
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<AddNewCustomerViewModel>();
            SimpleIoc.Default.Register<MainTransactionWindowViewModel>();
            SimpleIoc.Default.Register<AddNewLoanTransactionViewModel>();
            SimpleIoc.Default.Register<AddNewPaymentTransactionViewModel>();
        }
        
        public MainWindowViewModel MainWindowViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
        }

        public AddNewCustomerViewModel AddNewCustomerViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AddNewCustomerViewModel>(); }
        }

        public MainTransactionWindowViewModel MainTransactionWindowViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainTransactionWindowViewModel>(); }
        }

        public AddNewLoanTransactionViewModel AddNewLoanTransactionViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AddNewLoanTransactionViewModel>(); }
        }

        public AddNewPaymentTransactionViewModel AddNewPaymentTransactionViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AddNewPaymentTransactionViewModel>(); }
        }
    }
}