using System;

namespace Adapter
{
    //-------------------------------------------------
    internal interface ITransport
    {
        void Drive();
    }

    internal class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Car rides.");
        }
    }

    //-------------------------------------------------
    internal class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    internal class Yacht
    {
        public void Swimm()
        { 
            Console.WriteLine("Yacht swimm.");
        }
    }

    //-------------------------------------------------
    internal class YachtToAutoAdapter : ITransport
    {
        private readonly Yacht yacht;

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
    internal class Program
    {
        private static void Main(string[] args)
        {
            var auto = new Auto();
            var driver = new Driver();
            driver.Travel(auto);

            var yacht = new Yacht(); 
            ITransport yachtAuto = new YachtToAutoAdapter(yacht);
            driver.Travel(yachtAuto);

            Console.ReadLine();
        }
    }
}
