using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Icarus_Drone_Service_Application.Models
{
    public class Drone
    {
        private int serviceTag;
        private string clientName;
        private string droneModel;
        private string serviceProblem;
        private double serviceCost;

        public Drone(int serviceTag, string clientName, string droneModel, string serviceProblem, double serviceCost)
        {
            this.serviceTag = serviceTag;
            this.clientName = clientName;
            this.droneModel = droneModel;
            this.serviceProblem = serviceProblem;
            this.serviceCost = serviceCost;
        }

        public int ServiceTag { get => serviceTag; set => serviceTag = value; }
        public string ClientName { get => Utils.ToTitleCase(clientName); set => clientName = value; }
        public string DroneModel { get => droneModel; set => droneModel = value; }
        public string ServiceProblem { get => Utils.ToSentenceCase(serviceProblem); set => serviceProblem = value; }
        public double ServiceCost { get => serviceCost; set => serviceCost = value; }

        // Property for the XAML to reference
        public string ClientNameAndServiceCost => DisplayClientNameAndServiceCost();


        // 6.1 :: "Add a display method that returns a string for Client Name and Service Cost" - changed to public
        public string DisplayClientNameAndServiceCost()
        {
            return $"Client Name: {ClientName}\nCost: {ServiceCost}";
        }
    }
}
