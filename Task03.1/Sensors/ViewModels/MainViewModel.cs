using Sensors.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sensors.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value;
                OnPropertyChange(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewComand { get; set; }

        public MainViewModel()
        {
            UpdateViewComand = new UpdateViewCommand(this);
        }
    }
}
