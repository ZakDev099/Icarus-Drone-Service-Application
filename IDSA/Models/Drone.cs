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
    public class Drone
    {
        private readonly int serviceTag;
        public int ServiceTag => serviceTag;

        private readonly string clientName;
        public string ClientName => Utils.ToTitleCase(clientName);

        private readonly string droneModel;
        public string DroneModel => droneModel;

        private readonly string serviceProblem;
        public string ServiceProblem => Utils.ToSentenceCase(serviceProblem);

        private readonly double serviceCost;
        public double ServiceCost => serviceCost;
        private const double expressServiceFee = 0.15;

        public Drone(int serviceTag, string clientName, string droneModel, string serviceProblem, double serviceCost, bool applyFee = false)
        {
            this.serviceTag = serviceTag;
            this.clientName = clientName;
            this.droneModel = droneModel;
            this.droneModel = serviceProblem;
            this.serviceProblem = serviceProblem;

            if (applyFee)
            {
                this.serviceCost = serviceCost * (1 + expressServiceFee);
            }
            else
            {
                this.serviceCost = serviceCost;
            }
        }


        // 6.1 ::
        public (string, double) DisplayClientNameAndServiceCost()
        {
            return (ClientName, ServiceCost);
        }
    }
}
