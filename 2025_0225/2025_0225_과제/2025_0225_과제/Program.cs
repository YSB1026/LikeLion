using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0225_과제
{
    class 대장장이키우기
    {
        //class 대장장이
        //{
        //    int money;
        //    int[] items = new int[6];

        //    public int Money { get { return money; } set { money = value; } }
        //    public int[] Items { get { return items; } set { items = value; } }
        //}

        Random rand;
        int pmoney;
        int input;
        int rnd;
        string[] axeGrade;
        int[] chances;

        public 대장장이키우기() { 
            rand = new Random();
            pmoney = 1000;
            axeGrade = new string[] { "도끼 등급 SSS", "도끼 등급 SS", "도끼 등급 S", "도끼 등급 A", "도끼 등급 B", "도끼 등급 C" };
            chances = new int[] { 1, 6, 16, 38, 69, 100 };
        }
        private void Loading()
        {
            string text = " 대장장이 키우기";
            string sparkle1 = "★ ☆";
            string sparkle2 = "☆ ★";


            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.WriteLine($"{sparkle1}{text}{sparkle2}\n아무 키나 입력하면 시작");
                Thread.Sleep(500);

                Console.Clear();
                Console.WriteLine($"{sparkle2}{text}{sparkle1}\n아무 키나 입력하면 시작");
                Thread.Sleep(500);
            }

            Console.Clear();
            Console.ReadKey();
        }

        private void CutTree()
        {
            Console.Clear();
            Console.WriteLine("나무캐기(엔터)");
            Console.WriteLine("뒤로가기 x");

            while (true)
            {
                string str = Console.ReadLine();

                int treeValue = rand.Next(70, 101);
                Console.WriteLine($"나무를 캐서 {treeValue}원을 얻었습니다.");
                pmoney += treeValue;
                Thread.Sleep(300);

                if (str == "x")
                {
                    Console.WriteLine("뒤로가기...");
                    Thread.Sleep(500);
                    break;
                }
            }
        }

        private void GachaAxe()
        {
            if (pmoney>=1000)
            {
                pmoney-=1000;

                //20번뽑기
                for (int i = 0; i<20; i++)
                {
                    rnd = rand.Next(1, 101);

                    if (rnd <= chances[0])
                        Console.WriteLine(axeGrade[0]);
                    else if (rnd <= chances[1])
                        Console.WriteLine(axeGrade[1]);
                    else if (rnd <= chances[2])
                        Console.WriteLine(axeGrade[2]);
                    else if (rnd <= chances[3])
                        Console.WriteLine(axeGrade[3]);
                    else if (rnd <= chances[4])
                        Console.WriteLine(axeGrade[4]);
                    else
                        Console.WriteLine(axeGrade[5]);
                    Thread.Sleep(500);
                }
            }//if(pmoney>=1000)
            else
            {
                Console.WriteLine("돈이 부족합니다.\n");
                Thread.Sleep(500);
            }
        }
        public void Start()
        {
            Loading();

            bool isQuit = false;
            while (true)
            {
                if(isQuit)
                {
                    Console.WriteLine("게임을 종료합니다...");
                    Thread.Sleep(500);
                    break;
                }

                Console.Clear();
                Console.WriteLine("1. 나무 캐기");
                Console.WriteLine("2. 장비 뽑기");
                Console.WriteLine("3. 나가기");

                Console.Write("입력 : ");
                input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        CutTree();
                        break;
                    case 2:
                        GachaAxe();
                        break;
                    default:
                        isQuit = true;
                        break;
                }
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            #region 과제

            대장장이키우기 game = new 대장장이키우기();
            game.Start();

            /*string text = " 대장장이 키우기";
            string sparkle1 = "★ ☆";
            string sparkle2 = "☆ ★";

            while (!Console.KeyAvailable)
            {
                Console.Clear();
                Console.WriteLine($"{sparkle1}{text}{sparkle2}\n아무 키나 입력하면 시작");
                Thread.Sleep(500);

                Console.Clear();
                Console.WriteLine($"{sparkle2}{text}{sparkle1}\n아무 키나 입력하면 시작");
                Thread.Sleep(500);
            }

            Console.Clear();
            Console.ReadKey();

            Random rand = new Random();
            int pmoney = 10000;
            int input;
            int rnd;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. 나무 캐기");
                Console.WriteLine("2. 장비 뽑기");
                Console.WriteLine("3. 나가기");

                Console.Write("입력 : ");
                input = int.Parse(Console.ReadLine());

                if (input == 1)//나무캐기
                {
                    Console.Clear();
                    Console.WriteLine("나무캐기(엔터)");
                    Console.WriteLine("뒤로가기 x");

                    while (true)
                    {
                        string str = Console.ReadLine();

                        int treeValue = rand.Next(70, 101);
                        Console.WriteLine($"나무를 캐서 {treeValue}원을 얻었습니다.");
                        pmoney += treeValue;
                        Thread.Sleep(300);

                        if (str == "x")
                        {
                            Console.WriteLine("뒤로가기...");
                            Thread.Sleep(500);
                            break;
                        }
                    }
                }//if input 1
                else if (input ==2)//장비뽑기
                {
                    if (pmoney>=1000)
                    {
                        pmoney-=1000;

                        //20번뽑기
                        for (int i = 0; i<20; i++)
                        {
                            rnd = rand.Next(1, 101);
                            if (rnd==1)//1퍼
                            {
                                Console.WriteLine("도끼 등급 SSS");
                            }
                            else if (rnd<=6)//2~6, 5퍼
                            {
                                Console.WriteLine("도끼 등급 SS");
                            }
                            else if (rnd<=16)//7~16, 10퍼
                            {
                                Console.WriteLine("도끼 등급 S");
                            }
                            else if (rnd<=38)//17~38, 22퍼
                            {
                                Console.WriteLine("도끼 등급 A");
                            }
                            else if (rnd<=69)//39~69, 31퍼
                            {
                                Console.WriteLine("도끼 등급 B");
                            }
                            else//70~100 30퍼
                            {
                                Console.WriteLine("도끼 등급 C");
                            }
                            Thread.Sleep(500);
                        }
                    }//if(pmoney>=1000)
                    else
                    {
                        Console.WriteLine("돈이 부족합니다.\n");
                        Thread.Sleep(500);
                    }
                }//else if input 2
                else
                {
                    Console.WriteLine("게임을 종료합니다...");
                    Thread.Sleep(500);
                    break;
                }
            }//while*/

            #endregion
        }//main
    }
}
