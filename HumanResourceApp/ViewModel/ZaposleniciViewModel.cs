using FontAwesome.Sharp;
using HumanResourceApp.Repositories;
using HumanResourceApp.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace HumanResourceApp.ViewModel
{
    public class ZaposleniciViewModel : ViewModelBase
    {

        public ICommand ShowAddViewCommand { get; }


        private void ExecuteShowAddViewCommand(object obj)
        {
            KreiranjeZaposlenika win2 = new KreiranjeZaposlenika();
            win2.Show();
        }

      

        public ZaposleniciViewModel()
        {
           
            ShowAddViewCommand = new ViewModelCommand(ExecuteShowAddViewCommand);
        }

        private void DodajRadnika(string ime, string prezime, string grad, string adresa, byte pol)
        {

        }
      



    }
}
