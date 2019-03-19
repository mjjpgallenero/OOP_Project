using OOP_Project.ViewModels;

namespace OOP_Project
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel { get; set; } = new MainWindowViewModel();
        public AddNewCustomerViewModel AddNewCustomerViewModel { get; set; } = new AddNewCustomerViewModel();
    }
}