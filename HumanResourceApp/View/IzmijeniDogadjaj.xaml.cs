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
 
    public partial class IzmijeniDogadjaj : Window
    {
        public DogadjajiModel SelectedData { get; set; }

        public IzmijeniDogadjaj()
        {
            InitializeComponent();
            this.DataContext = new DogadjajiViewModel();
            Load();


        }

        private void Load()
        {
            RepositoryBase context = new RepositoryBase();
            var zaposlenici = context.Zaposlenici.ToList();

            cbZaposlenici.ItemsSource = zaposlenici;
            //cbZaposlenici.SelectedItem = SelectedData.Zaposlenici;
        }


        private void updateDogadjajBtn_Click(object sender, RoutedEventArgs e)
        {
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


            RepositoryBase context = new RepositoryBase();

            var selectedZaposlenik = cbZaposlenici.SelectedItem as ZaposleniciModel;
            var dogadjaj = context.Dogadjaji.Where(d => d.Id == SelectedData.Id).FirstOrDefault();


             if(dogadjaj != null)
            {
                dogadjaj.Datum = (DateTime)datumDatePicker.SelectedDate;
                dogadjaj.TekstDogadjaja = tekstDogadjajTextBox.Text;
                dogadjaj.Zaposlenici = selectedZaposlenik;
                dogadjaj.ZaposleniciId = selectedZaposlenik.Id;

            };

            context.Dogadjaji.Update(dogadjaj);
            context.SaveChanges();

            //((DogadjajiViewModel)this.DataContext).RefreshEventData(DogadjajiView.datagrid);
            this.Close();
        }
    }
}
