using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Launch("999999999999999999999999999");
            Console.WriteLine(person.IIN.Code);

            person.IIN = IIN.getInstance("888888888888888");
            Console.WriteLine(person.IIN.Code);
            Console.ReadKey();
        }
    }

    //-------------------------------------------
    class Person
    {
        public IIN IIN { get; set; }

        public void Launch(string code)
        {
            this.IIN = IIN.getInstance(code);
        }
    }

    //-------------------------------------------
    class IIN
    {
        private static IIN instance;
        public string Code { get; private set; }

        protected IIN(string code)
        {
            this.Code = code;
        }

        public static IIN getInstance(string code)
        {
            if(instance == null)
                instance = new IIN(code);

            return instance;
        }
    }
}
