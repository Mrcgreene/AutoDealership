using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealership
{
    public abstract class Vehicles
    {
        public string vehicleType;
        public string vehicleColor;
        protected double vehiclePrice;
        public string vehicleMake;
        public bool vehicleTest;

        public double VehiclePrice
        {
            get
            {
                return vehiclePrice;
            }

            set
            {
                vehiclePrice = value;
            }
        }

        public Vehicles()
        {

        }
    }
}
