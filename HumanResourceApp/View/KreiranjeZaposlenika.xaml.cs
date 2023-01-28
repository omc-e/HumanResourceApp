using HumanResourceApp.Model;
using HumanResourceApp.Repositories;
using HumanResourceApp.ViewModel;
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

namespace HumanResourceApp.View
{
    /// <summary>
    /// Interaction logic for KreiranjeZaposlenika.xaml
    /// </summary>
    public partial class KreiranjeZaposlenika : Window
    {
        public KreiranjeZaposlenika()
        {
            InitializeComponent();
            this.DataContext = new ZaposleniciViewModel();
        }


       

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            RepositoryBase db = new RepositoryBase();
            byte selectedValue = 0;

            if((string)polComboBox.SelectionBoxItem == "Musko")
            {
                selectedValue = 1;
            }
            else if((string)polComboBox.SelectionBoxItem == "Zensko")
            {
                selectedValue = 2;

            }

            ZaposleniciModel radnik = new ZaposleniciModel()
            {
                Ime = this.imeTextBox.Text,
                Prezime = this.prezimeTextBox.Text,
                Grad = this.gradTextBox.Text,
                Adresa = this.adresaTextBox.Text,
                DatumDodavanja = DateTime.Now,
                Pol = selectedValue


            };

            db.Zaposlenici.Add(radnik);
            db.SaveChanges();
            ((ZaposleniciViewModel)this.DataContext).RefreshEmployeeData(ZaposleniciView.datagrid);

            this.Close();

        }
    }
}
