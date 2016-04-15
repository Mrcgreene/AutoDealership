using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealership
{
    public class Hybrid : Vehicles
    {
        public Hybrid(string VehicleMake, string VehicleType, string VehicleColor, bool VehicleTest, double VehiclePrice)
        {
            vehicleMake = VehicleMake;
            vehicleType = VehicleType;
            vehicleColor = VehicleColor;
            vehicleTest = VehicleTest;
            vehiclePrice = VehiclePrice;
        }
    }
}
