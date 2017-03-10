using System;

namespace Proxy
{
    public interface IMath
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    //--------------------------------------------
    class Math: IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }
    }

    //--------------------------------------------
    class MathProxy: IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Subtract(double x, double y)
        {
            return _math.Subtract(x, y);
        }

        public double Multiply(double x, double y)
        {
            return _math.Multiply(x, y);
        }

        public double Divide(double x, double y)
        {
            return _math.Divide(x, y);
        }
    }

    class Program
    {
        static void Main()
        {
            MathProxy proxy = new MathProxy();

            double x = 6;
            double y = 7; 

            Console.WriteLine(x + " + " + y + " = " + proxy.Add(x, y));
            Console.WriteLine(x + " - " + y + " = " + proxy.Subtract(x, y));
            Console.WriteLine(x + " * " + y + " = " + proxy.Multiply(x, y));
            Console.WriteLine(x + " / " + y + " = " + proxy.Divide(x, y));

            Console.ReadLine();
        }
    }
}
