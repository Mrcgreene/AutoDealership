using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealership
{
    public class Dealership
    {
        List<Vehicles> ourVehicles;
        Customer customer;
        Manufacturer manufacturer;
        public double bargainedPrice;
        public double hookupDiscount;

        public Dealership()
        {
            customer = new Customer();
            ourVehicles = new List<Vehicles>();
            manufacturer = new Manufacturer();
        }

        public void Start()
        {
            Greeting();
            FloorTour();
        }

        public void Greeting()                              //good
        {
            Console.WriteLine("We are having a wonderful day at Car Camp.");
        }

        public void FloorTour()                                //good
        {
            int decision;
            FillTheLot();
            manufacturer.PopulateInventory();
            Console.WriteLine("What brings you here today?");
            Console.WriteLine("(1) I'm looking for a new vehicle.");
            Console.WriteLine("(2) I'm a salesrep here.");
            Console.WriteLine("(3) I just stopped in to see when your hours of operations were.");
            decision = Convert.ToInt32(Console.ReadLine());
            if (decision == 1)
            {
                Console.WriteLine("What is your name please?");
                string purchaser = Console.ReadLine();
                Console.WriteLine("I think we will defintely be able to help you " + purchaser);
                Console.WriteLine("Please choose a 4 to 6 digit private number as an identification purposes.");
                int purchaserID = Convert.ToInt32(Console.ReadLine());
                Customer customer = new Customer(purchaser, purchaserID);
                CustomerOptions();
            }
            else if (decision == 2)
            {
                SalesrepOptions();
            }
            else if (decision == 3)
            {
                Console.WriteLine("Oh, we are here from 8:15am until 6:15pm Monday through Friday.");
                Console.WriteLine("You're welcome to come back anytime you feel...ask for Adam, Andrew or Mike.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That was an invalid entry.");
                Greeting();
            }
            Console.ReadLine();
        }

        public void CustomerOptions()
        {
            int decision;

            Console.WriteLine("So how can I help you today?");
            Console.WriteLine("(1) View the vehicles available.");
            Console.WriteLine("(2) Have a sales representative order more vehicles.");
            Console.WriteLine("(3) Test drive a vehicle.");
            Console.WriteLine("(4) Negotiate the price lower.");
            Console.WriteLine("(5) Purchase vehicle.");
            Console.WriteLine("(6) Leave the dealership.");

            decision = Convert.ToInt32(Console.ReadLine());
            if (decision == 1)
            {
                Console.WriteLine("Here are the vehicles in the showroom.");
                ViewVehicles();
            }
            else if (decision == 2)
            {
                manufacturer.ViewWherehouse();
                OrderVehiclesAddToList();
            }
            else if (decision == 3)
            {
                GiveTestDrive();
            }
            else if (decision == 4)
            {
                customer.HagglePrice();
            }
            else if (decision == 5)
            {
                VehicleTransaction(customer);                       //fix?
            }
            else if (decision == 6)
            {
                Console.WriteLine("Today just doesn't seem like a good day to buy a vehicle.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That was an invalid entry.");
                CustomerOptions();
            }
            CustomerOptions();
            Console.ReadKey();
        }

        public void VehicleTransaction(Customer customer)
        {
            //customer.PurchaseVehicle();
            SellVehicle();
        }

        public void SalesrepOptions()                               //good
        {
            int decision;
            Console.WriteLine("What would you like to do at the time?");
            Console.WriteLine("(1) Order vehicle(s) from the manufacturer.");
            Console.WriteLine("(2) View inventory of the dealership.");
            Console.WriteLine("(3) Inspect a vehicle.");
            Console.WriteLine("(4) Increase vehicle price.");
            Console.WriteLine("(5) Lower vehicle price.");
            Console.WriteLine("(6) Create a sales event.");
            Console.WriteLine("(7) Take a break from the floor.");
            decision = Convert.ToInt32(Console.ReadLine());
            if (decision == 1)
            {
                manufacturer.ViewWherehouse();
                OrderVehiclesAddToList();
                SalesrepOptions();
            }
            else if (decision == 2)
            {
                ViewVehicles();
            }
            else if (decision == 3)
            {
                TestVehicle();
            }
            else if (decision == 4)
            {
                ViewVehicles();
                IncreasePrice();
            }
            else if (decision == 5)
            {
                ViewVehicles();
                LowerPrice();
            }
            else if (decision == 6)
            {
                SalesEventDiscount();
            }
            else if (decision == 7)
            {
                FloorTour();
            }
            else
            {
                Console.WriteLine("That was an invalid entry.");
                SalesrepOptions();
            }
            Console.WriteLine("Do more during your shift or taking a break may work better for you.");
            Console.ReadKey();
            SalesrepOptions();
            Console.ReadLine();
        }

        public void ViewVehicles()                                      //good
        {
            foreach (Vehicles vehicle in ourVehicles)
            {
                Console.WriteLine(vehicle.vehicleMake + ":" + vehicle.vehicleColor + ":" + vehicle.vehicleType + " for $" + vehicle.VehiclePrice);
            }
            Console.ReadLine();
        }

        public void OrderVehiclesAddToList()                            //good
        {
            Console.WriteLine("Which vehicle have you chosen from the wherehouse?");
            Console.WriteLine();
            string pickedVehicle = Console.ReadLine();
            for (int i = 0; i < manufacturer.vehicles.Count; i++)
            {
                foreach (Vehicles vehicle in manufacturer.vehicles)
                {
                    if (pickedVehicle.Equals(vehicle.vehicleMake))
                    {
                        Console.WriteLine("The " + pickedVehicle + " is now at the dealership.");
                        ourVehicles.Add(vehicle);
                        OptOut();
                    }
                }

                //else if(pickedVehicle != vehicle.vehicleMake)
                //{
                //    Console.WriteLine("That vehicle is not in the wherehouse's list, please try again");
                //    OrderVehiclesAddToList();
                //}
            }
            Console.ReadKey();
        }

        public void OptOut()                                    //good
        {
            Console.WriteLine("Do you want to add another vehicle?");
            Console.WriteLine("Press 7 to add another vehicle.");
            Console.WriteLine("Press 8 to goto customer menu.");
            Console.WriteLine("Press 9 to exit to main menu.");
            int response = Convert.ToInt32(Console.ReadLine());
            if (response == 7)
            {
                OrderVehiclesAddToList();
            }
            else if (response == 8)
            {
                CustomerOptions();
            }
            else if (response == 9)
            {
                FloorTour();
            }
        }

        public void TestVehicle()                                   //good
        {
            ViewVehicles();
            Console.WriteLine("Which vehicle would you like to test?");
            string testingVehicle = Console.ReadLine();
            foreach (Vehicles vehicle in ourVehicles)
            {
                if (testingVehicle.Equals(vehicle.vehicleMake))
                {
                    vehicle.vehicleTest = true;
                    Console.WriteLine(testingVehicle + " has had the tires, brakes, hoses, belts, transmission, exhaust & wiring all tested by our mechanics and has passed inspection.");
                    Console.ReadKey();
                }
                //else
                //{
                //    Console.WriteLine("Please choose a different vehicle.");
                //    TestVehicle();
                //}
                //break;
            }
            SalesrepOptions();

        }

        public void GiveTestDrive()                         //good----possible switch case rand comments
        {
            ViewVehicles();
            Console.WriteLine("Which vehicle would you like to test drive?");
            string testDriving = Console.ReadLine();
            foreach (Vehicles vehicle in ourVehicles)
            {
                if (testDriving.Equals(vehicle.vehicleMake))
                {
                    Console.WriteLine("The " + testDriving + " perfomed smoothly during your drive.");
                    Console.WriteLine();
                }
                //else
                //{
                //    Console.WriteLine("Please choose a different vehicle.");
                //    GiveTestDrive();
                //}
                //break;
            }
            CustomerOptions();
        }
        //public double RequestedDiscount()
        //{
        //    Console.WriteLine("How much of a discount are you thinking about exactly?");
        //    double hookup;
        //    hookup = Convert.ToDouble(Console.ReadLine());
        //    if (hookup < 1000.00)
        //    {
        //        Console.WriteLine("I can work with that I guess.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Oh no buddy, I can't do that much off.");
        //        RequestedDiscount();
        //    }
        //    return hookupDiscount;
        //}

        //public string ride;
        public void SellVehicle()                           //fix
        {
            Console.WriteLine("Which vehicle was that again you picked out");
            string chosenVehicle = Console.ReadLine();
            for (int i = 0; i < manufacturer.vehicles.Count; i++)
            {
                foreach (Vehicles vehicle in ourVehicles)
                {
                    if (chosenVehicle.Equals(vehicle.vehicleMake))
                    {
                        Console.WriteLine("You are now the new proud owner of a " + chosenVehicle);
                        //Console.WriteLine("The purchase price was " + chosenVehicle);
                        Console.WriteLine("Here are your keys.");
                        Console.ReadKey();
                        Console.WriteLine("Please come see us again and tell a friend. Have a good day!");
                        ourVehicles.Remove(vehicle);
                    }
                    //else
                    //{
                    //    Console.WriteLine("That car was not yours to sell.");
                    //    SellVehicle();
                    //}
                    
                }
            }
            Environment.Exit(0);


        }

        public void PurchaseVehicle(Customer customer)                  //fix
        {
            Console.WriteLine("");
        }

        public void IncreasePrice()                                 //good
        {
            Console.WriteLine("Which vehicle's value needs to reflect the increase in the market?");
            string increasingVehicle = Console.ReadLine();
            foreach (Vehicles vehicle in ourVehicles)
            {
                if (increasingVehicle.Equals(vehicle.vehicleMake))
                {
                    vehicle.VehiclePrice += 550.00;
                    Console.WriteLine("The new price of the " + vehicle.vehicleMake + " is $" + vehicle.VehiclePrice);
                    Console.ReadLine();
                }
                //else
                //{
                //    Console.WriteLine("Please choose a different vehicle.");
                //    IncreasePrice();
                //}
                //break;
            }
            SalesrepOptions();
        }

        public void LowerPrice()                                    //good
        {
            Console.WriteLine("Which vehicle needs to reflect decreased market value?");
            string decreasingVehicle = Console.ReadLine();
            foreach (Vehicles vehicle in ourVehicles)
            {
                if (decreasingVehicle.Equals(vehicle.vehicleMake))
                {
                    vehicle.VehiclePrice -= 1250.00;
                    Console.WriteLine("The new price of the " + vehicle.vehicleMake + " is $" + vehicle.VehiclePrice);
                    Console.ReadLine();
                }
                //else
                //{
                //    Console.WriteLine("Please choose a different vehicle.");
                //    LowerPrice();
                //}
                //break;
            }
            SalesrepOptions();
        }

        public void FillTheLot()                                    //good
        {
            ourVehicles.Add(new SUV("Jeep", "SUV", "Brown", true, 16000.00));
            ourVehicles.Add(new SUV("Lincoln", "SUV", "Tan", true, 25000.00));
            ourVehicles.Add(new Sedan("Chrysler", "Sedan", "Silver", true, 19750.00));
            ourVehicles.Add(new Sedan("Acura", "Sedan", "Forest Green", true, 18000.00));
            ourVehicles.Add(new Luxury("Jaguar", "Luxury", "Black", true, 27000.00));
            ourVehicles.Add(new Sedan("Volvo", "Sedan", "Red", true, 21000.00));
            ourVehicles.Add(new Hybrid("Scion", "Hybrid", "Pink", true, 20750.00));
            ourVehicles.Add(new Sports("Chevrolet", "Sports", "Blue", true, 23000.00));

        }

        public void SalesEventDiscount()                            //good
        {
            ViewVehicles();
            double saleEventPrice;
            string saleEventMake;
            Console.WriteLine("Which make of vehicle would you like to place on sale for a week?");
            saleEventMake = Console.ReadLine();
            Console.WriteLine("How much will the price drop for a week?");
            saleEventPrice = Convert.ToDouble(Console.ReadLine());

            foreach (Vehicles vehicle in ourVehicles)
            {
                if (vehicle.vehicleMake == saleEventMake)
                {
                    vehicle.VehiclePrice -= saleEventPrice;
                }
            }
            Console.WriteLine("The price of the " + saleEventMake + "'s has been discounted by $" + saleEventPrice);
            ViewVehicles();

        }
    }
}



