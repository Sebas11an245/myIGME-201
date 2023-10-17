using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public abstract class Pet 
    {
        private string name;
        public int age;

        public string Name;
        public abstract void Eat();
        public abstract void Play();
        public abstract void GoToVet();
        public Pet() 
        {

        }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

    }
    public class Pets
    {
        public List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        public int Count 
        {
            get
            {
                return petList.Count;
            }
        
        }
        public void Add(Pet pet)
        {
            petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
    }
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine($"{Name} is munching.");
        }
        public override void Play()
        {
            Console.WriteLine($"{Name}'s playtime.");

        }
        public void Purr()
        {
            Console.WriteLine($"{Name} purrs.");

        }
        public void Scratch()
        {
            Console.WriteLine($"{Name} attacks.");

        }
        public override void GoToVet()
        {
            Console.WriteLine($"{Name} is sick.");

        }
        public Cat()
        {
           
        }

    }
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    public class Dog : Pet, IDog
    {
        public string license;

        public override void Eat()
        {
            Console.WriteLine($"{Name} is munching.");

        }
        public override void Play()
        {
            Console.WriteLine($"{Name} loves to play.");

        }
        public void Bark()
        {
            Console.WriteLine($"{Name} barks.");

        }
        public void NeedToWalk()
        {
            Console.WriteLine($"{Name} wants to go outside.");

        }
        public override void GoToVet()
        {
            Console.WriteLine($"{Name} is sick.");

        }
        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }
    }
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedToWalk();
        void GoToVet();
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for (int i = 1; i <= 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                        Console.Write("License => ");
                        string license = Console.ReadLine();
                        Console.Write("Name => ");
                        string name = Console.ReadLine();
                        Console.Write("Age => ");
                        int age = int.Parse(Console.ReadLine());
                        dog = new Dog(license, name, age);
                        pets.Add(dog);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        cat = new Cat();
                        Console.Write("Name => ");
                        cat.Name = Console.ReadLine();
                        Console.Write("Age => ");
                        cat.age = int.Parse(Console.ReadLine());
                        pets.Add(cat);
                    }
                }
                else
                {
                    try 
                    { 
                        thisPet = pets[rand.Next(0, pets.Count-1)];
                    }
                    catch 
                    {
                        continue;
                    }

                    if (thisPet.GetType() == typeof(Dog))
                    {
                        iDog = (Dog)thisPet;

                        int number = rand.Next(0, 5);

                        switch (number)
                        {
                            case 1:
                                iDog.GoToVet();
                                break;
                            case 2:
                                iDog.Bark();
                                break;
                            case 3:
                                iDog.Eat();
                                break;
                            case 4:
                                iDog.Play();
                                break;
                            default:
                                iDog.NeedToWalk();
                                break;
                        }
                    }
                    else
                    {
                        iCat = (Cat)thisPet;

                        int number = rand.Next(0, 5);

                        switch (number)
                        {
                            case 1:
                                iCat.Scratch();
                                break;
                            case 2:
                                iCat.Purr();
                                break;
                            case 3:
                                iCat.Eat();
                                break;
                            default:
                                iCat.Play();
                                break;
                        }
                    }
                }
            }
        }
    }
}
