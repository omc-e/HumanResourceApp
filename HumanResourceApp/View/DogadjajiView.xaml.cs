using HumanResourceApp.Model;
using HumanResourceApp.Repositories;
using HumanResourceApp.ViewModel;
using System.Linq;
using System.Windows.Controls;

namespace HumanResourceApp.View
{
    /// <summary>
    /// Interaction logic for DogadjajiView.xaml
    /// </summary>
    public partial class DogadjajiView : UserControl
    {
        public static DataGrid datagrid;


        public DogadjajiView()
        {
            InitializeComponent();
            Load();
            datagrid = this.DogadjajiLista;
        }


        private void Load()
        {
            RepositoryBase db = new RepositoryBase();

            var dogadjaji = db.Dogadjaji.ToList();
            var zaposlenici = db.Zaposlenici.ToList();

            var result = from d in dogadjaji
                         join z in zaposlenici on d.ZaposleniciId equals z.Id into dz
                         from zaposlenik in dz.DefaultIfEmpty()
                         select new DogadjajiModel
                         {
                             Id = d.Id,
                             ZaposleniciId = d.ZaposleniciId,
                             TekstDogadjaja = d.TekstDogadjaja,
                             Datum = d.Datum,
                             Zaposlenici = zaposlenik
                         }; 

            this.DogadjajiLista.ItemsSource = dogadjaji.ToList();
            datagrid = this.DogadjajiLista;
        }
      
    }
}
