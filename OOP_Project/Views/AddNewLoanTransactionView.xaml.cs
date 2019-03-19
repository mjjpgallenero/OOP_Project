using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_Project.Views
{
    /// <summary>
    /// Interaction logic for AddNewLoanTransactionView.xaml
    /// </summary>
    public partial class AddNewLoanTransactionView : UserControl
    {
        public AddNewLoanTransactionView()
        {
            InitializeComponent();
            DataContext = App.Locator.AddNewLoanTransactionViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (JType.Text
                == "" && JQuality.Text == "" && JCWeight.Text == "" &&
                JWeight.Text == "") MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK);
        }
    }
}
