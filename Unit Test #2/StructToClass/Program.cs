using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructToClass
{
    //Class: Friend
    //Author: Sebastian Arroyo
    //Purpose: Friend Struct
    //Restrictions: None
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    }
    //Class: Program
    //Author: Sebastian Arroyo
    //Purpose: Main
    //Restrictions: None
    class Program
    {
        //Method: Main
        //Purpose: Create friend Charlie Sheen and make them my enemy
        //Restrictions: None
        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy = new Friend();

            // Create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // Now he has become my enemy
            enemy = friend;

            // Set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender. Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}
