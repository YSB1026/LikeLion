using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study7
{

    //인터페이스를 활용하면 객체가 어떤 특정한 동작을 보장하면서도 다양한 형태로 사용
    //여러 동물을 공통된 방식으로 다룰 수 있다.
    public interface IAnimal
    {
        void Speak();
    }

    public class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("야옹");
        }
    }
    class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("멍멍");
        }
    }

    public class AnimalTrainer
    {
        public void Train(IAnimal animal)
        {
            Console.Write("동물이 소리를 냅니다.");
            animal.Speak();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AnimalTrainer trainer = new AnimalTrainer();

            IAnimal myDog = new Dog();
            IAnimal myCat = new Cat();

            trainer.Train(myDog);
            trainer.Train(myCat);
        }
    }
}
