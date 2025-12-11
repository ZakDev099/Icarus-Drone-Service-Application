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

        private string selectedQueue = "Regular";
        public string SelectedQueue
        {
            get => selectedQueue;
            set
            {
                selectedQueue = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ActiveQueue));
            }
        }
        public IEnumerable<Drone> ActiveQueue
        {
            get
            {
                return SelectedQueue switch
                {
                    "Regular" => RegularService.ToArray(),
                    "Express" => ExpressService.ToArray(),
                    _ => ReturnWithFeedback(RegularService).ToArray()
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

        private Drone? selectedDrone = null;
        public Drone? SelectedDrone
        {
            get => selectedDrone;
            set
            {
                if (selectedDrone != value)
                {
                    selectedDrone = value;
                    if (selectedDrone != null)
                    {
                        OpenDroneForm(selectedDrone.ClientName, selectedDrone.ServiceProblem);
                    }

                    OnPropertyChanged();
                }
            }
        }

        private Drone? droneForDeletion = null;
        public Drone? DroneForDeletion
        {
            get { return droneForDeletion; }
            set
            {
                if (droneForDeletion != value)
                {
                    droneForDeletion = value;
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
                    if (value == null)
                    {
                        SelectedDrone = null;
                    }

                    activeDroneForm = value;
                    OnPropertyChanged();
                }
            }
        }

        private int serviceTagTracker = 100;
        public int ServiceTagTracker
        {
            get => serviceTagTracker;
            set
            {
                if (value > 900)
                {
                    serviceTagTracker = 100;
                }
                else
                {
                    serviceTagTracker = value;
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

        // 6.14 ::
        public ICommand Cmd_SetActiveQueueToRegular => new RelayCommand(() => SelectedQueue = "Regular");
        // 6.15 ::
        public ICommand Cmd_SetActiveQueueToExpress => new RelayCommand(() => SelectedQueue = "Express");

        public ICommand Cmd_MoveDroneToFinishedList => new RelayCommand(DequeueActiveQueue);
        public ICommand Cmd_OpenDroneForm => new RelayCommand(OpenDroneForm);
        public ICommand Cmd_CloseDroneForm => new RelayCommand(CloseDroneForm);
        public ICommand Cmd_AddNewItem => new RelayCommand(AddNewItem);


        // ======== METHODS =========


        private Queue<Drone> ReturnWithFeedback(Queue<Drone> input)
        {
            FeedbackMessage = "An error occured while attempting to show the drone queue";
            return input;
        }

        // 6.17 :: (Drone form is removed, along with all textbox data)
        private void CloseDroneForm() => ActiveDroneForm = null;
        private void OpenDroneForm() => ActiveDroneForm = new(serviceTagTracker);

        // 6.12 & 6.13 ::
        private void OpenDroneForm(string? clientName, string? serviceProblem)
        {
            ActiveDroneForm = new(serviceTagTracker, clientName, serviceProblem);
        }

        // Dequeues and moves drone from active queue into finished list
        private void DequeueActiveQueue()
        {
            if (SelectedQueue == "Regular" && RegularService.Count > 0)
            {
                FinishedList.Add(RegularService.Dequeue());
                FinishedList = new List<Drone>(FinishedList);
                OnPropertyChanged(nameof(ActiveQueue));
            }
            else if (SelectedQueue == "Express" && ExpressService.Count > 0)
            {
                FinishedList.Add(ExpressService.Dequeue());
                FinishedList = new List<Drone>(FinishedList);
                OnPropertyChanged(nameof(ActiveQueue));
            }
            else
            {
                FeedbackMessage = "An error occured while attempting to move drone to finished list";
            }
        }

        // 6.16 ::
        public void DeleteDroneFromFinishedList()
        {
            if (DroneForDeletion != null && finishedList.Contains(DroneForDeletion))
            {
                FinishedList.Remove(DroneForDeletion);
                FinishedList = new List<Drone>(FinishedList);
                DroneForDeletion = null;
            }
            else
            {
                FeedbackMessage = "An error occured while attempting to delete drone from finished list";
            }
        }

        // 6.5 :: (Invoked using UI Command) -> UserControls.DroneFormControl
        private void AddNewItem()
        {
            if (ActiveDroneForm != null && ActiveDroneForm.TryMakeDrone() == true)
            {
                if (ActiveDroneForm.GetServicePriority())
                {
                    IncrementServiceTag();
                    ExpressService.Enqueue(ActiveDroneForm.NewDrone!);
                    OnPropertyChanged(nameof(ActiveQueue));
                    CloseDroneForm();
                }
                else
                {
                    IncrementServiceTag();
                    RegularService.Enqueue(ActiveDroneForm.NewDrone!);
                    OnPropertyChanged(nameof(ActiveQueue));
                    CloseDroneForm();
                }
            }
            else
            {
                return;
            }
        }

        // 6.11 :: Create a custom method to increment the service tag control,
        //      :: this method must be called inside the “AddNewItem” method before the new service
        //      :: item is added to a queue. 
        private void IncrementServiceTag()
        {
            ServiceTagTracker += 10;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
