using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    //---------------------------------------
    interface IAnimal
    {
        IAnimal Clone();
        void GetInfo();
    }


    //---------------------------------------
    class Monkey : IAnimal
    {
        bool State;
        string Name;
        int Age;

        public Monkey(bool state, string name, int age)
        {
            this.State = state;
            this.Name = name;
            this.Age = age;
        }
        public IAnimal Clone()
        {
            return new Monkey(this.State, this.Name, this.Age);
        }

        public void GetInfo()
        {
            Console.WriteLine(State ? "Monkey`s name is {0}, she is {1}." : "Monkey`s name is {0}, he is {1}.", Name,
                Age.ToString());
        }
    }

    class Panda: IAnimal
    {
        bool State;
        string Name;
        int Age;
        int SleepHours;
        public Panda(bool state, string name, int age, int sleepHours)
        {
            this.State = state;
            this.Name = name;
            this.Age = age;
            this.SleepHours = sleepHours;
        }

        public void GetInfo()
        {
            if(SleepHours > 10)
            Console.WriteLine(State ? "Panda`s name is {0}, she is {1} and she is dormouse." : "Monkey`s name is {0}, he is {1} and he is dormouse.", Name,
                Age.ToString());
            else
                Console.WriteLine(State ? "Panda`s name is {0}, she is {1}." : "Monkey`s name is {0}, he is {1}. ", Name,
                    Age.ToString());
        }

        public IAnimal Clone()
        {
            return new Panda(this.State, this.Name, this.Age, this.SleepHours);
        }
    }


    //---------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = new Monkey(true, "Mimi", 2);
            IAnimal clonedAnimal = animal.Clone();
            animal.GetInfo();
            clonedAnimal.GetInfo();

            animal = new Panda(false,"Ricky",6, 12);
            clonedAnimal = animal.Clone();
            animal.GetInfo();
            clonedAnimal.GetInfo();

            Console.ReadKey();
        }
    }
}
