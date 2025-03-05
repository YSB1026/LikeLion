using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0305_study3
{
    //class Animal
    //{
    //    public string Name { get; set; }
    //    public void Eat()
    //    {
    //        Console.WriteLine($"{Name}이(가) 음식을 먹고 있습니다.");
    //    }
    //}
    //class Dog : Animal
    //{
    //    public Dog()
    //    {
    //        Name = "골든 댕댕이";
    //    }
    //    public void Bark()
    //    {
    //        Console.WriteLine($"{Name}이가 멍멍 짖습니다!");
    //    }
    //}

    //class Player
    //{
    //    public string name;

    //    public void Render()
    //    {
    //        Console.WriteLine($"플레이어-{name}");
    //    }
    //}
    
    //class Wizard : Player
    //{
    //    public string job;

    //    public void RenderJob()
    //    {
    //        Console.WriteLine($"직업은 {job} 입니다");
    //    }
    //}
    
    //오버라이딩
    class Animal1
    {
        public string Name { get; set; }

        public virtual void Speak()
        {
            Console.WriteLine($"{Name} 소리를 냅니다.");
        }
    }
   
    class Dog1 : Animal1
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} 이/가 멍멍 짖어요 :)");        
        }
        public void Bark()
        {
            Console.WriteLine($"{Name} 이/가 겁나 짖어요 :)");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //상속
            //Dog dog = new Dog();
            //dog.Eat();
            //dog.Bark();

            //상속
            //Player p = new Player();
            //p.name = "커비";
            //p.Render();

            //Wizard wizard = new Wizard();
            //wizard.name = "커비2";
            //wizard.job = "힘법사";
            //wizard.Render();
            //wizard.RenderJob();

            ////오버라이딩
            //Animal1 myAnimal = new Animal1();
            //myAnimal.Name = "일반동물";
            //myAnimal.Speak();

            //Dog1 myDog = new Dog1();
            //myDog.Name = "바둑이";
            //myDog.Speak();

            //업케스팅
            //자식 -> 부모로 변환
            //암시적 변환 가능(컴파일러가 자동 변환)
            //안전 : 데이터 손실 없이 변환 가능
            Animal1 myAnimal = new Dog1();
            myAnimal.Speak();
            //myA.Bark();//오류

            //다운 케스팅
            //Dog1 myD = (Dog1)myA; //명시적 변환
            Dog1 myDog = myAnimal as Dog1;

            if (myAnimal is Dog1 myDog1)
            {
                myDog1.Bark(); //실행
            }
            else
            {
                Console.WriteLine("변환할수 없습니다.");
            }

        }
    }
}
