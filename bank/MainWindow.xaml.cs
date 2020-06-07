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

namespace bank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        bankrekeningDataContext db = new bankrekeningDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnKlanten_Click(object sender, RoutedEventArgs e)
        {
            klanten Mywindow = new klanten();
            Mywindow.Show();
            this.Close();

        }

        private void Btntypes_Click(object sender, RoutedEventArgs e)
        {
            rekeningtypes mywindow = new rekeningtypes();
            mywindow.Show();
            this.Close();
        }

        private void Btnaccount_Click(object sender, RoutedEventArgs e)
        {
            account mywindow = new account();
            mywindow.Show();
            this.Close();
        }
    }
}
