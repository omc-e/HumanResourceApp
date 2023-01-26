using FontAwesome.Sharp;
using System.Windows.Input;

namespace HumanResourceApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currenChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrenChildView
        {
            get => _currenChildView; set
            {
                _currenChildView = value;
                OnPropertyChanged(nameof(CurrenChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon; set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowZaposleniciViewCommand { get; }
        public ICommand ShowDogadjajiViewCommand { get; }
        public ICommand ShowPocetnaViewCommand { get; }

        public MainViewModel()
        {
            ShowZaposleniciViewCommand = new ViewModelCommand(ExecuteShowZaposleniciViewCommand);
            ShowDogadjajiViewCommand = new ViewModelCommand(ExecuteShowDogadjajiViewCommand);
            ShowPocetnaViewCommand = new ViewModelCommand(ExecuteShowPocetnaViewCommand);
            ExecuteShowPocetnaViewCommand(null);
        }

        private void ExecuteShowDogadjajiViewCommand(object obj)
        {
            CurrenChildView = new DogadjajiViewModel();
            Caption = "Dogadjaji";
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowZaposleniciViewCommand(object obj)
        {
            CurrenChildView = new ZaposleniciViewModel();
            Caption = "Zaposlenici";
            Icon = IconChar.User;
        }

        private void ExecuteShowPocetnaViewCommand(object obj)
        {
            CurrenChildView = new PocetnaViewModel();
            Caption = "Pocetna";
            Icon = IconChar.Home;
        }
    }
}
