using Icarus_Drone_Service_Application.Models;
using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Icarus_Drone_Service_Application.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // 6.3 :: "Create a 'global' Queue<T> of type Drone called 'RegularService'" -> therefore I have it public
        public Queue<Drone> RegularService = [];
        // 6.4 :: "Create a 'global' Queue<T> of type Drone called 'ExpressService'” -> therefore I have it public
        public Queue<Drone> ExpressService = [];
        public int SelectedQueue { get; set; }
        public Queue<Drone> ActiveQueue
        {
            get
            {
                return SelectedQueue switch
                {
                    0 => RegularService,
                    1 => ExpressService,
                    _ => ReturnWithFeedback(RegularService)
                };
            }
        }

        private List<Drone> finishedList = [];
        // 6.2 ::
        public List<Drone> FinishedList
        {
            get => finishedList;
            set
            {
                if (finishedList != value)
                {
                    finishedList = value;
                    OnPropertyChanged();
                }
            }
        }

        private DroneFormViewModel? activeDroneForm = null;
        public DroneFormViewModel? ActiveDroneForm
        {
            get => activeDroneForm;
            set
            {
                if (activeDroneForm != value)
                {
                    activeDroneForm = value;
                    OnPropertyChanged();
                }
            }
        }

        private string feedbackMessage = "";
        public string FeedbackMessage
        {
            get => feedbackMessage;
            set
            {
                if (feedbackMessage != value)
                {
                    feedbackMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        // ====== UI COMMANDS ======


        public ICommand Cmd_SetActiveQueueToRegular => new RelayCommand(() => SelectedQueue = 0);
        public ICommand Cmd_SetActiveQueueToExpress => new RelayCommand(() => SelectedQueue = 1);
        public ICommand Cmd_OpenDroneForm => new RelayCommand(OpenDroneForm);
        public ICommand Cmd_CloseDroneForm => new RelayCommand(CloseDroneForm);



        // ======== METHODS =========


        private Queue<Drone> ReturnWithFeedback(Queue<Drone> input)
        {
            FeedbackMessage = "An error occured while attempting to show the drone queue";
            return input;
        }

        private void OpenDroneForm() => ActiveDroneForm = new();
        private void CloseDroneForm() => ActiveDroneForm = null;

        // 6.5 :: (Invoked using UI Command) -> UserControls.DroneFormControl
        private void AddNewItem()
        {
            // If adding to Express Queue, remember to add +15% modifier when building the drone
            if (ActiveDroneForm != null && ActiveDroneForm.MakeDrone() == true)
            {
                // 6.7 :: Create a custom method called “GetServicePriority” which returns the value of the priority radio group
                // -> This naming is unclear and confusing but is required
                if (ActiveDroneForm.GetServicePriority())
                {
                    ExpressService.Enqueue(ActiveDroneForm.NewDrone);
                }
                else
                {
                    RegularService.Enqueue(ActiveDroneForm.NewDrone);
                }
            }
            else
            {
                return;
            }

            
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
