using FontAwesome.Sharp;
using HumanResourceApp.Model;
using HumanResourceApp.Repositories;
using HumanResourceApp.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace HumanResourceApp.ViewModel
{
    public class ZaposleniciViewModel : ViewModelBase
    {
        public static DataGrid datagrid;
        public ICommand ShowAddViewCommand { get; }
        public ICommand ShowEditViewCommand { get; }
        private ObservableCollection<ZaposleniciModel> _employees;
        public ObservableCollection<ZaposleniciModel> Employees
        {
            get { return _employees; }
            set { _employees = value; OnPropertyChanged(nameof(Employees));}
        }


        private void ExecuteShowAddViewCommand(object obj)
        {
            KreiranjeZaposlenika win2 = new KreiranjeZaposlenika();     
            win2.Show();
        }

        private void ExecuteEditViewCommand(object obj)
        {


            var selectedItem = ZaposleniciView.datagrid.SelectedItem;
            if (selectedItem != null)
            {
                IzmjenaZaposlenika win2 = new IzmjenaZaposlenika();
                win2.DataContext = win2;
                win2.SelectedData = (ZaposleniciModel)selectedItem;
                win2.Show();
            }
        }

        public ZaposleniciViewModel()
        {
            _employees = new ObservableCollection<ZaposleniciModel>(GetEmployeeData());
            ShowAddViewCommand = new ViewModelCommand(ExecuteShowAddViewCommand);
            ShowEditViewCommand = new ViewModelCommand(ExecuteEditViewCommand);
            
        }


       private List<ZaposleniciModel>GetEmployeeData()
        {
            using (var context = new RepositoryBase())
            {
                return context.Zaposlenici.ToList();
            }
        }

        public void RefreshEmployeeData(DataGrid dataGrid)
        {
            //Retrieve employee data from a shared data source
            _employees = new ObservableCollection<ZaposleniciModel>(GetEmployeeData());
            // update the grid's data source
            dataGrid.ItemsSource = _employees;
            datagrid = dataGrid;
        }


    }
}
