using Icarus_Drone_Service_Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Icarus_Drone_Service_Application.Models
{
    // 6.1 :: No setters were needed as the object is not required to be mutable or expected to change after construction
    public class Drone(int serviceTag, string clientName, string droneModel, string serviceProblem, double serviceCost)
    {
        private int serviceTag = serviceTag;
        public int ServiceTag
        {
            get { return serviceTag; }
            set { serviceTag = value; }
        }

        private string clientName = clientName;
        public string ClientName
        {
            get { return Utils.ToTitleCase(clientName); }
            set { clientName = value; }
        }

        private string droneModel = droneModel;
        public string DroneModel
        {
            get { return droneModel; }
            set { droneModel = value; }
        }

        private string serviceProblem = serviceProblem;
        public string ServiceProblem
        {
            get { return Utils.ToSentenceCase(serviceProblem); }
            set { serviceProblem = value; }
        }

        private double serviceCost = serviceCost;
        public double ServiceCost
        {
            get { return serviceCost; }
            set { serviceCost = value; }
        }

        // Added property for the XAML to reference
        public string ClientNameAndServiceCost => DisplayClientNameAndServiceCost();


        // 6.1 :: "Add a display method that returns a string for Client Name and Service Cost"
        private string DisplayClientNameAndServiceCost()
        {
            return $"Client Name: {ClientName}\nCost: {ServiceCost}";
        }
    }
}
