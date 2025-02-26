using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0226_Bingo
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

            //tuple활용해서 swap가능
            //(a, b) = (b, a);
        }
        static void Main(string[] args)
        {
            #region 1차원 배열 빙고
            //int[] array = new int[25];
            //Random rand = new Random();
            
            //for (int i = 0; i < 25; i++)
            //{
            //    array[i] = i + 1;
            //}

            ////shuffle
            //for (int i = 0; i < 100; i++)
            //{
            //    int r1 = rand.Next(25);
            //    int r2 = rand.Next(25);
            //    Swap(ref array[r1], ref array[r2]);
            //}

            //int bingo = 0;
            //string asterisk = "*";
            //int cnt = 0;
            ////빙고 게임
            //while (true)
            //{
            //    Console.WriteLine($"빙고 : {bingo}");
            //    for (int i = 0; i<5; i++)
            //    {
            //        for (int j = 0; j < 5; j++)
            //        {
            //            if (array[i*5 + j] == 0)
            //            {
            //                Console.Write($"{asterisk,3}");
            //            }
            //            else
            //            {
            //                Console.Write($"{array[i * 5 + j],3:D2}");
            //            }
            //        }
            //        Console.WriteLine();
            //    }//for, 보드판 그리기

            //    //해당 숫자 동그라미(*)처리
            //    Console.WriteLine("숫자를 입력하세요");
            //    int input = int.Parse(Console.ReadLine());
            //    bingo = 0;

            //    for (int i = 0; i < 25; i++)
            //    {
            //        if (array[i] == input)
            //        {
            //            array[i] = 0;
            //            break;
            //        }
            //    }

            //    //빙고 체크
            //    //가로 췤
            //    for (int i = 0; i<5; i++)
            //    {
            //        for (int j = 0; j < 5; j++)
            //        {
            //            if (array[i * 5 + j] == 0)
            //            {
            //                cnt++;
            //            }
            //        }
            //        if (cnt==5)
            //        {
            //            bingo++;
            //        }
            //        cnt = 0;
            //    }

            //    //세로 췤
            //    for (int i = 0; i<5; i++)
            //    {
            //        for (int j = 0; j < 5; j++)
            //        {
            //            if(array[j * 5 + i] == 0)
            //            {
            //                cnt++;
            //            }
            //        }
            //        if(cnt == 5)
            //        {
            //            bingo++;
            //        }
            //        cnt = 0;
            //    }

            //    //대각선 췤( ↘)
            //    for (int i = 0; i<5; i++)
            //    {
            //        if (array[i * 5 + i] == 0)//i * (width+1) + i
            //        {
            //            cnt++;
            //        }
            //        if(cnt == 5)
            //        {
            //            bingo++;
            //        }
            //        cnt=0;
            //    }
            //    //대각선 췤( ↙)
            //    for(int i = 0; i < 5; i++)
            //    {
            //        if (array[i * 4 + 4] == 0)//i * (width-1) + (width-1)
            //        {
            //            cnt++;
            //        }
            //        if(cnt == 5)
            //        {
            //            bingo++;
            //        }
            //        cnt=0;
            //    }


            //    Console.Clear();
            //}
            #endregion

            #region 2차원 배열 빙고

            int[,] board = new int[5, 5];//빙고판
            bool[,] check = new bool[5, 5];//선택된 숫자 체크
            Random rand = new Random();

            int bingoCount = 0;
            int input = 0;

            int[] numbers = new int[25];

            for (int i = 0; i < 25; i++) numbers[i] = i + 1;//빙고판 초기화

            //Shuffle
            for (int i = 0; i < 100; i++)
            {
                int r1 = rand.Next(25);
                int r2 = rand.Next(25);
                (numbers[r1], numbers[r2]) = (numbers[r2], numbers[r1]);
            }

            //빙고판에 숫자 배치
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i, j] = numbers[i * 5 + j];
                }
            }

            while (bingoCount<5)
            {
                Console.Clear();

                //빙고판 출력
                Console.WriteLine($"빙고 : {bingoCount}");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (check[i, j])
                        {
                            Console.Write($"{"X",4}");
                        }
                        else
                        {
                            Console.Write($" {board[i, j]:D2} ");
                        }
                    }
                    Console.WriteLine();
                }

                //입력받은 숫자 체크
                Console.WriteLine("숫자를 입력하세요");

                if (int.TryParse(Console.ReadLine(), out int n)) input = n;//숫자가 유효한지 체크
                else continue;

                if(input < 1 || input > 25) continue;//숫자가 유효한지 체크

                //입력받은 숫자 마스킹
                bool found = false;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (board[i, j] == input)
                        {
                            check[i, j] = true;
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }

                bingoCount = 0;

                //빙고 체크
                for (int i = 0; i < 5; i++)
                {
                    bool rowBingo = true, colBingo = true;//가로,세로 빙고

                    for (int j = 0; j < 5; j++)
                    {
                        if (!check[i, j]) rowBingo = false;
                        if (!check[j, i]) colBingo = false;
                    }

                    if (rowBingo) bingoCount++;
                    if (colBingo) bingoCount++;
                }

                bool diagonal1Bingo = true, diagonal2Bingo = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!check[i, i]) diagonal1Bingo = false;
                    if (!check[i, 4 - i]) diagonal2Bingo = false;
                }

                if (diagonal1Bingo) bingoCount++;
                if (diagonal2Bingo) bingoCount++;

            }//while

            Console.WriteLine("5 bingo!!");

            #endregion
        }
    }
}
