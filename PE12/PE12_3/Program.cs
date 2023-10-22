using System;
namespace PE12_3
{
    public class MyClass
    {
        private string myString;
        public string MyString
        {
            set
            {
                this.myString = value;
            }
        }
        public virtual string GetString()
        {
            return this.myString;
        }
    }
    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass myDerivedClass = new MyDerivedClass();
            myDerivedClass.MyString = "supercalifragilisticexpialidocious";
            Console.WriteLine(myDerivedClass.GetString());
        }
    }
}