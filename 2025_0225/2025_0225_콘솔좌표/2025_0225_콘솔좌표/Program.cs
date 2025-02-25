using _2025_0225_콘솔좌표;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _2025_0225_콘솔좌표
{
    //Snake 게임!
    #region Console width, height 설정
    static class Constant
    {
        public const int WIDTH = 80, HEIGHT = 25;
    }
    #endregion
    #region 좌표 클래스
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
            if (a is null || b is null)
            {
                return false;
            }
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Position a, Position b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            bool case1 = a.x != b.x;
            bool case2 = a.y != b.y;
            return case1 || case2;
        }
    }
    #endregion
    #region 게임 보드 클래스
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
#endregion
    class SnakeGame
    {
        private Random rand;
        private readonly DrawBoard drawBoard;
        private LinkedList<Position> snake;
        private Position food;
        private int direction;
        private bool isGameover;
        public SnakeGame()
        {
            Console.OutputEncoding = new System.Text.UTF8Encoding(false);
            Console.CursorVisible = false;
            rand = new Random();

            drawBoard = new DrawBoard();
            snake = new LinkedList<Position>();
            food = new Position(-1,-1);
            direction = 0;//0:오른쪽, 1:아래, 2:왼쪽, 3:위
            isGameover = false;

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


        private void GenerateFood()//랜덤 좌표에 먹이 생성
        {
            if (food.x!=-1 && food.y!=-1) return;

            int x = rand.Next(3, Constant.WIDTH-3);
            int y = rand.Next(3, Constant.HEIGHT-3);
            food.x = x;
            food.y = y;
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow://상
                        direction = direction != 1 ? 3 : 1;
                        break;
                    case ConsoleKey.DownArrow://하
                        direction = direction != 3 ? 1 : 3;
                        //direction = 1;
                        break;
                    case ConsoleKey.LeftArrow://좌
                        direction = direction != 0 ? 2 : 0;
                        break;
                    case ConsoleKey.RightArrow://우
                        direction = direction != 2 ? 0 : 2;
                        break;
                    case ConsoleKey.Escape:
                        isGameover = true;
                        break;
                    default:
                        break;
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

            //snake.AddFirst(newHead);
            //snake.RemoveLast();
            snake.AddFirst(newHead);
            if (newHead == food)
            {
                //snake.AddFirst(newHead);
                food.x=-1;
                food.y=-1;
            }
            else
            {
                //snake.AddFirst(newHead);
                snake.RemoveLast();
            }
        }
        private void DrawGame()
        {
            //board그리기
            drawBoard.Draw();

            //뱀그리기
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

            //먹이 그리기
            if (food.x!=-1 && food.y!=-1)
            {
                Console.SetCursorPosition(food.x, food.y);
                Console.Write("★");
            }
        }

        private void CheckCrash()
        {
            Position head = snake.First.Value;
            if (head.x<=1 || head.x>=Constant.WIDTH-1 || head.y<=1 || head.y>=Constant.HEIGHT-1)
            {
                isGameover = true;
            }
            for (int i = 1; i<snake.Count; i++)
            {
                if (head == snake.ElementAt(i))
                {
                    isGameover = true;
                    break;
                }
            }
        }

        private void Gameover()
        {
            Console.Clear();
            Console.SetCursorPosition(Constant.WIDTH/2-5, Constant.HEIGHT/2);
            Console.WriteLine("💀Game Over💀");
            Thread.Sleep(2000);
        }

        public void Run()
        {
            DrawLoading();

            while (!isGameover)
            {
                Console.Clear();
                GenerateFood();
                Input();
                Move();
                CheckCrash();
                DrawGame();
                Thread.Sleep(100);
            }

            Gameover();
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Constant.WIDTH, Constant.HEIGHT);
            //콘솔 버퍼 크기로 설정
            Console.SetBufferSize(Constant.WIDTH, Constant.HEIGHT);

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
