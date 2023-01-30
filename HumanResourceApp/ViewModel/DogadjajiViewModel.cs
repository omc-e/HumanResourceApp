using HumanResourceApp.Model;
using HumanResourceApp.Repositories;
using HumanResourceApp.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanResourceApp.ViewModel
{
    public class DogadjajiViewModel : ViewModelBase
    {
        public static DataGrid datagrid;
        public ICommand ShowAddViewCommand { get; }
        public ICommand ShowEditViewCommand { get; }
        public ICommand DeleteCommand { get; }




        private ObservableCollection<DogadjajiModel> _dogadjaj;
        public ObservableCollection<DogadjajiModel> Dogadjaj
        {
            get { return _dogadjaj; }
            set { _dogadjaj = value; OnPropertyChanged(nameof(Dogadjaj)); }
        }


        private void ExecuteShowAddViewCommand(object obj)
        {
            DodajDogadjaj win2 = new DodajDogadjaj();
            win2.Show();
        }


        public DogadjajiViewModel()
        {

            _dogadjaj = new ObservableCollection<DogadjajiModel>(GetEventData());
            ShowAddViewCommand = new ViewModelCommand(ExecuteShowAddViewCommand);
            ShowEditViewCommand = new ViewModelCommand(ExecuteEditViewCommand);
            DeleteCommand = new ViewModelCommand(DeleteEvent);
        }

        private void DeleteEvent(object obj)
        {
            var selectedItem = DogadjajiView.datagrid.SelectedItem;
            if (selectedItem == null) return;

            var result = MessageBox.Show("Zelite li izbrisati ovaj dogadjaj?", "Confirm", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            using (var context = new RepositoryBase())
            {
                var dogadjaj = (DogadjajiModel)selectedItem;
                var dogadjajToDelete = context.Dogadjaji.FirstOrDefault(x => x.Id == dogadjaj.Id);
                context.Dogadjaji.Remove(dogadjajToDelete);


                context.SaveChanges();
            }

            RefreshEventData(DogadjajiView.datagrid);
        }


        private List<DogadjajiModel> GetEventData()
        {
            using (var context = new RepositoryBase())
            {
                return context.Dogadjaji.Include(x => x.Zaposlenici).ToList();
            }
        }

        public void RefreshEventData(DataGrid dataGrid)
        {

            _dogadjaj = new ObservableCollection<DogadjajiModel>(GetEventData());

            dataGrid.ItemsSource = _dogadjaj;
            datagrid = dataGrid;
        }

        private void ExecuteEditViewCommand(object obj)
        {


            var selectedItem = DogadjajiView.datagrid.SelectedItem;
            if (selectedItem != null)
            {
                IzmijeniDogadjaj win2 = new IzmijeniDogadjaj();
                win2.DataContext = win2;
                win2.SelectedData = (DogadjajiModel)selectedItem;
                win2.Show();
            }
        }
    }
}

