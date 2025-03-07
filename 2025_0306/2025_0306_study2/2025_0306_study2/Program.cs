using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study2
{
    //추상 클래스(Abstact Class)
    //추상 클래스는 객체를 생성 할 수 없는 클래스로, 상속을 통해서만 사용할 수 있음
    abstract class Animal
    {
        public abstract void MakeSound();

        public void Sleep()
        {
            Console.WriteLine("잠을 잡니다..");
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("멍멍");
        }
    }
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("야옹");
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            Animal myDog = new Dog();
            myDog.MakeSound();
            myDog.Sleep();

            Animal myCat = new Cat();
            myCat.MakeSound();
            myCat.Sleep();
        }
    }
}
