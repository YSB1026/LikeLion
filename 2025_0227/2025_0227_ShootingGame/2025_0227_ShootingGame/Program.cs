using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace _2025_0227_ShootingGame

    /*
     * 추가할 만한 것들
     * 1. 페이즈 추가
     * 2. 아이템 추가
     * ==============
     * 개선 점
     * 1. List말고 다른 자료구조 사용? -> 충돌 처리 로직 개선
     * 2. missile / player 구분
     * 3. move, attack 같은 로직 player,missile,enemy 클래스에 넣기
    */
    class Point
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
    }
    class Player
    {
        Point pos;
        List<Point> missiles;
        int health;
        Stopwatch fireCool;
        long coolTime;

        public Player(int x = 0, int y = 12)
        {
            pos = new Point(x, y);
            missiles = new List<Point>();

            coolTime = 300;
            fireCool = new Stopwatch();
            fireCool.Start();
            health = 5;
        }
        public void Fire()
        {
            if (fireCool.ElapsedMilliseconds < coolTime) return; //쿨타임일땐 발사 X
            missiles.Add(new Point(pos.X+2, pos.Y+1));
            fireCool.Restart();//쿨타임 초기화
        }
        public int X { get { return pos.X; } set { pos.X=value; } }
        public int Y { get { return pos.Y; } set { pos.Y=value; } }
        public long CoolTime { get { return coolTime; } set { coolTime = value; } }
        public List<Point> Missiles { get { return missiles; }}
        public Point Pos { get { return pos; } }
        public int Health { get { return health; } set { health = value; } }
    }

    class Enermy
    {
        List<Point> posList;
        Random rand;
        Stopwatch genCool;
        long genTime;
        public Enermy()
        {
            posList = new List<Point>();
            rand = new Random();
            genTime = 400;
            genCool = new Stopwatch();
            genCool.Start();
        }

        public void GenEnemy()
        {
            if (genCool.ElapsedMilliseconds < genTime) return;
            int _y = -1;
            _y = rand.Next(3, Console.WindowHeight-3);
            Point _genPoint = new Point(Console.WindowWidth-2, _y);
            posList.Add(_genPoint);
            genCool.Restart();

        }
        public List<Point> PosList { get { return posList; } }
        public int GenTime { get; set; }
    }
    class ShootingGame
    {
        ConsoleKeyInfo keyInfo;
        Player player;
        Enermy enemy;
        readonly string[] playerString = new string[] {
                "@=",
                "🛸",
                "@="
        };
        readonly string missileStr = "->";
        readonly string enemyStr = "☄";

        Stopwatch stopwatch = new Stopwatch();
        long prevSecond, currentSecond;
        bool isEscape = false;
        int score = 0;
        void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W: if ((player.Y-1) > 0) player.Y--; break;
                    case ConsoleKey.S: if ((player.Y-1) < Console.WindowHeight - 4) player.Y++; break;
                    case ConsoleKey.A: if (player.X > 0) player.X--; break;
                    case ConsoleKey.D: if (player.X < Console.WindowWidth - 2) player.X++; break;
                    case ConsoleKey.Spacebar: player.Fire(); break;
                    case ConsoleKey.Escape: isEscape = true; break;// ESC 키로 종료
                }
            }
        }
        void Display()
        {
            Console.SetCursorPosition(0,1);
            Console.WriteLine($"체력 : {player.Health}\n점수 : {score}");
            if (currentSecond - prevSecond >= 50)
            {
                Console.Clear();

                prevSecond = currentSecond;

                MovePlayer();
                MoveMissile();
                MoveEnemy();
            }
        }
        void MoveMissile()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = player.Missiles.Count-1; i>=0; i--)
            {
                Console.SetCursorPosition(player.Missiles[i].X, player.Missiles[i].Y-1);
                Console.Write(missileStr);
                player.Missiles[i].X++;
                if (player.Missiles[i].X >= Console.WindowWidth-2)
                {
                    player.Missiles.RemoveAt(i);
                    i--;
                }
            }

            Console.ResetColor();
        }

        bool CheckCollision(Point obj1, Point obj2)
        {
            if (Math.Abs(obj1.X - obj2.X) <= 1 && Math.Abs(obj1.Y - obj2.Y) <= 1)
            {
                return true;
            }
            return false;
        }
        bool CheckMissileCollision(Point enemy)
        {
            for(int i= player.Missiles.Count-1; i>=0; i--)
            {
                if (CheckCollision(player.Missiles[i],enemy))
                {
                    player.Missiles.RemoveAt(i);
                    return true;
                } 
            }
            return false;
        }
        void MoveEnemy()
        {
            for (int i = enemy.PosList.Count-1; i >=0; i--)
            { 
                Console.SetCursorPosition(enemy.PosList[i].X, enemy.PosList[i].Y);
                Console.Write(enemyStr);
                enemy.PosList[i].X--;
                if (CheckCollision(player.Pos, enemy.PosList[i]))
                {
                    player.Health--;
                    enemy.PosList.RemoveAt(i);
                }
                else if (enemy.PosList[i].X <= 1 || CheckMissileCollision(enemy.PosList[i]))
                {
                    enemy.PosList.RemoveAt(i);
                    score+=100;
                }
            }
        }

        void MovePlayer()
        {
            for (int i = 0; i < playerString.Length; i++)
            {
                Console.SetCursorPosition(player.X, (player.Y-1) + i);
                Console.WriteLine(playerString[i]);
            }
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            stopwatch.Start();
            prevSecond = stopwatch.ElapsedMilliseconds;

            player = new Player(0,12);
            enemy = new Enermy();
            while (player.Health>0 && !isEscape)
            {
                enemy.GenEnemy();
                currentSecond = stopwatch.ElapsedMilliseconds;
                ReadInput();
                Display();
            }//while

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth/2-5, Console.WindowHeight/2);
            Console.WriteLine("🦁Thank You🦁");
            Thread.Sleep(3000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShootingGame game = new ShootingGame();
            game.Run();
        }
    }
}
