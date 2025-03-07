using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_study3
{
    class Program
    {
        //델리게이트와 이벤트를 더 쉽게 만든 Action

        static void SayHello()
        {
            Console.WriteLine("안녕하세요");
        }
        static void ShowNotification()
        {
            Console.WriteLine("중요한 알림.");
        }
        static void HelloWorld(string message)
        {
            Console.WriteLine("신규 메세지:" + message);
        }
        static void Main(string[] args)
        {
            //Action은 매개변수가 없고 반환값이 없는 메서드를 참조
            Action action = SayHello;
            //helloAction();
            action += ShowNotification;

            action?.Invoke();

            Action<string> h = null;
            h+=HelloWorld;
            h?.Invoke("액션");

            Action noti = null;
            noti += () => Console.WriteLine("람다식으로도 가능..");
            noti?.Invoke();

            Action<int> Square = number => Console.WriteLine(number*number);
            Square(5);
        }
    }
}
