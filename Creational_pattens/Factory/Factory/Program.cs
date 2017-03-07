using System;


namespace Factory
{
    abstract class House
    {

    }

    //----------------------------------------
    class PanelHouse: House
    {
        public PanelHouse()
        {
            Console.WriteLine("Panel house was built.");
        }
    }

    class WoodHouse: House
    {
        public WoodHouse()
        {
            Console.WriteLine("Wood house was built.");
        }
    }

    class BrickHouse: House
    {
        public BrickHouse()
        {
            Console.WriteLine("Brick house was built.");
        }
    }

    //----------------------------------------
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }

        abstract public House Create();
    }

    //----------------------------------------
    class PanelDeveloper: Developer
    {
        public PanelDeveloper(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper: Developer
    {
        public WoodDeveloper(string name) : base(name)
        {

        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    class BrickDeveloper: Developer
    {
        public BrickDeveloper(string name) : base(name)
        {
        }

        public override House Create()
        {
            return new BrickHouse();
        }
    }
    //----------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev;

            dev = new PanelDeveloper("Panel house builder");
            House firstHouse = dev.Create();

            dev = new WoodDeveloper("Wood house builder");
            House secondHouse = dev.Create();

            dev = new BrickDeveloper("Brick house builder");
            House thirdHouse = dev.Create();

            Console.ReadKey();
        }
    }
}
