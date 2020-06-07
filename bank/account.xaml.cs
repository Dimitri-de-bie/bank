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
using System.Windows.Shapes;

namespace bank
{
    /// <summary>
    /// Interaction logic for account.xaml
    /// </summary>
    public partial class account : Window
    {
        bankrekeningDataContext db = new bankrekeningDataContext();
        accountclass ac;
        Account SelectedItem;

        List<String> BSN;
        public account()
        {
            InitializeComponent();
            ac = new accountclass();

            SetData();

            cbRekhou.ItemsSource = db.Customers.ToList();
            cbRekhou.DisplayMemberPath = "voornaam";

            cbType.ItemsSource = db.types.ToList();
            cbType.DisplayMemberPath = "Naam";
        }
        private void SetData()
        {

            dgRekeningen.ItemsSource = ac.alleaccounts();
            List<String> Fullnames = new List<String>();
            BSN = new List<String>();
            foreach (Customer K in db.Customers)
            {
                BSN.Add(K.BSN);
            }
           
        }

        private void Btnterug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mywindows = new MainWindow();
            mywindows.Show();
            this.Close();
        }

        private void Btntoevoegen_Click(object sender, RoutedEventArgs e)
        {
            DateTime startdatum = dpstart.SelectedDate.Value;
            DateTime stopdatum = dpstop.SelectedDate.Value;

            string sSaldo = txtSadlo.Text;
            double saldo = Convert.ToDouble(sSaldo);

            ac.nieuwerekening(txtSadlo.Text, BSN[cbRekhou.SelectedIndex], saldo, (type)cbType.SelectedItem,startdatum ,stopdatum );
            db.SubmitChanges();
            SetData();
        }

        private void Btnwijzigen_Click(object sender, RoutedEventArgs e)
        {
            DateTime startdatum = dpstart.SelectedDate.Value;
            DateTime stopdatum = dpstart.SelectedDate.Value;
            string sSaldo = txtSadlo.Text;
            double saldo = Convert.ToDouble(sSaldo);
            ac.rekeningveranderen(SelectedItem.IBAN, BSN[cbRekhou.SelectedIndex], saldo, (type)cbType.SelectedItem,startdatum, stopdatum);
            db.SubmitChanges();
            SetData();
        }

        

        private void dgRekeningen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = (Account)dgRekeningen.SelectedItem;
            TxtIBAN.Text = SelectedItem.IBAN;
            cbRekhou.SelectedItem = SelectedItem.Rekeningeigenaar;
                txtSadlo.Text = SelectedItem.Saldo.ToString();
                cbType.SelectedItem = SelectedItem.Type;
                dpstart.Text = SelectedItem.Startdatum.ToString();
                dpstop.Text = SelectedItem.afsluitdaten.ToString();

            
        }
    }
}
