using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0304_solve
{
    class Program
    {
        class Warrior
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public int Strength { get; set; }

            public override string ToString()
            {
                return $"이름 : {Name}\n점수 : {Score,3}\n힘   : {Strength,3}";
            }
        }
        static void Main(string[] args)
        {
            /*
             1.
             클래스와 상속
                Warrior 클래스를 만들고 Name과 Score 속성을 추가하세요.
                Warrior Strength 속성을 추가하세요.
                Main 메서드에서 Warrior 객체를 생성하고, Name, Score, Strength 값을 설정한 후 출력하세요.
            */
            //Console.WriteLine("문제 1");
            //Warrior w = new Warrior();
            //w.Name = "커비";
            //w.Score = 100;
            //w.Strength = 200;
            //Console.WriteLine(w);

            /*예외 처리
            사용자에게 정수를 입력받고, 이를 int로 변환하는 프로그램을 작성하세요.
            숫자로 변환할 수 없는 경우 FormatException을 처리하여 "올바른 숫자를 입력하세요!"라는 메시지를 출력하세요.
            변환이 성공하면 입력한 숫자를 출력하세요.
            */
            //Console.WriteLine("문제 2");
            //try
            //{
            //    int num = int.Parse(Console.ReadLine());
            //}
            //catch(FormatException e)
            //{
            //    Console.WriteLine (e.Message);
            //}

            /*
             * 컬렉션 (List, Queue, Stack) 활용
                List<string>을 생성하고 "사과", "바나나", "포도"를 추가하세요.
                Queue<string>을 생성하고 "첫 번째 작업", "두 번째 작업", "세 번째 작업"을 추가하세요.
                Stack<int>을 생성하고 10, 20, 30을 추가한 뒤 하나씩 출력하세요.
            */
            //Console.WriteLine("문제 3");
            //List<string> list = new List<string>() { "사과", "바나나", "포도" };
            //foreach (string s in list)
            //{
            //    Console.WriteLine(s);
            //}
            //Queue<string> queue = new Queue<string>();
            //queue.Enqueue("첫 번째 작업");
            //queue.Enqueue("두 번째 작업");
            //queue.Enqueue("세 번째 작업");
            //while (queue.Count>0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}
            //Stack<int> stack = new Stack<int>();
            //stack.Push(10); stack.Push(20); stack.Push(30);
            //while (stack.Count > 0)
            //{
            //    Console.WriteLine(stack.Pop());
            //}

            /*문자열 처리
            사용자로부터 "Hello, C# World!" 같은 문자열을 입력받아, 다음을 수행하세요.
            전체 문자열을 대문자로 변환
            "C#"을 "CSharp"으로 변경
            문자열의 길이 출력
            */
            //Console.WriteLine("문제 4");
            //string input = Console.ReadLine();
            //Console.WriteLine(input.ToUpper());
            //Console.WriteLine(input.Replace("C#", "CShapr"));

            /*
             LINQ 활용
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; 배열이 주어질 때,
            LINQ를 사용하여 짝수만 필터링하고 출력하세요.
            LINQ를 사용하여 모든 숫자의 합을 구하고 출력하세요.
            스레드
            //*/
            //Console.WriteLine("문제 5");
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNum = numbers.Where(n => n % 2 == 0);
            var sum = numbers.Sum();

            foreach (var even in evenNum)
            {
                Console.Write(even + " ");
            }
            Console.WriteLine($"\n배열의 합 : {sum}");
        }
    }
}
