using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0228_study1
{
    //마린 클래스를 만드세요.
    //이름, 미네랄
    //기본 생성자, 인자있는 생성자

    class Marin
    {
        public int Mineral { get; set; }
        public string Name { get; }
        public Marin()
        {
            Mineral = 50;
            Name = "마린";
        }
        public Marin(int mineral, string name)
        {
            Mineral=mineral;
            Name=name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"미네랄 : {Mineral,4}, 이름 : {Name,15}");
        }
    }

    class SCV
    {
        public int Mineral { get; set; }
        public string Name { get; }
        public SCV()
        {
            Mineral = 50;
            Name = "SCV";
        }
        public SCV(int mineral, string name)
        {
            Mineral=mineral;
            Name=name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"미네랄 : {Mineral,4}, 이름 : {Name,-15}");
        }
    }

    class Barruck
    {
        public int Mineral { get; }
        public string Name { get; }
        public Barruck()
        {
            Mineral = 150;
            Name = "배럭";
        }
        public Barruck(int mineral, string name)
        {
            Mineral = mineral;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"미네랄 : {Mineral,4}, 이름 : {Name,-15}");
        }
    }
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        //기본생성자
        //클래스가 객체로 생성될 때 자동으로 실행되는 메소드
        //클래스와 같은 이름, 반환형이 없음
        //객체를 만들 때 필요한 초기값 할당

        public Person(string name = "이름 없어용", int age = 0)
        {
            Name = name;
            Age = age;
            Console.WriteLine("오호홍 실행");
        }
    
        public void ShowInfo()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("나이 : " + Age);
        }

    }

    //미네랄 클래스
    //Mineral 1500 기본
    //7개 시작
    //클래스화

    class Mineral
    {
        public int Amount { get; private set; }
        public Mineral(int amount = 1500)
        {
            Amount = amount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"미네랄의 양 : {Amount}");
        }
    }

    //game 클래스 만들어보자
    class Game
    {
        public static int mineral;
        public static int gas;
        public static int curPopularity;

        public static void ShowInfo()
        {
            Console.WriteLine($"미네랄 : {mineral}, 가스 : {gas}, 인구수 : {curPopularity}");
        }
    }
    class Programs
    {
        static void Main(string[] args)
        {
            //Person person = new Person();
            //person.ShowInfo();

            Game.mineral = 50;
            Game.gas = 0;
            Game.curPopularity = 10;
            Game.ShowInfo();

            Marin m1 = new Marin(100, "앗쎄이 해병님");
            SCV scv = new SCV(60, "고된 노동을 하는 노예");
            Barruck b1 = new Barruck(150, "앗쎄이 해병들의 숙소");

            m1.ShowInfo();
            scv.ShowInfo();
            b1.ShowInfo();
            Mineral[] mineral = new Mineral[7];
            for (int i = 0; i < mineral.Length; i++)
            {
                mineral[i] = new Mineral();
                Console.Write($"{i+1}번 - ");
                mineral[i].ShowInfo();
            }
        }
    }
}
