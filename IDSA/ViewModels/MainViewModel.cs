using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icarus_Drone_Service_Application.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public DroneFormViewModel? ActiveDroneForm = null;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
