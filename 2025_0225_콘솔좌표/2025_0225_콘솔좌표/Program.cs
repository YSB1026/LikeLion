using _2025_0225_콘솔좌표;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2025_0225_콘솔좌표
{
    //Snake 게임!
    static class Constant
    {
        public const int WIDTH = 80, HEIGHT = 25;
    }
    class Position
    {
        public int x;
        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public static bool operator ==(Position a, Position b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Position a, Position b)
        {
            bool case1 = a.x != b.x;
            bool case2 = a.y != b.y;
            return case1 || case2;
        }
    }
    class DrawBoard
    {
        string dash = "━";
        string title1 = "┌", title2 = "", title3 = "┐", title4 = "│", title5 = "└", title6 = "┘", space = "";
        public DrawBoard()
        {
            for (int _ = 0; _<Constant.WIDTH-2; _++)
            {
                title2 += dash;
                space += " ";
            }
        }

        public void Draw()
        {
            for (int i = 0; i<Constant.HEIGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                if (i == 0)
                {
                    Console.Write(title1 + title2 + title3);
                }
                else if (i<24)
                {
                    Console.Write(title4 + space + title4);
                }
                else
                {
                    Console.Write(title5 + title2 + title6);
                }
            }
        }
    }
    class SnakeGame
    {
        LinkedList<Position> snake;
        DrawBoard drawBoard;
        Random rand;
        int direction = 0;//0: 오른쪽, 1: 아래, 2: 왼쪽, 3: 위
        public SnakeGame()
        {
            Console.OutputEncoding = new System.Text.UTF8Encoding(false);
            Console.CursorVisible = false;
            snake = new LinkedList<Position>();
            drawBoard = new DrawBoard();
            rand = new Random();

            snake.AddFirst(new Position(Constant.WIDTH/2, Constant.HEIGHT/2));
            snake.AddLast(new Position(Constant.WIDTH/2+1, Constant.HEIGHT/2));
        }

        private void DrawLoading()
        {
            drawBoard.Draw();
            Console.SetCursorPosition(Constant.WIDTH/2-11, Constant.HEIGHT/2);
            Console.WriteLine("⚔️멋사콘솔게임만들기⚔️");
            Console.SetCursorPosition(Constant.WIDTH/2-9, Constant.HEIGHT/2+1);
            Console.WriteLine("⚔️Press Any Key⚔️");
            Console.ReadKey();
        }

        private void DrawGame()
        {
            drawBoard.Draw();

            foreach (var pos in snake)
            {
                Console.SetCursorPosition(pos.x, pos.y);
                if (pos==snake.First.Value)
                {
                    Console.Write("◎");
                }
                else
                {
                    Console.Write("○");
                }
            }
        }

        private void Move()
        {
            Position head = snake.First.Value;
            Position newHead = new Position(head.x, head.y);
            switch (direction)
            {
                case 0://오른쪽
                    newHead.x++;
                    break;
                case 1://아래
                    newHead.y++;
                    break;
                case 2://왼쪽
                    newHead.x--;
                    break;
                case 3://위
                    newHead.y--;
                    break;
            }
            snake.AddFirst(newHead);
            snake.RemoveLast();
        }
        private void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow://상
                        direction = 3;
                        break;
                    case ConsoleKey.DownArrow://하
                        direction = 1;
                        break;
                    case ConsoleKey.LeftArrow://좌
                        direction = 2;
                        break;
                    case ConsoleKey.RightArrow://우
                        direction = 0;
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        //ver2 추가해야할 로직
        //1.뱀이 먹이를 먹었을 때 꼬리 늘어나는 로직
        //2.Board 밖으로 갔을때 GameOver 로직
        //3.사용자가 입력한 방향과 현재 방향이 반대일 때 입력 무시
        //4.랜덤 좌표 먹이 생성 및 먹이를 먹었을 때 먹이를 새로운 위치에 생성
        //
        
        //private void GenerateFood()//랜덤 좌표에 먹이 생성
        //{
                
        //}

        public void Run()
        {
            DrawLoading();

            while (true)
            {
                Console.Clear();
                Input();
                Move();
                DrawGame();
                Thread.Sleep(100);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame snakeGame = new SnakeGame();
            snakeGame.Run();
            #region 이전코드
            //Console.OutputEncoding = new System.Text.UTF8Encoding(false);

            //const int WIDTH = 80, HEIGHT = 25;
            ////콘솔 창 크기 설정
            //Console.SetWindowSize(WIDTH, HEIGHT);
            ////콘솔 버퍼 크기로 설정
            //Console.SetBufferSize(WIDTH, HEIGHT);

            //Console.Title = "멋사콘솔게임만들기";
            ////Console.BackgroundColor = ConsoleColor.White;

            //Console.CursorVisible = false;//커서 안보이게 설정
            //Console.Clear();//콘솔창 초기화

            //string dash = "━";
            //string title1 = "┌", title2 = "", title3 = "┐", title4 = "│", title5 = "└", title6 = "┘", space = "";
            //for (int _ = 0; _<WIDTH-2; _++)
            //{
            //    title2 += dash;
            //    space += " ";
            //}

            //for (int i = 0; i<HEIGHT; i++)
            //{
            //    Console.SetCursorPosition(0, i);
            //    if (i == 0)
            //    {
            //        Console.Write(title1 + title2 + title3);
            //    }
            //    else if (i<24)
            //    {
            //        Console.Write(title4 + space + title4);
            //    }
            //    else
            //    {
            //        Console.Write(title5 + title2 + title6);
            //    }
            //}

            //Console.SetCursorPosition(WIDTH/2-11, HEIGHT/2);
            //Console.WriteLine("⚔️멋사콘솔게임만들기⚔️");

            //Thread.Sleep(3000);

            //for (int x = 0; x<WIDTH; x++)
            //{
            //    Console.Clear();
            //    Console.SetCursorPosition(x, HEIGHT/2);
            //    Console.Write("◎");
            //    Thread.Sleep(100);
            //}

            //Console.ReadKey();
            #endregion
        }
    }
}
