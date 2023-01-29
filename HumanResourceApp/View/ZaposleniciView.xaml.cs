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
            //var zaposlenici = from d in db.Zaposlenici
            //                  select d;

            var zaposlenici = from z in db.Zaposlenici
                              select new ZaposleniciModel
                              {
                                  Id = z.Id,
                                  Ime = z.Ime,
                                  Prezime = z.Prezime,
                                  Pol = z.Pol,
                                  Grad = z.Grad,
                                  Adresa = z.Adresa,
                                  Dogadjaji = (from d in db.Dogadjaji
                                               where d.ZaposleniciId == z.Id
                                               select new DogadjajiModel
                                               {
                                                   Id = d.Id,
                                                   ZaposleniciId = d.ZaposleniciId,
                                                   TekstDogadjaja = d.TekstDogadjaja,
                                                   Datum = d.Datum
                                               }).ToList()
                              };




            this.ZaposleniciLista.ItemsSource = zaposlenici.ToList();
            
            datagrid = this.ZaposleniciLista;
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            RepositoryBase db = new RepositoryBase();
            var zaposlenici = from z in db.Zaposlenici
                              where z.Ime.ToLower().Contains(searchText) || z.Prezime.ToLower().Contains(searchText)
                              select new ZaposleniciModel
                              {
                                  Id = z.Id,
                                  Ime = z.Ime,
                                  Prezime = z.Prezime,
                                  Pol = z.Pol,
                                  Grad = z.Grad,
                                  Adresa = z.Adresa,
                                  Dogadjaji = (from d in db.Dogadjaji
                                               where d.ZaposleniciId == z.Id
                                               select new DogadjajiModel
                                               {
                                                   Id = d.Id,
                                                   ZaposleniciId = d.ZaposleniciId,
                                                   TekstDogadjaja = d.TekstDogadjaja,
                                                   Datum = d.Datum
                                               }).ToList()
                              };
            this.ZaposleniciLista.ItemsSource = zaposlenici.ToList();
        }
    }
}
