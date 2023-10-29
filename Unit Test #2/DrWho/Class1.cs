using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrWho
{
    public class Program
    {

        public abstract class Phone
        {
            private string phoneNumber;
            public string address;

            public string PhoneNumber;
            public abstract void Connect();
            public abstract void Disconnect();
        }
        public interface PhoneInterface
        {
            void Answer();
            void MakeCall();
            void HangUp();
        }
        public class RotaryPhone : Phone, PhoneInterface
        {
            public void Answer()
            {

            }
            public void MakeCall()
            {

            }
            public void HangUp()
            {

            }
            public override void Connect()
            {
                throw new NotImplementedException();
            }
            public override void Disconnect()
            {
                throw new NotImplementedException();
            }
        }
        public class PushButtonPhone : Phone, PhoneInterface
        {
            public void Answer()
            {

            }
            public void MakeCall()
            {

            }
            public void HangUp()
            {

            }
            public override void Connect()
            {
                throw new NotImplementedException();
            }
            public override void Disconnect()
            {
                throw new NotImplementedException();
            }
        }
        public class Tardis : RotaryPhone
        {
            private bool sonicScrewdriver;
            private byte whichDrWho;
            private string femaleSideKick;
            public double exteriorSurfaceArea;
            public double interiorVolume;

            public byte WhichDrWho { get; }
            public string FemaleSideKick { get; }
            public void TimeTravel()
            {
                throw new NotImplementedException();
            }
            public Tardis(byte drWho)
            {
                WhichDrWho = drWho;
            }
            public static bool operator ==(Tardis t1, Tardis t2)
            {
                if (t1 is null)
                {
                    return t2 is null;
                }

                if (t2 is null)
                {
                    return false;
                }

                if (t1.WhichDrWho == 10)
                {
                    return true;
                }

                if (t2.WhichDrWho == 10)
                {
                    return false;
                }

                return t1.WhichDrWho == t2.WhichDrWho;
            }

            public static bool operator !=(Tardis t1, Tardis t2)
            {
                return !(t1 == t2);
            }

            public static bool operator <(Tardis t1, Tardis t2)
            {
                if (t1 is null || t2 is null)
                {
                    throw new ArgumentNullException("Tardis objects cannot be compared to null.");
                }

                if (t1.WhichDrWho == 10)
                {
                    return false;
                }

                if (t2.WhichDrWho == 10)
                {
                    return true;
                }

                return t1.WhichDrWho < t2.WhichDrWho;
            }

            public static bool operator >(Tardis t1, Tardis t2)
            {
                return t2 < t1;
            }

            public static bool operator <=(Tardis t1, Tardis t2)
            {
                return t1 == t2 || t1 < t2;
            }

            public static bool operator >=(Tardis t1, Tardis t2)
            {
                return t1 == t2 || t1 > t2;
            }
        }
        public class PhoneBooth : PushButtonPhone
        {
            private bool superMan;
            public double costPerCall;
            public bool phoneBook;

            public void OpenDoor()
            {

            }
            public void CloseDoor()
            {

            }
        }
        static void Main(string[] args)
        {
            // Create a Tardis object
            Tardis tardis = new Tardis(10);

            // Create a PhoneBooth object
            PhoneBooth phoneBooth = new PhoneBooth();

            // Use the UsePhone method to call MakeCall and HangUp
            UsePhone(tardis);
            UsePhone(phoneBooth);
        }

        static void UsePhone(object obj)
        {
            // Check if the object implements the PhoneInterface
            if (obj is PhoneInterface phone)
            {
                Console.WriteLine("Using phone:");
                phone.MakeCall();
                phone.HangUp();

                if (obj is PhoneBooth phoneBooth)
                {
                    Console.WriteLine("This is a PhoneBooth.");
                    phoneBooth.OpenDoor();
                }
                else if (obj is Tardis tardis)
                {
                    Console.WriteLine("This is a Tardis.");
                    tardis.TimeTravel();
                }
            }
            else
            {
                Console.WriteLine("The object does not implement the PhoneInterface.");
            }
        }
    }
}
