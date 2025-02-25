using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0225_study
{
    class Program
    {
        struct Status
        {
            private int atk, def;
            private string className;
            public int Atk
            {
                get { return atk; }
                set { atk = value; }
            }
            public int Def
            {
                get { return def; }
                set { def = value; }
            }
            public string ClassName
            {
                get { return className; }
                set { className = value; }
            }
        }

        static void Main(string[] args)
        {
            #region switch - case문
            //int day = 3;
            //switch (day)
            //{
            //    case 1: Console.WriteLine("월요일");
            //        break;
            //    case 2:
            //        Console.WriteLine("화요일");
            //        break;
            //    case 3:
            //        Console.WriteLine("수요일");
            //        break;
            //    case 4:
            //        Console.WriteLine("목요일");
            //        break;
            //    case 5:
            //        Console.WriteLine("금요일");
            //        break;
            //    case 6:
            //        Console.WriteLine("토요일");
            //        break;
            //    case 7:
            //        Console.WriteLine("일요일");
            //        break;
            //    default:
            //        Console.WriteLine("입력 오류");
            //        break;
            //}

            ////캐릭터를 선택하세요(1.검사 2.마법사 3.도적)
            ////switch문 사용
            //Console.Write("캐릭터를 선택하세요(1. 검사 2.마법사 3.도적) : ");
            //int select = int.Parse(Console.ReadLine());
            //Status stat = new Status();
            //switch (select)
            //{
            //    case 1:
            //        Console.WriteLine("검사를 선택하셨습니다.");
            //        stat.Atk = 100;
            //        stat.Def = 90;
            //        stat.ClassName = "검사";
            //        break;
            //    case 2:
            //        Console.WriteLine("마법사를 선택하셨습니다.");
            //        stat.Atk = 110;
            //        stat.Def = 80;
            //        stat.ClassName = "마법사";
            //        break;
            //    case 3:
            //        Console.WriteLine("도적을 선택하셨습니다.");
            //        stat.Atk = 115;
            //        stat.Def = 70;
            //        stat.ClassName = "도적";
            //        break;
            //}
            //Console.WriteLine(
            //    $"직업 : {stat.ClassName}\n" +
            //    $"공격력 : {stat.Atk}\n" +
            //    $"방어력 : {stat.Def}\n");

            #endregion

            #region 반복문
            //for문

            //for (int i = 0; i<10; i++)
            //{
            //    Console.WriteLine($"{i+1}번 반복중");
            //}

            //0~9 출력
            //for(int i=0; i<10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //1부터 10까지 합구하기
            //int sum = 0;
            //for (int i = 1; i<=10; i++)
            //{
            //    sum+=i;
            //    Console.WriteLine($"중간 췤! : {sum}");
            //}
            //Console.WriteLine(sum);

            //while문
            //int i = 1;
            //while (i<=5)
            //{
            //    if (i==3)
            //    {
            //        Console.WriteLine("반복문 탈출!! i is 3..");
            //        break;
            //    }
            //    Console.WriteLine($"{i}번째 반복중");
            //    i++;
            //}
            #endregion

            #region 랜덤
            Random rand = new Random();

            //0이상 10미만
            //int randNum = rand.Next(0,10);
            //Console.WriteLine(randNum);
            //for (int i = 0; i < 10; i++)
            //{
            //    int randNum = rand.Next(0, 10);
            //    Console.WriteLine($"랜덤 숫자 : {randNum}");
            //}

            //double randNum = rand.NextDouble();
            //Console.WriteLine(randNum);

            //대장장이 키우기
            //도끼 등급 SSS 10%
            //도끼 등급 SS 40%
            //도끼 등급 S 50%

            //int rnd = 0;

            //for (int i = 0; i<20; i++)
            //{
            //    rnd = rand.Next(1, 101);
            //    if(rnd<=10)
            //    {
            //        Console.WriteLine($"도끼(SSS)!!!!! {rnd}");
            //    }
            //    else if (rnd<=40)
            //    {
            //        Console.WriteLine($"도끼(SS) {rnd}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"도끼(S) {rnd}");
            //    }
            //    Thread.Sleep(500);
            //}

            #endregion

            #region do-while문

            //int x = 5;

            //do
            //{
            //    Console.WriteLine("최소 한번은 실행");
            //    x--;
            //}while(x>0);
            #endregion

            #region break, continue

            ////break
            //for (int i = 0; i<10; i++)
            //{
            //    if (i==5) break;
            //    Console.WriteLine(i);
            //}

            ////continue
            //for (int i = 0; i<10; i++)
            //{
            //    if (i%2==0) continue;
            //    Console.WriteLine(i);
            //}
            #endregion

            #region goto문
            ////학부생 시절 C 배울때 교수님이 쓰지말라고 하셨던..

            //int n = 1;

            //start:

            //if (n<=5)
            //{
            //    Console.WriteLine(n);
            //    n++;
            //    goto start;
            //}

            #endregion
        }
    }
}
