using _2025_0227_ShootingGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Timers;


namespace _2025_0227_ShootingGame
{
    interface IGameObject
    {
        Point Position { get; }
        void Move(int dx, int dy);
        void Draw();
        bool CheckCollision(Point other);
    }


    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }//Point

    class Missile : IGameObject
    {
        public Point Position { get; private set; }
        public string Sprite { get; } = "->";

        public Missile(int x, int y)
        {
            Position = new Point(x, y);
        }

        public void Move(int dx = 1, int dy = 0)
        {
            Position.Move(dx, dy);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Sprite);
        }

        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Position.Y == other.Y;
        }
    }//Missile

    class Player : IGameObject
    {
        public Point Position { get; private set; }
        public List<Missile> Missiles { get; private set; }
        public int Health { get; set; }
        public int Score { get; set; }
        public string[] Sprite { get; } = new string[] { "@=", "🛸", "@=" };
        public int MissileCount { get; set; }
        public bool Boosted { get; set; }

        public int BosstedTime { get; set; }

        Stopwatch fireCool;
        long coolTime;

        public Player(int x = 0, int y = 12)
        {
            Position = new Point(x, y);
            Missiles = new List<Missile>();
            fireCool = new Stopwatch();
            fireCool.Start();
            coolTime = 200;
            Health = 5;
            MissileCount = 1;
            Boosted = false;
        }

        public void Fire()
        {
            if (fireCool.ElapsedMilliseconds < coolTime) return;
 
            if (Boosted)
            {
                for (int i = 0; i < Sprite.Length; i++)
                {
                    Missiles.Add(new Missile(Position.X + 2, Position.Y + i));
                }
                
                Boosted = false;
            }
            else
            {
                Missiles.Add(new Missile(Position.X + 2, Position.Y + 1));
            }

            fireCool.Restart();
        }

        public void Move(int dx, int dy)
        {
            Position.Move(dx, dy);
        }

        public void Draw()
        {
            //Console.Write(Sprite);
            for (int i = 0; i < Sprite.Length; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.WriteLine(Sprite[i]);
            }
        }

        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Math.Abs((Position.Y+1) - other.Y) <= 1;
        }
    }//Player

    class Enemy : IGameObject
    {
        public Point Position { get; private set; }
        public string Sprite { get; private set; } = "☄";
        
        public Enemy(int x, int y)
        {
            Position = new Point(x, y);
        }
        public void Move(int dx = -1, int dy = 0)
        {
            Position.Move(dx, dy);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Sprite);
        }
        public bool CheckCollision(Point other)
        {
            return (Math.Abs(Position.X - other.X) <= 1) && (Position.Y == other.Y);
        }
    }//Enemy

    class Item : IGameObject
    {
        public Point Position { get; set; }
        //public bool ItemLife { get; set; } = false;

        public string Sprite = "🌟";

        public Item(int x, int y)
        {
            Position = new Point(x, y);
        }

        public void Move(int dx = -1, int dy = 0)
        {
            Position.Move(dx, dy);
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Sprite);
        }

        public bool CheckCollision(Point other)
        {
            return Math.Abs(Position.X - other.X) <= 1 && Position.Y == other.Y;
        }
    }//Item

    class ShootingGame//입력, 플레이어, 적 객체 관리
    {
        ConsoleKeyInfo keyInfo;
        Random rand = new Random();

        Player player = new Player(1, 12);
        List<Enemy> enemies = new List<Enemy>();
        List<Item> items = new List<Item>();

        int dwTime;
        int genTime;

        bool isEscape = false;

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            dwTime = Environment.TickCount;
            genTime = Environment.TickCount;

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
            if (genTime + 400 > Environment.TickCount) return;
            genTime = Environment.TickCount;

            int _y = rand.Next(3, Console.WindowHeight - 3);
            enemies.Add(new Enemy(Console.WindowWidth - 2, _y));
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

        public void DrawUI()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");

            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");

            Console.SetCursorPosition(65, 1);
            Console.Write($"Score  : {player.Score,2}");

            Console.SetCursorPosition(63, 2);
            Console.Write("┃              ┃");

            Console.SetCursorPosition(65, 2);
            Console.Write($"Health : {player.Health,2}");

            Console.SetCursorPosition(63, 3);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        void Display()
        {
            if (dwTime + 50 < Environment.TickCount)
            {
                dwTime = Environment.TickCount;

                Console.Clear();

                DrawUI();
                player.Draw();
                MoveMissiles();
                MoveEnemies();
                CheckMissileCollision();
                MoveItem();
            }
        }
        void MoveMissiles()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = player.Missiles.Count - 1; i >= 0; i--)
            {
                var missile = player.Missiles[i];
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

                if (enemy.CheckCollision(new Point(1, enemy.Position.Y)))//왼쪽 벽 충돌 확인 
                {
                    enemies.RemoveAt(i);
                }
                else if (player.CheckCollision(enemy.Position))//플레이어와 충돌 확인
                {
                    player.Health--;
                    enemies.RemoveAt(i);
                }
            }
        }
        void CheckMissileCollision()
        {
            List<Missile> missiles = player.Missiles;

            for (int i = missiles.Count - 1; i >= 0; i--)
            {
                var missile = missiles[i];

                if (CheckEnemyCollision(missile))
                {
                    missiles.RemoveAt(i);
                }
                else if (CheckItemCollision(missile))
                {
                    missiles.RemoveAt(i);
                }
            }
        }

        bool CheckEnemyCollision(Missile missile)
        {
            var enemy = enemies.FirstOrDefault(e => e.CheckCollision(missile.Position));
            if (enemy != null)
            {
                items.Add(new Item(enemy.Position.X, enemy.Position.Y));
                enemies.Remove(enemy);
                player.Score += 1;
                return true;
            }
            return false;
        }

        bool CheckItemCollision(Missile missile)
        {
            var item = items.FirstOrDefault(m => m.CheckCollision(missile.Position));
            if (item != null)
            {
                player.Boosted = true;
                items.Remove(item);
                return true;
            }
            return false;
        }
        void MoveItem()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var item = items[i];
                item.Draw();
                item.Move();

                if (item.CheckCollision(new Point(1, item.Position.Y)))//왼쪽 벽 충돌 확인 
                {
                    items.RemoveAt(i);
                }
            }
        }
    }//Shooting Game

    class Program
    {
        static void Main(string[] args)
        {
            ShootingGame game = new ShootingGame();
            game.Run();
        }
    }
}

