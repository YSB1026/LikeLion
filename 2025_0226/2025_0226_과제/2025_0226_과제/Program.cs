using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0226_과제
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            ///*Q1. 배열 요소 출력
            //// 문제: 크기가 5인 정수 배열을 만들고, {10, 20, 30, 40, 50} 값을 저장한 후 출력하세요.
            //예상 출력
            //*/
            //int[] arr = { 10, 20, 30, 40, 50 }; //new int[] {}도됨
            //foreach (int i in arr)
            //{
            //    Console.WriteLine(i);
            //}

            /*Q2. 배열 요소 합 구하기
            // 문제: 사용자가 5개의 정수를 입력하면 배열에 저장하고, 모든 수의 합을 출력하세요.
            숫자 입력: 1 2 3 4 5
            총 합: 15
            */

            //int[] arr2 = new int[5];
            //string uInput = Console.ReadLine(); // 사용자 입력 받기
            //string[] inputs = uInput.Split(' ');
            //for (int i = 0; i < inputs.Length; i++)
            //{
            //    {
            //        if (int.TryParse(inputs[i], out int n))
            //        {
            //            arr2[i] = n;
            //        }
            //    }
            //}
            //Console.WriteLine(arr2.Sum());

            ///*
            // Q3. 최대값 찾기

            //// 문제: 정수 배열 {3, 8, 15, 6, 2}에서 가장 큰 값을 찾아 출력하세요.
            //예상 출력:15
            //*/
            //int[] arr3 = { 3, 8, 15, 6, 2 };
            //Console.WriteLine(arr3.Max());//이것도 함수로있네요
            ////직접 구현은 순차적으로 순회하면서 max값 찾기 or 배열 정렬 후 최대값 찾기

            ///*
            //Q4. 1부터 10까지 출력(for문)
            //// 문제: for문을 사용하여 1부터 10까지 출력하세요.
            //*/
            //for (int i = 1; i<=10; i++)
            //{
            //    Console.Write(i +" ");
            //}
            //Console.WriteLine();

            ///*
            // Q5. 짝수만 출력 (while문)
            //// 문제: while문을 사용하여 1부터 10까지 중 짝수만 출력하세요.
            //*/
            //int n = 1;
            //while (n<=10)
            //{
            //    if (n%2==0) Console.Write(n + " ");
            //    n++;
            //}
            //Console.WriteLine();

            ///*
            //Q6.배열 요소 출력(foreach문)
            //// 문제: foreach문을 사용하여 배열 {1, 2, 3, 4, 5}의 요소를 출력하세요.
            //*/
            //int[] arr4 = { 1, 2, 3, 4, 5 };
            //foreach (int i in arr4)
            //{
            //    Console.Write(i + " ");
            //}
            //Console.WriteLine();

            ///*
            // Q7. 두 수의 합을 구하는 함수
            //// 문제: 두 개의 정수를 입력받아 합을 반환하는 함수를 작성하세요.
            //*/
            //int a = 3; int b = 5;
            //Console.WriteLine($"{a}+{b} = {Add(a, b)}");

            /*Q8. 문자열 길이 반환 함수
            // 문제: 문자열을 입력받아 길이를 반환하는 함수를 작성하세요.
            예상 출력
            */
            //string str = Console.ReadLine();
            //Console.WriteLine(str.Length);

            ///*Q9. 가장 큰 수 반환 함수
            //// 문제: 세 개의 정수를 입력받아 가장 큰 값을 반환하는 함수를 작성하세요.
            //예상 출력
            //*/
            //int max = 0;
            //for (int i = 0; i<3; i++)
            //{
            //    max = Math.Max(int.Parse(Console.ReadLine()), max);
            //}
            //Console.WriteLine(max);
        }
    }
}
