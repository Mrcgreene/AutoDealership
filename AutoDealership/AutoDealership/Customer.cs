using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealership
{
    public class Customer
    {
        public string name;
        private int identificationNumber;
        public double hookupDiscount;

        public Customer(string Name, int IdentificatonNumber)
        {
            name = Name;
            identificationNumber = IdentificatonNumber;
        }
        public Customer()
        {
            name = null;
        }

        public double HagglePrice()
        {
            Console.WriteLine("How much of a discount are you thinking about?");
            double hookup;
            hookup = Convert.ToDouble(Console.ReadLine());
            if (hookup < 1000.00)
            {
                Console.WriteLine("I can work with that I guess.");
            }
            else
            {
                Console.WriteLine("Oh no buddy, I can't do that much off.");
                HagglePrice();
            }
            return hookupDiscount;
        }
        //public void PurchaseVehicle()
        //{

        //    Console.WriteLine(name + " is the new proud owner of a " + "");        //fix

        //    Environment.Exit(0);
        //}
 
    }
}
