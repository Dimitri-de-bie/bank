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
    /// Interaction logic for klanten.xaml
    /// </summary>
    public partial class klanten : Window
    {

        klantenclass kc;
        Customer SelectedItem;
        bankrekeningDataContext db = new bankrekeningDataContext();
        public klanten()
        {
            InitializeComponent();
            kc = new klantenclass();
            dgklant.ItemsSource = kc.giveAllCustomers();
            SetData();
        }
        private void SetData()
        {
            dgklant.ItemsSource = kc.AllKlanten();
        }

        private void Btnterug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mywindow = new MainWindow();
            mywindow.Show();
            this.Close();
        }

        private void txtadres_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btntoevoegen_Click(object sender, RoutedEventArgs e)
        {
            string sBsn = TxtBSN.Text;

            string sVoorletters = txtvoorletters.Text;

            string sVoornaam = Txtvoornaam.Text;

            string sAchternaam = txtachternaam.Text;

            string sAdres = txtadres.Text;

            string sPostcode = txtpostcode.Text;

            string sWoonplaats = txtwoonplaats.Text;

            string sTelefoonnummer = txttelefoonnummer.Text;

            string sEmail = txtemail.Text;

            kc.klantopslaan(sBsn, sVoorletters, sVoornaam, 
                sAchternaam, sAdres, sPostcode, sWoonplaats, 
                sTelefoonnummer, sEmail);
            dgklant.ItemsSource = kc.giveAllCustomers();
        }

        private void dgklant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            
        }

        private void Btnwijzigen_Click(object sender, RoutedEventArgs e)
        {

           
                kc.EditKlant(SelectedItem.BSN, txtvoorletters.Text, 
                    Txtvoornaam.Text, txtachternaam.Text, 
                    txtadres.Text, txtpostcode.Text, txtwoonplaats.Text, 
                    txttelefoonnummer.Text, txtemail.Text);
            db.SubmitChanges();
            SetData();
           


        }
       

        private void dgklant_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
                SelectedItem = (Customer)dgklant.SelectedItem;
                
                    TxtBSN.IsReadOnly = true;

                    TxtBSN.Text = SelectedItem.BSN;

                    txtvoorletters.Text = SelectedItem.voorletters;

                    Txtvoornaam.Text = SelectedItem.voornaam;

                    txtachternaam.Text = SelectedItem.achternaam;

                    txtadres.Text = SelectedItem.adres;

                    txtpostcode.Text = SelectedItem.postcode;

                    txtwoonplaats.Text = SelectedItem.woonplaats;

                    txttelefoonnummer.Text = SelectedItem.telefoonnummer;

                    txtemail.Text = SelectedItem.email;
                
                
        }

        private void Btnverwijderen_Click(object sender, RoutedEventArgs e)
        {
            kc.Klantenverwijderen(SelectedItem.BSN);
            db.SubmitChanges();
            SetData();
        }
    }
}
