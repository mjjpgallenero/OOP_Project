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
using OOP_Project.Views;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = App.Locator.MainWindowViewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new MainTransactionWindow();
            Application.Current.MainWindow = window;
            window.Show();
            this.Close();

        }
    }
}
