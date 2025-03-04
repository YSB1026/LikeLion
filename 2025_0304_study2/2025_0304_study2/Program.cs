using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0304_study2
{
    class Program
    {
        public class A
        {
            public int X {  get; set; }
        }
        static void Main(string[] args)
        {
            #region 값 형식과 참조 형식
            //값 형식은 스택에 저장, 참조는 힙

            //int valueType = 10;
            //object referernceType = valueType;
            //valueType = 20;


            //Console.WriteLine($"ValueType : {valueType}, Reference : {referernceType}");

            //박싱 언박싱
            //값 형식을 참조형식으로 변환(박싱), 다시 값 형식으로 변환(언박싱)

            //int value = 42;
            //object boxed = value;
            //int unboxed = (int)boxed;
            //근데 이케이스에선 value type인 int라서 그냥 값형식으로 되고 stack에 저장된듯
            //Console.WriteLine($"{boxed}, {unboxed}");
            //A a = new A();
            //A aa = a;
            //a.X = 10;

            //Console.WriteLine(a.X);
            //Console.WriteLine(aa.X);
            //Console.WriteLine(a.Equals(aa));
            #endregion
            #region is 연산자
            //is 연산자

            //object obj = "Hello";
            //Console.WriteLine(obj is string);
            //Console.WriteLine(obj is int);

            //object obj = "Hello";
            //string str = obj as string;
            //Console.WriteLine(1);

            //var obj = 42;
            //if (obj is int number)
            //{
            //    Console.WriteLine($"{number}");
            //}
            //else
            //{
            //    Console.WriteLine("Not a number");
            //}
            #endregion

            #region string 클래스
            //string greeting = "Hello";
            //string name = "Alice";

            //string message = greeting + ',' + name +"!";
            //Console.WriteLine(message);

            //Console.WriteLine($"Length of name : {name.Length}");
            //Console.WriteLine($"To Upper: {name.ToUpper()}");
            //Console.WriteLine($"Substring : {name.Substring(1)}");

            //string 다양한 메서드
            //string text = "C# is awesome";
            //Console.WriteLine($"Contains 'awsome' : {text.Contains("awesome")}");
            //Console.WriteLine($"Start with 'C#' : {text.StartsWith("C#")}");
            //Console.WriteLine($"Indeox of 'is' : {text.IndexOf("is")}");
            //Console.WriteLine($"Replace 'awesome' with 'greeting' " +
            //    $"{text.Replace("awesome","greeting")}");

            ////string builder
            //StringBuilder sb = new StringBuilder("Hello");
            //sb.Append(",");
            //sb.Append("World!");
            //Console.WriteLine(sb);

            //string과 stringbuilder 클래스 성능차이 비교
            //반복적으로 문자열을 수정할때 StringBuilder가 효율적

            //int iterations = 100000;
            //Stopwatch sw = Stopwatch.StartNew();
            //string text = "";
            //for (int i = 0; i<iterations; i++)
            //{
            //    text+= ".";
            //}
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            //sw.Restart();
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i<iterations; i++)
            //{
            //    sb.Append("a");
            //}
            //sw.Stop();
            //Console.Write(sw.ElapsedMilliseconds);
            //#endregion
            #endregion
            #region try - catch
            //예외처리

            //try
            //{
            //    int[] numbers = { 1, 2, 3 };
            //    Console.WriteLine(numbers[5]);
            //}
            //catch(IndexOutOfRangeException e) {
            //    Console.WriteLine(e.Message);
            //}

            //try
            //{
            //    int number = int.Parse("Not number");
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"Format Error : {e.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("항상 실행");
            //}

            try
            {
                int age = -5;
                if (age < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            string str = "Hello";

            #endregion
        }
    }
}
