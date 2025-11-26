using Icarus_Drone_Service_Application.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Icarus_Drone_Service_Application.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public DroneFormViewModel? ActiveDroneForm = null;
        private Queue<Drone> regularService = new();
        private Queue<Drone> expressService = new();
        public Queue<Drone>? ActiveQueue { get; set; }
        public List<Drone> FinishedList { get; set; } = new();
        private readonly double droneCostModifier = 1.15;

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public void AddNewItem()
        {

        }

        public void MoveToFinishedList(Queue<Drone> droneQueue)
        {

        }
    }
}
