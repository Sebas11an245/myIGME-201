using System;
using Vehicles;

namespace Traffic
{
    class Traffic
    {
        static void Main(string[] args)
        {
            // create object that inherits IPassengerCarrier
            Compact compact = new Compact();

            // create object that does not inherit IPassengerCarrier
            FreightTrain freightTrain = new FreightTrain();

            // we can pass compact to the function because it inherits the interface
            AddPassenger(compact);

            // we cannot pass freighTrain to the function because it does not inherit the interface
            AddPassenger(freightTrain);
        }

        public static void AddPassenger(IPassengerCarrier vehicleObject)
        {
            //call method
            vehicleObject.LoadPassenger();

            //use ToString() method
            Console.WriteLine(vehicleObject.ToString());
        }
    }
}

