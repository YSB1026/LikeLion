using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0226_study1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 배열
            //int[] arr = new int[3];

            //arr[0] = 10;
            //arr[1] = 20;
            //arr[2] = 30;

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}

            //foreach (int n in arr)
            //{
            //    Console.WriteLine(n);
            //}

            //int[] arr2 = new int[] { 10, 20, 30 }; //선언과 초기화
            //int[] arr4 = new int[3] { 10, 20, 30 }; //선언과 초기화
            //int[] arr3 = { 10, 20, 30 }; //선언과 초기화

            //string[] fruits = { "사과", "바나나", "포도", "딸기" };
            //foreach (string fruit in fruits)
            //{
            //    Console.WriteLine(fruit);
            //}

            //3명의
            //국어, 영어, 수학 점수를 입력받아
            //총점과 평균을 출력하세요.
            //string[] subjects = { "국어", "영어", "수학" };
            //int[,] score = new int[3, subjects.Length];
            //int[] total = new int[3];
            //double[] avg = new double[3];

            //for (int i = 0; i < score.Length; i++)
            //{
            //    Console.WriteLine("{0}번째 학생의 점수를 입력하세요.", i + 1);
            //    for (int j = 0; j < subjects.Length; j++)
            //    {
            //        Console.Write($"{subjects[j]} 과목 점수 : ");
            //        score[i, j] = int.Parse(Console.ReadLine());
            //        total[i] += score[i, j];
            //    }
            //}

            //for(int i = 0; i < score.Length; i++)
            //{
            //    avg[i] = (double)total[i] / subjects.Length;
            //    Console.WriteLine($"{i + 1,3}번째 학생의 총점 : {total[i],3}, 평균 : {avg[i],-3:F2}");
            //}

            //string format
            //double value = 123_123.456;
            //Console.WriteLine(value.ToString("0.0")); //123.5
            //Console.WriteLine(string.Format("소수점 둘째 자리 : {0:F2}",value)); //123.46
            //Console.WriteLine($"value : {value,0:F2}"); //123.5

            #endregion

            #region 2차원 배열
            //int[,] arr = new int[2, 3]
            //{
            //    {1,2,3}, //0행 0~2열
            //    {4,5,6} //1행 0~2열
            //};

            //Console.WriteLine(arr.Length); //6
            //Console.WriteLine(arr.GetLength(0)); //2
            //Console.WriteLine(arr.GetLength(1)); //3

            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        Console.Write($"{arr[i, j]}");
            //    }
            //    Console.WriteLine();
            //}

            //int[][] arr2 = new int[3][];
            //arr2[0] = new int[3] { 1, 2, 3 };
            //arr2[1] = new int[2] { 4, 5 };
            //arr2[2] = new int[3] { 6, 7, 8 };
            //Console.WriteLine(arr2.Length); //2
            //Console.WriteLine(arr2[0].Length); //3
            //Console.WriteLine(arr2[1].Length); //2

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    for (int j = 0; j < arr2[i].Length; j++)
            //    {
            //        Console.Write($"{arr2[i][j]} ");
            //    }
            //    Console.WriteLine();
            //}

            //var
            //Console.WriteLine("var 사용");
            //var number = new[] { 1, 2, 3, 4, 5 };
            //Console.WriteLine(number);//.GetType()도 가능
            //foreach (var n in number)
            //{
            //    Console.WriteLine(n);
            //}

            #endregion

        }
    }
}
