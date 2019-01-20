using System;

namespace FactoryMethod
{
    public class Truck : iTransport
    {
        public void deliver()
        {
            Console.WriteLine("truck deliver");
        }
    }

    public class Ship : iTransport
    {
        public void deliver()
        {
            Console.WriteLine("ship deliver");
        }
    }

    public abstract class Logistics
    {
        iTransport transport { get; set; }

        public void planDelivery()
        {
            this.transport = CreateTransport();

            transport.deliver();
        }

        protected abstract iTransport CreateTransport();
    }

    public class RoadLogistic : Logistics
    {
        protected override iTransport CreateTransport()
        {
            return new Truck();
        }
    }

    public class SeaLogistic : Logistics
    {
        protected override iTransport CreateTransport()
        {
            return new Ship();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logistics road = new RoadLogistic();
            road.planDelivery();

            Logistics sea = new SeaLogistic();
            sea.planDelivery();
        }
    }
}
