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
        private readonly int serviceTag = serviceTag;
        public int ServiceTag => serviceTag;

        private readonly string clientName = clientName;
        public string ClientName => Utils.ToTitleCase(clientName);

        private readonly string droneModel = droneModel;
        public string DroneModel => droneModel;

        private readonly string serviceProblem = serviceProblem;
        public string ServiceProblem => Utils.ToSentenceCase(serviceProblem);

        private readonly double serviceCost = serviceCost;
        public double ServiceCost => serviceCost;

        // Added property for the XAML to reference
        public string ClientNameAndServiceCost => DisplayClientNameAndServiceCost();


        // 6.1 :: "Add a display method that returns a string for Client Name and Service Cost"
        private string DisplayClientNameAndServiceCost()
        {
            return $"Client Name: {ClientName}\nCost: {ServiceCost}";
        }
    }
}
