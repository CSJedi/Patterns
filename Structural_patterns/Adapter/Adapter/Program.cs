using System;


namespace Adapter
{
    //-------------------------------------------------
    interface ITransport
    {
        void Drive();
    }

    class Auto: ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car rides.");
        }
    }

    //-------------------------------------------------
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    class Yacht
    {
        public void Swimm()
        {
            Console.WriteLine("Yacht swimm.");
        }
    }

    //-------------------------------------------------
    class YachtToAutoAdapter: ITransport
    {
        Yacht yacht;

        public YachtToAutoAdapter(Yacht yacht)
        {
            this.yacht = yacht;
        }

        public void Drive()
        {
            yacht.Swimm();
        }
    }

    //-------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();
            Driver driver = new Driver();
            driver.Travel(auto);

            Yacht yacht = new Yacht();
            ITransport yachtAuto = new YachtToAutoAdapter(yacht);
            driver.Travel(yachtAuto);

            Console.ReadLine();
        }
    }
}
