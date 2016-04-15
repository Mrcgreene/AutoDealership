using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealership
{
    public class Manufacturer
    {
        public List<Vehicles> vehicles;

        public Manufacturer()
        {
            vehicles = new List<Vehicles>();
        }

        public void PopulateInventory()                         //good
        {
            SUV redSUV = new SUV("Toyota","SUV","Red", false, 18500.00);
            vehicles.Add(redSUV);
            Sports redSports = new Sports("Dodge", "Sports","Red", true, 21500.00);
            vehicles.Add(redSports);
            SUV blueSUV = new SUV("GMC", "SUV","Blue", true, 18000.00);
            vehicles.Add(blueSUV);
            Hybrid orangeHybrid = new Hybrid("Hyundai", "Hybrid","Orange", true, 19500.00);
            vehicles.Add(orangeHybrid);
            Sedan blueSedan = new Sedan("Chevrolet", "Sedan","Blue", false, 17250.00);
            vehicles.Add(blueSedan);
            SUV blackSUV = new SUV("Chevy", "SUV","Black", true, 19000.00);
            vehicles.Add(blackSUV);
            Sports silverSports = new Sports("Mitsubishi","Sports","Silver", true, 22500.00);
            vehicles.Add(silverSports);
            SUV whiteSUV = new SUV("Cadillac", "SUV","White", false, 19000.00);
            vehicles.Add(whiteSUV);
            SUV greySUV = new SUV("Infinity", "SUV","Grey", true, 18000.00);
            vehicles.Add(greySUV);
            Sedan greenSedan = new Sedan("Subaru", "Sedan","Green", true, 17000.00);
            vehicles.Add(greenSedan);
            Hybrid neonHybrid = new Hybrid("Honda", "Hybrid", "Neon", true, 20000.00);
            vehicles.Add(neonHybrid);
            Sedan redSedan = new Sedan("Nissan", "Sedan","Red", true, 17500.00);
            vehicles.Add(redSedan);
            Luxury champagneLux = new Luxury("Mercedes", "Luxury", "Champagne", true, 52000.00);
            vehicles.Add(champagneLux);
            Luxury pearlLux = new Luxury("BMW", "Luxury", "Pearl", false, 48500.00);
            vehicles.Add(pearlLux);
        }

        public void ViewWherehouse()                                      //good
        {
            foreach (Vehicles vehicle in vehicles)
            {
                Console.WriteLine(vehicle.vehicleMake + ":" + vehicle.vehicleColor + ":" + vehicle.vehicleType + " for $" + vehicle.VehiclePrice);
            }
            
        }

    }
}
