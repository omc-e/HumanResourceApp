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
    /// Interaction logic for DodajDogadjaj.xaml
    /// </summary>
    public partial class DodajDogadjaj : Window
    {
        RepositoryBase context = new RepositoryBase();

        public DodajDogadjaj()
        {
            InitializeComponent();
            Load();
            this.DataContext = new DogadjajiViewModel();
        }

        private void Load()
        {
          context = new RepositoryBase();
           var zaposlenici = context.Zaposlenici.ToList();

            cbZaposlenici.ItemsSource = zaposlenici;

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedZaposlenik = cbZaposlenici.SelectedItem as ZaposleniciModel;

             if (datumDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Morate odabrati datum!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tekstDogadjajTextBox.Text))
            {
                MessageBox.Show("Morate upisati tekst dogadjaja!");
                return;
            }

            if (cbZaposlenici.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati radnika!");
                return;
            }

            DogadjajiModel dogadjaj = new DogadjajiModel()
            {
                Datum = (DateTime)datumDatePicker.SelectedDate,
                TekstDogadjaja = tekstDogadjajTextBox.Text,
                Zaposlenici = selectedZaposlenik,
                ZaposleniciId = selectedZaposlenik.Id
                
            };
            
            context.Dogadjaji.Add(dogadjaj);
            context.SaveChanges();

            ((DogadjajiViewModel)this.DataContext).RefreshEventData(DogadjajiView.datagrid);
            this.Close();
        }
    }
}
