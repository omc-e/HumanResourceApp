using HumanResourceApp.Repositories;
using System;
using System.Linq;
using System.Windows.Controls;

namespace HumanResourceApp.View
{
    /// <summary>
    /// Interaction logic for ZaposleniciView.xaml
    /// </summary>
    public partial class ZaposleniciView : UserControl
    {

        public static DataGrid datagrid;

        public ZaposleniciView()
        {
            InitializeComponent();

            RepositoryBase db = new RepositoryBase();
            var zaposlenici = from d in db.Zaposlenici
                              select d;

            foreach (var item in zaposlenici)
            {
                Console.WriteLine(item);
            }
            this.ZaposleniciLista.ItemsSource = zaposlenici.ToList();
        }
    }
}
