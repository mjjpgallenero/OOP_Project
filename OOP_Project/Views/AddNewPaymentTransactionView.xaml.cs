﻿using System;
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
    /// Interaction logic for AddNewPaymentTransactionView.xaml
    /// </summary>
    public partial class AddNewPaymentTransactionView : UserControl
    {
        public AddNewPaymentTransactionView()
        {
            InitializeComponent();
            DataContext = App.Locator.AddNewPaymentTransactionViewModel;
        }
    }
}
