using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    public interface IMood
    {
        string Mood 
        { 
            get; 
        }
    }

    public class Waiter : IMood
    {
        public string name;
        public string Mood 
        { 
            get; 
        }

        public void ServeCustomer(HotDrink cup)
        {
            Console.WriteLine("Here is your HotDrink, " + cup.customer.name + ".");
        }
    }

    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;
        public string Mood 
        {
            get;
        }
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public HotDrink()
        {
        }

        public HotDrink(string brand)
        {
        }

        public virtual void AddSugar(byte amount)
        {
        }

        public abstract void Steam();
    }

    public interface ITakeOrder
    {
        void TakeOrder();
    }

    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public CupOfCoffee(string brand) : base(brand)
        {
        }

        public override void Steam()
        {
        }

        public void TakeOrder()
        {
        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public CupOfTea(bool customerIsWealthy)
        {
        }

        public override void Steam()
        {
        }

        public void TakeOrder()
        {
        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;
        public string Source
        {
            set
            {
                this.source = value;
            }
        }

        public CupOfCocoa() : this(false)
        {
        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {
            this.marshmallows = marshmallows;
        }

        public override void Steam()
        {
        }

        public override void AddSugar(byte amount)
        {
        }

        public void TakeOrder()
        {
        }
    }
}
