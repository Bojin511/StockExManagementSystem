using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utils;
using System.Data;

namespace StockExMangementSystem
{
    /// <summary>
    /// Interaction logic for SystemWindow.xaml
    /// </summary>
    public partial class SystemWindow : Window
    {
        public SystemWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IssueAdder.addRequest(usernameTextbox.Text, passwordTextbox.Text, datePicker1.Text, descriptionTextbox.Text, statusComboBox.Text);
            MessageBox.Show("User Request has been sent!");
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewSHButton_Click(object sender, RoutedEventArgs e)
        {
            viewSHDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareholderViewer.ViewShareholder() }); 
        }

        private void SHApprovedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewSHDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareholderStatusFilterer.ApprovedStatus() });
        }

        private void SHDeniedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewSHDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareholderStatusFilterer.DeniedStatus() });
        }

        private void SHSuspenededRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewSHDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareholderStatusFilterer.SuspendedStatus() });
        }

        private void EditSHStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ShareholderStatusChanger.changeShareholderStatus(SHFirstNameTextBox.Text, SHLastNameTextBox.Text, SHStockEXcomboBox.Text, SHStatuscomboBox.Text);
            MessageBox.Show("Shareholder Stock Exchange status has been changed");
        }

        private void BApprovedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewBDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = BrokerStatusFilterer.ApprovedStatus() });
        }

        private void BDeniedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewBDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = BrokerStatusFilterer.DeniedStatus() });
        }

        private void BSuspenedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            viewBDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = BrokerStatusFilterer.SuspendedStatus() });
        }

        private void viewBButton_Click(object sender, RoutedEventArgs e)
        {
            viewBDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = BrokerViewer.ViewBroker() }); 
        }

        private void EditBStatusButton_Click(object sender, RoutedEventArgs e)
        {
            BrokerStatusChanger.changeBrokerStatus(BFirstNameTextBox.Text, BLastNameTextBox.Text, BStockEXcomboBox.Text, BStatuscomboBox.Text);
            MessageBox.Show("Broker Stock Exchange status has been changed");
        }

        private void shareholderSharesButton_Click(object sender, RoutedEventArgs e)
        {
            SHDisplayDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareOwnedViewer.ViewShareOwned(searchSHFirstNameTextBox.Text, searchSHLastNameTextBox.Text) }); 
        }

        private void BrokerSharesButton_Click(object sender, RoutedEventArgs e)
        {
            BDisplayDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = ShareOwnedViewer.ViewShareOwned(searchBFirstNameTextBox.Text, searchBLastNameTextBox.Text) }); 
        }

        private void BrokerTradesButton_Click(object sender, RoutedEventArgs e)
        {
            BDisplayDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = TradeDoneViewer.ViewTradeDone(searchBFirstNameTextBox.Text, searchBLastNameTextBox.Text) }); 
        }

        private void shareholderTradesButton_Click(object sender, RoutedEventArgs e)
        {
            SHDisplayDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = TradeDoneViewer.ViewTradeDone(searchSHFirstNameTextBox.Text, searchSHLastNameTextBox.Text) }); 
        }

        private void ViewCompanyButton_Click(object sender, RoutedEventArgs e)
        {
            CompanyViewDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = CompanyViewer.ViewCompany() }); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            viewTradesDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding { Source = TradesViewer.ViewTrades() }); 
        }



        }
    }

