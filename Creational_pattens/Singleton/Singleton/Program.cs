using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            (
                new Thread(
                    () =>
                    {
                        person.Launch();
                        Console.WriteLine(person.IIN.Code);
                    }
                )
            ).Start();

            person.IIN = IIN.getInstance();
            Console.WriteLine(person.IIN.Code);

            Console.ReadKey();
        }
    }

    //-------------------------------------------
    class Person
    {
        public IIN IIN { get; set; }

        public void Launch()
        {
            this.IIN = IIN.getInstance();
        }
    }

    //-------------------------------------------
    class IIN
    {
        private static readonly IIN instance = new IIN();
        public string Code { get; private set; }

        private IIN()
        {
            this.Code = System.Guid.NewGuid().ToString(); ;
        }

      
        public static IIN getInstance()
        {
            return instance;
        }
    }
}
