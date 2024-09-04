using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hybridinheritance
{
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }
    }

    interface ISwim
    {
        void Swim();
    }

    interface IFly
    {
        void Fly();
    }

    class Dolphin : Animal, ISwim
    {
        public void Swim()
        {
            Console.WriteLine("Dolphin is swimming");
        }
    }

    class Bird : Animal, IFly
    {
        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }
    }

    class FlyingFish : Animal, ISwim, IFly
    {
        public void Swim()
        {
            Console.WriteLine("Flying fish is swimming");
        }

        public void Fly()
        {
            Console.WriteLine("Flying fish is flying");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dolphin dolphin = new Dolphin();
            dolphin.Eat();
            dolphin.Swim();

            Bird bird = new Bird();
            bird.Eat();
            bird.Fly();

            FlyingFish flyingFish = new FlyingFish();
            flyingFish.Eat();
            flyingFish.Swim();
            flyingFish.Fly();

            Console.ReadLine();
        }
    }

}
