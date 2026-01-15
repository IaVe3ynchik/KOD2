using System;
namespace HomeWork1501
{
    interface IProducer<out T>
    {
        T Produce();
    }

    class Fruit { }
    class Apple : Fruit { }

    class AppleProducer : IProducer<Apple>
    {
        public Apple Produce() => new Apple();
    }

    class Task1
    {
        public static void NotMain(){
            IProducer<Fruit> fruitProducer = new AppleProducer();
            Fruit fruit = fruitProducer.Produce();

        }

    }
}