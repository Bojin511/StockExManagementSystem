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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utils;

namespace StockExMangementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void userNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //validate(userNameTextBox.Text, passwordTextBox.Text);
            int c = UserValidator.getUserByUsername(userNameTextBox.Text, passwordTextBox.Text);
            if (c != 0)
            {
                new SystemWindow().Show();

                UserLoginLogger.logSuccess(userNameTextBox.Text);
            }
            else
            {
                MessageBox.Show("Incorrect Username / Password");

                UserLoginLogger.logFailed(userNameTextBox.Text);

            }
        }
    }
}
