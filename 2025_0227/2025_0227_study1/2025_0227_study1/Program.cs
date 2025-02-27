using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dev1
{
    class MyClass
    {
        public static void SayHello()
        {
            Console.WriteLine("dev1의 SayHello!");
        }
    }
}
namespace _2025_0227_study1
{
    class Program
    {
        #region 함수 구현부
        static int n = 20;
        static void PrintHello()
        {
            Console.WriteLine("Hello!");
        }
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        static int GetNumber()
        {
            return 42;
        }
        static int Add(int a, int b)
        {
            return a+b;
        }

        static void Greet(string name = "손님")
        {
            Console.WriteLine($"안녕하세요, {name}");
        }

        /// <summary>
        /// 두 수를 곱하는 함수, param1, param2를 곱한 수를 return한다
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns> (int) param * param2</returns>
        static int Multiply(int a, int b)
        {
            return a*b;
        }
        static double Multiply(double a, double b)
        {
            return a*b;
        }

        /// <summary>
        /// quotient = a / b, remainder = a % b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="quotient"></param>
        /// <param name="remainder"></param>
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            if (b==0)
            {
                quotient = -1; remainder = -1;
                return;
            }
            quotient = a/b;
            remainder = a%b;
        }

        static void Increase(ref int num)
        {
            num +=10;
        }

        static int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int n in numbers)
            {
                total += n;
            }
            return total;
        }

        static void Print()
        {
            Console.WriteLine("재귀");
            Print();
        }

        static int Factorial(int n)
        {
            if (n<=1)
            {
                return 1;
            }
            return n*Factorial(n-1);
        }

        static void SayHello()
        {
            Console.WriteLine("Program의 say Hello!");
        }
        #endregion

        static void Main(string[] args)
        {
            #region 함수
            ////1.매개변수도 없는 함수, 반환값도 없는 함수
            //PrintHello();
            ////2.매개변수만 있는 함수
            //PrintMessage("Hello!!");
            ////3.반환 값만 있는 함수
            //Console.WriteLine(GetNumber());
            ////static variable
            //Console.WriteLine(n);
            ////4. 매개변수와 반환값이 있는 함수
            //int result = Add(5,20);//result 출력도 가능
            //Console.WriteLine(Add(5, 20));

            ////5.default parameter
            //Greet();
            //Greet("커비");

            ////6.함수 오버로딩(Overloading)
            //Console.WriteLine(Multiply(3,4));
            //Console.WriteLine(Multiply(3.4, 2));

            //7.out 키워드 (여러 값을 반환할 때)
            //int q, r;
            //Divide(10, 3, out q, out r);
            //Console.WriteLine($"몫 : {q} 나머지 : {r}");

            //int val = 5;
            //Increase(ref val);
            //Console.WriteLine(val);


            //params
            Console.WriteLine(Sum(1, 2, 3));

            //재귀함수(recursive)
            Console.WriteLine(Factorial(5));
            #endregion

            #region 네임 스페이스
            //네임스페이스
            //클래스, 함수, 변수, 이름이 충돌하는것을 방지하기 위해 사용된다.
            dev1.MyClass.SayHello();
            SayHello();
            #endregion
        }
    }
}
