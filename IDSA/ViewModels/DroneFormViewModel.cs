using Icarus_Drone_Service_Application.Models;
using Icarus_Drone_Service_Application.Resources;
using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Icarus_Drone_Service_Application.ViewModels
{
    public class DroneFormViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public Drone? NewDrone = null;
        public int ServiceTag { get; set; }
        public string? ClientName { get; set; }
        public string? DroneModel { get; set; }
        public string? ServiceProblem { get; set; }

        private string? serviceCost;
        public string? ServiceCost 
        {
            get => serviceCost;
            set 
            { 
                serviceCost = value;
                OnPropertyChanged();
                ValidateProperty(nameof(ServiceCost), serviceCost);
            }
        }
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

        private Dictionary<string, List<string>> propertyErrors = new();


        // ======== Constructors =========


        public DroneFormViewModel(int serviceTag)
        {
            this.ServiceTag = serviceTag;
        }

        public DroneFormViewModel(int serviceTag, string? clientName, string? serviceProblem)
        {
            this.ServiceTag = serviceTag;
            this.ClientName = clientName;
            this.ServiceProblem = serviceProblem;
        }


        // ===== INotifyDataErrorInfo =====


        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !propertyErrors.ContainsKey(propertyName))
            {
                return new List<string>();
            }
            return propertyErrors[propertyName];
        }

        public bool HasErrors => propertyErrors.Values.Any(list => list.Count > 0);

        private void ValidateProperty(string propertyName, string? value)
        {

            if (propertyErrors.ContainsKey(propertyName))
            {
                propertyErrors[propertyName].Clear();
            }
            else
            {
                propertyErrors[propertyName] = new List<string>();
            }

            if (propertyName == nameof(ServiceCost))
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    propertyErrors[propertyName].Add("Service cost cannot be empty.");
                }
                else
                {
                    var validation = new TwoDecimalValidation();
                    var result = validation.Validate(value, CultureInfo.CurrentCulture);

                    if (!result.IsValid)
                    {
                        propertyErrors[propertyName].Add(result.ErrorContent?.ToString() ?? "Invalid service cost.");
                    }
                }
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }


        // ===== INotifyPropertyChanged =====


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        // ======== METHODS =========


        public bool TryMakeDrone()
        {
            // Validating properties of the new drone


            // Validating ServiceCost Textbox has no errors
            if (HasErrors || !double.TryParse(ServiceCost, out double validatedServiceCost))
            {
                UserFeedback = "Input is invalid, expecting a numerical value with two decimal places.";
                return false;
            }

            // 6.6 :: "Before a new service item is added to the Express Queue the service cost must be increased by 15%"
            if (PriorityExpress)
            {
                validatedServiceCost = Math.Round(validatedServiceCost * ExpressFee, 2);
            }
            
            // Validating other drone properties
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
