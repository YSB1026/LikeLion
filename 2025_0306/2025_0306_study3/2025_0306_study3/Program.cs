
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study3
{
    class Program
    {
        //부모 클래스의 생성자 호출
        public class Parent
        {
            public Parent(string message)
            {
                Console.WriteLine("부모 생성자 호출 - " + message);
            }
        }

        public class Child : Parent
        {
            string msg;
            public Child():base("아버지 정답을 알고 있다면 답을 알려줘")
            {
                Console.WriteLine("자식 생성자 호출");
            }
        }
        static void Main(string[] args)
        {
            Child c = new Child();
        }
    }
}
