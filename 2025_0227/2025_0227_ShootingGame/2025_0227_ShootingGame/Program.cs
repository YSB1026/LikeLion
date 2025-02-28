using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;


namespace _2025_0227_ShootingGame
{
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
    interface IGameObject
    {
        Point Position { get; }
        void Move(int dx, int dy);
        void Draw();
        bool CheckCollision(Point other);
    }


    class Point
    {
        public int X {  get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Move(int dx, int dy)
        {
            return new Point(X + dx, Y + dy);
        }
    }

    class Missile : IGameObject
    {
        public Point Position { get; private set; }
        public string Symbol { get; } = "->";

        public Missile(int x, int y)
        {
            Position = new Point(x, y);
        }

        public void Move(int dx = 1, int dy = 0)
        {
            Position = Position.Move(dx, dy);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }

        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Math.Abs(Position.Y - other.Y) <= 1;
        }
    }

    class Player : IGameObject
    {
        public Point Position { get; private set; }
        public List<Missile> Missiles { get; private set; }
        public int Health { get; set; }
        public int Score { get; set; }
        public string[] Symbol { get; } = new string[] { "@=", "🛸", "@=" };
        Stopwatch fireCool;
        long coolTime;

        public Player(int x = 0, int y = 12)
        {
            Position = new Point(x, y);
            Missiles = new List<Missile>();
            fireCool = new Stopwatch();
            fireCool.Start();
            coolTime = 300;
            Health = 5;
        }

        public void Fire()
        {
            if (fireCool.ElapsedMilliseconds < coolTime) return;
            Missiles.Add(new Missile(Position.X + 2, Position.Y + 1));
            fireCool.Restart();
        }

        public void Move(int dx, int dy)
        {
            Position = Position.Move(dx, dy);
        }

        public void Draw()
        {
            //Console.Write(Symbol);
            for (int i = 0; i < Symbol.Length; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.WriteLine(Symbol[i]);
            }
        }

        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Math.Abs(Position.Y - other.Y) <= 2;
        }
    }

    class Enemy : IGameObject
    {
        public Point Position { get; private set; }
        public string Symbol { get; } = "☄";

        public Enemy(int x, int y)
        {
            Position = new Point(x, y);
        }
        public void Move(int dx = -1, int dy = 0)
        {
            Position = Position.Move(dx, dy);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Symbol);
        }
        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Math.Abs(Position.Y - other.Y) <= 1;
        }
    }

    class ShootingGame
    {
        ConsoleKeyInfo keyInfo;
        Player player;
        List<Enemy> enemies;
        Stopwatch stopwatch = new Stopwatch();
        long prevSecond, currentSecond;
        bool isEscape = false;

        Stopwatch genTimer = new Stopwatch();
        long genCoolTime = 400;
        Random rand = new Random();


        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            genTimer.Start();
            stopwatch.Start();
            prevSecond = stopwatch.ElapsedMilliseconds;

            player = new Player(0, 12);
            enemies = new List<Enemy>();

            while (player.Health > 0 && !isEscape)
            {
                GenEnemy();
                ReadInput();
                Display();
            }

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
            Console.WriteLine("🦁Thank You🦁");
            Thread.Sleep(3000);
        }

        void GenEnemy()
        {
            if (genTimer.ElapsedMilliseconds < genCoolTime) return;
            int y = rand.Next(3, Console.WindowHeight - 3);
            enemies.Add(new Enemy(Console.WindowWidth - 2, y));
            genTimer.Restart();
        }

        void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W: if ((player.Position.Y - 1) > 0) player.Move(0, -1); break;
                    case ConsoleKey.S: if ((player.Position.Y - 1) < Console.WindowHeight - 5) player.Move(0, 1); break;
                    case ConsoleKey.A: if (player.Position.X > 0) player.Move(-1, 0); break;
                    case ConsoleKey.D: if (player.Position.X < Console.WindowWidth - 2) player.Move(1, 0); break;
                    case ConsoleKey.Spacebar: player.Fire(); break;
                    case ConsoleKey.Escape: isEscape = true; break;
                }
            }
        }

        void Display()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"체력 : {player.Health}\n점수 : {player.Score}");
            currentSecond = stopwatch.ElapsedMilliseconds;
            if (currentSecond - prevSecond >= 50)
            {
                Console.Clear();
                prevSecond = currentSecond;

                player.Draw();
                MoveMissiles();
                MoveEnemies();
            }
        }

        void MoveMissiles()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var missile in player.Missiles.ToList())
            {
                missile.Draw();
                missile.Move();
                if (missile.Position.X >= Console.WindowWidth - 2)
                {
                    player.Missiles.Remove(missile);
                }
            }
            Console.ResetColor();
        }

        void MoveEnemies()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                var enemy = enemies[i];
                enemy.Draw();
                enemy.Move();

                if (enemy.CheckCollision(player.Position))//플레이어와 충돌 확인
                {
                    player.Health--;
                    enemies.RemoveAt(i);
                }
                else if (enemy.Position.X <= 1)//맵 밖 나간지 확인
                {
                    enemies.RemoveAt(i);
                }
                else if (player.Missiles.Any(m => m.CheckCollision(enemy.Position)))//미사일 충돌 확인
                {
                    /*
                     *var missile = player.Missiles.FirstOrDefault(m => m.CheckCollision(enemy.Position)); 
                     *gpt 도움받음
                     *그냥 2중 for문으로 확인했는데 LINQ, 람다식을 활용
                     *FirstOrDefault 조건에 만족하는 첫번째 요소 없으면 default(null)
                     *m = > m.Check~ 람다식, Missile m이 m.CheckCollision(적)을 만족하는 m을 반환
                     */
                    var missile = player.Missiles.FirstOrDefault(m => m.CheckCollision(enemy.Position));
                    if (missile != null)
                    {
                        player.Missiles.Remove(missile);
                        enemies.RemoveAt(i);
                        player.Score += 100;
                    }
                }
            }

            //bool CheckCollision(Point obj1, Point obj2)
            //{
            //    return Math.Abs(obj1.X - obj2.X) <= 1 && Math.Abs(obj1.Y - obj2.Y) <= 1;
            //}

            //bool CheckMissileCollision(Point enemyPos)
            //{
            //    for (int i = player.Missiles.Count - 1; i >= 0; i--)
            //    {
            //        if (CheckCollision(player.Missiles[i].Position, enemyPos))
            //        {
            //            player.Missiles.RemoveAt(i);
            //            return true;
            //        }
            //    }
            //    return false;
            //}
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
}
