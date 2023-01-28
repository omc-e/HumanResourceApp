using HumanResourceApp.Model;
using HumanResourceApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HumanResourceApp.View
{
    /// <summary>
    /// Interaction logic for ZaposleniciView.xaml
    /// </summary>
    public partial class ZaposleniciView : UserControl
    {

        public static DataGrid datagrid;
        public ZaposleniciModel SelectedZaposlenik { get; set; }


        public ZaposleniciView()
        {
            InitializeComponent();
            Load();
            datagrid = this.ZaposleniciLista;

        }

        private void Load()
        {
            RepositoryBase db = new RepositoryBase();
            var zaposlenici = from d in db.Zaposlenici
                              select d;

            this.ZaposleniciLista.ItemsSource = zaposlenici.ToList();
            
            datagrid = this.ZaposleniciLista;
        }

    }
}
