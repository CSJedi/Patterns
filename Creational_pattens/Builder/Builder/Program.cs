using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Builder
{
    class Product
    {
        List<object> parts = new List<object>();

        public void Add(string part)
        {
            parts.Add(part);
        }
    }
    abstract class Buider
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();
        public abstract Product GetResult();

    }

    class ConcreteBuilder : Buider
    {
        Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("Part A");
        }

        public override void BuildPartB()
        {
            product.Add("Part B");
        }

        public override void BuildPartC()
        {
            product.Add("Part C");
        }

        public override Product GetResult()
        {
            return product;
        }
    }


    class Director
    {
        Buider builder;

        public Director(Buider builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }

    class Client
    {
        void Main()
        {
            Buider buider = new ConcreteBuilder();
            Director director = new Director(buider);
            director.Construct();
            Product product = buider.GetResult();
        }
    }
}
