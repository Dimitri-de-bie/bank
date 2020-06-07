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
    /// Interaction logic for rekeningtypes.xaml
    /// </summary>
    public partial class rekeningtypes : Window
    {
        Typesclass tc;
        type SelectedItem;
        bankrekeningDataContext db = new bankrekeningDataContext();


        public rekeningtypes()
        {
            InitializeComponent();
            tc = new Typesclass();
            SetData();

        }
        private void SetData()
        {
            
            dgTypen.ItemsSource = tc.AllTypen();
        }

        private void Btnterug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mywindow = new MainWindow();
            mywindow.Show();
            this.Close();
        }

        private void Btntoevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtRente.Text, out double Rente) && double.TryParse(Txtmax.Text, out double MaxOpname))
            {
                tc.nieuwetypes(TxtNaam.Text, Rente, MaxOpname);
                db.SubmitChanges();
                SetData();
            }
        }

        private void Btnwijzigen_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtRente.Text, out double Rente) && double.TryParse(Txtmax.Text, out double MaxOpname))
            {
                tc.EditType(SelectedItem.Naam, Rente, MaxOpname);
                db.SubmitChanges();
                SetData();
            }
        }

        private void Btnverwijderen_Click(object sender, RoutedEventArgs e)
        {
            tc.DeleteType(SelectedItem.Naam);
            db.SubmitChanges();
            SetData();
        }

        

        private void dgTypen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = (type)dgTypen.SelectedItem;
            TxtNaam.IsReadOnly = true;
            TxtNaam.Text = SelectedItem.Naam;
            TxtRente.Text = SelectedItem.Rente.ToString();
            Txtmax.Text = SelectedItem.MaxOpname.ToString();
        }

        private void dgTypen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
