using System;


namespace Adapter
{
    class Target
    {
        public virtual void Request()
        {
            
        }
    }
    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }

    class Adapter: Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    class Adaptee 
    {
        public void SpecificRequest()
        {
            
        }
    }
}
