using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study4
{
    abstract class Parent
    {
        protected string name;
        public Parent(string name)
        {
            this.name = name;
        }
        public abstract void Test();
    }

    class Child : Parent
    {
        private int age;
        public Child(string name, int age) : base(name)
        {
            this.age = age;
            Console.WriteLine($"자식 생성자 -  나이 : {age}");
        }
        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {name}, 나이 : {age}");
        }

        public override void Test()
        {
            Console.WriteLine("테스트 함수 호출");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Child("커비", 5);
            p.Test();
        }
    }
}
