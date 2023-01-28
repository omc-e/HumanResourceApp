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
    /// Interaction logic for IzmjenaZaposlenika.xaml
    /// </summary>
    public partial class IzmjenaZaposlenika : Window
    {
        public ZaposleniciModel SelectedData { get; set; }

        public IzmjenaZaposlenika()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            RepositoryBase db = new RepositoryBase();
            byte selectedValue = 0;

            if ((string)polComboBox.SelectionBoxItem == "Musko")
            {
                selectedValue = 1;
            }
            else if ((string)polComboBox.SelectionBoxItem == "Zensko")
            {
                selectedValue = 2;

            }
            var radnik = db.Zaposlenici.Where(d => d.Id == SelectedData.Id).FirstOrDefault();
         
            if (radnik != null)
            {
                radnik.Ime = this.imeTextBox.Text;
                radnik.Prezime = this.prezimeTextBox.Text;
                radnik.Pol = selectedValue;
                radnik.Adresa = this.adresaTextBox.Text;
                radnik.Grad = this.gradTextBox.Text;
                radnik.DatumIzmjene = DateTime.Now;
            }

            db.Zaposlenici.Update(radnik);
            db.SaveChanges();
            //((ZaposleniciViewModel)this.DataContext).RefreshEmployeeData(ZaposleniciView.datagrid);

            this.Close();
        }
    }
}
