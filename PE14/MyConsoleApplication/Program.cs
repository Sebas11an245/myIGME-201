using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApplication
{
    public interface IMyInterface
    {
        void MyMethod();
    }

    public class MyClass1 : IMyInterface
    {
        public void MyMethod()
        {
            Console.WriteLine("This is MyClass1 implementing the interface.");
        }
    }

    public class MyClass2 : IMyInterface
    {
        public void MyMethod()
        {
            Console.WriteLine("This is MyClass2 implementing the interface.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of MyClass1 and MyClass2
            MyClass1 class1 = new MyClass1();
            MyClass2 class2 = new MyClass2();

            // Call MyMethod using the interface
            CallMyMethod(class1);
            CallMyMethod(class2);
        }

        // A method that accepts an object of a class that implements the interface
        public static void CallMyMethod(IMyInterface myObject)
        {
            myObject.MyMethod();
        }
    }
}
