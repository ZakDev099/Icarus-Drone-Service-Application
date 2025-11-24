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
    public class DroneFormViewModel : INotifyPropertyChanged
    {
        public Drone? NewDrone = null;
        public string? ServiceTag { get; set; }
        public string? ClientName { get; set; }
        public string? DroneModel { get; set; }
        public string? ServiceProblem { get; set; }
        public string? ServiceCost { get; set; }

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
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public bool CreateDrone()
        {
            // Validating properties of the new drone
            if (ServiceTag == null || !Int32.TryParse(ServiceTag, out var validatedServiceTag))
            {
                UserFeedback = "ERROR: Service tag is empty or invalid";
                return false;
            }
            if (ServiceCost == null || !Double.TryParse(ServiceCost, out var validatedServiceCost))
            {
                UserFeedback = "ERROR: Service cost is empty or invalid";
                return false;
            }
            if (ClientName == null)
            {
                UserFeedback = "ERROR: Client name is empty";
                return false;
            }
            if (DroneModel == null)
            {
                UserFeedback = "ERROR: Drone model is empty";
                return false;
            }
            if (ServiceProblem == null)
            {
                UserFeedback = "ERROR: Service problem is empty";
                return false;
            }
            string validatedClientName = Utils.ToTitleCase(ClientName);
            string validatedServiceProblem = Utils.ToSentenceCase(ServiceProblem);

            NewDrone = new(validatedServiceTag, ClientName, DroneModel, ServiceProblem, validatedServiceCost);
            return true;
        }
    }
}
