using Icarus_Drone_Service_Application.Models;
using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Icarus_Drone_Service_Application.ViewModels
{
    public class DroneFormViewModel(int serviceTag) : INotifyPropertyChanged
    {
        public Drone? NewDrone = null;
        public int ServiceTag => serviceTag;
        public string? ClientName { get; set; }
        public string? DroneModel { get; set; }
        public string? ServiceProblem { get; set; }
        public string? ServiceCost { get; set; }
        private readonly double ExpressFee = 1.15;

        private string? userFeedback;
        public string? UserFeedback
        {
            get => userFeedback;
            set
            {
                if (userFeedback != value)
                {
                    userFeedback = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool priorityRegular = true;
        public bool PriorityRegular
        {
            get => priorityRegular;
            set
            {
                if (priorityRegular != value)
                {
                    priorityRegular = value;
                    OnPropertyChanged();
                    if (value) PriorityExpress = false;
                }
            }
        }

        private bool priorityExpress = false;
        public bool PriorityExpress
        {
            get => priorityExpress;
            set
            {
                if (priorityExpress != value)
                {
                    priorityExpress = value;
                    OnPropertyChanged();
                    if (value) PriorityRegular = false;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        // ======== METHODS =========


        public bool TryMakeDrone()
        {
            // Validating properties of the new drone
            if (string.IsNullOrWhiteSpace(ServiceCost) || !Double.TryParse(ServiceCost, out var validatedServiceCost))
            {
                UserFeedback = "ERROR: Service cost is empty or invalid";
                return false;
            }
            // 6.6 :: "Before a new service item is added to the Express Queue the service cost must be increased by 15%"
            //     :: Yes, this occurs before the item is added to the express queue.
            if (PriorityExpress)
            {
                validatedServiceCost *= ExpressFee;
            }
            validatedServiceCost = Utils.LimitDecimalPlace(validatedServiceCost, 2);

            if (string.IsNullOrWhiteSpace(ClientName))
            {
                UserFeedback = "ERROR: Client name is empty or invalid";
                return false;
            }
            if (string.IsNullOrWhiteSpace(DroneModel))
            {
                UserFeedback = "ERROR: Drone model is empty or invalid";
                return false;
            }
            if (string.IsNullOrWhiteSpace(ServiceProblem))
            {
                UserFeedback = "ERROR: Service problem is empty or invalid";
                return false;
            }

            try
            {
                NewDrone = new(ServiceTag, ClientName, DroneModel, ServiceProblem, validatedServiceCost);
            }
            catch (Exception ex)
            {
                UserFeedback = $"ERROR: Item creation failed. \n{ex.Message}";
                return false;
            }
            
            return true;
        }

        // 6.7 :: Create a custom method called “GetServicePriority” which returns the value of the priority radio group
        // -> This naming is unclear and confusing but required. I would just use a getter or name it something like "IsExpressPriority()".
        public bool GetServicePriority()
        {
            return PriorityExpress;
        }
    }
}
