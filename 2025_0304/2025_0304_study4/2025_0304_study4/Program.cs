using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0304_study4
{
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("동물 akfgka");
        }
    }

    class Dog: Animal
    {
        public override void Speak()
        {
            Console.WriteLine("멍멍 짖는다");
        }

        public void WagTail()
        {
            Console.WriteLine("꼬리콥터");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Dog();//업케스팅
            myAnimal.Speak();

            Dog d = (Dog)myAnimal;
            d.WagTail();
        }
    }
}
