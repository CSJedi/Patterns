using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Builder
{
    class Flour
    {
        public string Sort { get; set; }
    }

    class Sugar
    {
        public string Sort { get; set; }
    }

    class Cream
    {
        public string Name { get; set; }
    }

    class Cake
    {
        public Flour WheatFlour { get; set; }
        public Sugar Sugar { get; set; }

        public Cream ChocolateCream { get; set; }
        public Cream VanillaCream { get; set; }

        public string Combine()
        {
            StringBuilder sb = new StringBuilder();

            if (WheatFlour != null)
                sb.Append("Wheat flour:" + WheatFlour.Sort + "\n");
            if (Sugar != null)
                sb.Append("Sugar \n");
            if (ChocolateCream != null)
                sb.Append("Cream: " + ChocolateCream.Name + "\n");
            if (VanillaCream != null)
                sb.Append("Cream: " + VanillaCream.Name + "\n");

            return sb.ToString();
        }
    }

    abstract class CakeBuilder
    {
        public Cake Cake { get; set; }

        public void CreateCake()
        {
            Cake = new Cake();
        }

        public abstract void SetWheatFlour();
        public abstract void SetSugar();
        public abstract void SetChocolateCream();
        public abstract void SetVanillaCream();
    }

    class Baker
    {
        public Cake Bake(CakeBuilder cakeBuilder)
        {
            cakeBuilder.CreateCake();
            cakeBuilder.SetWheatFlour();
            cakeBuilder.SetSugar();
            cakeBuilder.SetVanillaCream();
            cakeBuilder.SetChocolateCream();
            return cakeBuilder.Cake;
        }
    }

    class VanillaCakeBuilder: CakeBuilder
    {
        public override void SetChocolateCream()
        {
            //do not use
        }

        public override void SetWheatFlour()
        {
            this.Cake.WheatFlour = new Flour() {Sort = "first sort"};
        }

        public override void SetSugar()
        {
            this.Cake.Sugar = new Sugar();
        }
   
        public override void SetVanillaCream()
        {
            this.Cake.VanillaCream = new Cream() {Name = "Super vanilla"};
        }
    }
    class ChocolateCakeBuilder : CakeBuilder
    {
        public override void SetChocolateCream()
        {
            this.Cake.ChocolateCream = new Cream() { Name = "Super choco" };
        }

        public override void SetWheatFlour()
        {
            this.Cake.WheatFlour = new Flour() { Sort = "first sort" };
        }

        public override void SetSugar()
        {
            this.Cake.Sugar = new Sugar();
        }

        public override void SetVanillaCream()
        {
            //do not use 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Baker baker = new Baker();
            CakeBuilder builder = new VanillaCakeBuilder();
            Cake vanillaCake = baker.Bake(builder);
            Console.WriteLine(vanillaCake.Combine());

            builder = new ChocolateCakeBuilder();
            Cake chocoCake = baker.Bake(builder);
            Console.WriteLine(chocoCake.Combine());

            Console.ReadLine();
        }
    }
}
