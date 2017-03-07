using System;
 
namespace AbstractFactory
{
    //---------------------------------
    abstract class Movement
    {
        public abstract void Move();
    }

    abstract class Weapon
    {
        public abstract void Hit();
    }


    //---------------------------------
    class Laser: Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Hero`s laser hits enemy.");
        }
    }

    class Fist: Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Hero hit enemy by fist.");
        }
    }

    class Fly: Movement
    {
        public override void Move()
        {
            Console.WriteLine("Hero flies.");
        }
    }

    class Run: Movement
    {
        public override void Move()
        {
            Console.WriteLine("Hero runs.");
        }
    }


    //---------------------------------
    abstract class SuperHeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }


    //---------------------------------
    class SuperManFactory : SuperHeroFactory
    {
        public override Movement CreateMovement()
        {
            return new Fly();
        }

        public override Weapon CreateWeapon()
        {
            return new Laser();
        }
    }

    class IronManFactory: SuperHeroFactory
    {
        public override Movement CreateMovement()
        {
            return new Run();
        }

        public override Weapon CreateWeapon()
        {
            return new Fist();
        }
    }


    //---------------------------------
    class WarriorFactory: SuperHeroFactory
    {
        public override Movement CreateMovement()
        {
            return new Run();
        }

        public override Weapon CreateWeapon()
        {
            return new Laser();
        }
    }


    //---------------------------------
    class SuperHero
    {
        private Weapon weapon;
        private Movement movement;

        public SuperHero(SuperHeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Hit()
        {
            weapon.Hit();
        }
    }

    //---------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            SuperHero superMan = new SuperHero(new SuperManFactory());
            superMan.Hit();
            superMan.Run();

            SuperHero ironMan = new SuperHero(new IronManFactory());
            ironMan.Hit();
            ironMan.Run();

            SuperHero warrior = new SuperHero(new WarriorFactory());
            warrior.Hit();
            warrior.Run();

            Console.ReadKey();
        }
    }
}
