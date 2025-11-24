using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Icarus_Drone_Service_Application.Models
{
    public class Drone(int serviceTag, string clientName, string droneModel, string serviceProblem, double serviceCost)
    {
        public int ServiceTag { get; } = serviceTag;
        public string ClientName { get; } = clientName;
        public string DroneModel { get; } = droneModel;
        public string ServiceProblem { get; } = serviceProblem;
        private readonly double serviceCost = serviceCost;
        public double ServiceCost => serviceCost * serviceCostModifier;
        private readonly double serviceCostModifier = 1.15;
    }
}
