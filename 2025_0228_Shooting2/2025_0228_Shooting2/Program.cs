using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0228_Shooting2
{
    //Bullet class
    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Fire { get; set; }

        string symbol = "->";
        public void Draw()
        {
            Console.Write(symbol);
        }
    }
    //플레이어 클래스
    class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();
        public int X { get; set; }
        public int Y { get; set; }

        public int Score { get; set; } = 0;

        public Bullet[] bullets = new Bullet[20];
        public Bullet[] bullets2 = new Bullet[20];
        public Bullet[] bullets3 = new Bullet[20];

        public Item item = new Item();
        public int itemCount = 0;

        private string[] symbol =
        {
            "->",
            ">>>",
            "->"
        };

        public Player()
        {
            X = 0;
            Y = 12;
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new Bullet();
                bullets[i].X = 0;
                bullets[i].Y = 0;
                bullets[i].Fire = false;

                bullets2[i] = new Bullet();
                bullets2[i].X = 0;
                bullets2[i].Y = 0;
                bullets2[i].Fire = false;

                bullets3[i] = new Bullet();
                bullets3[i].X = 0;
                bullets3[i].Y = 0;
                bullets3[i].Fire = false;
            }
        }

        public void GameMain()
        {
            //점수 UI그리기
            UIscore();
            //키를 입력하는 부분
            KeyControl();
            //플레이어를 그려줌
            PlayerDraw();

            if (item.ItemLife)
            {
                item.ItemMove();
                item.ItemDraw();
                CrashItem();
            }
        }

        //키를 입력하는 부분
        public void KeyControl()
        {
            int pressKey;
            if (Console.KeyAvailable)
            {
                pressKey = _getch();
                if (pressKey == 224)
                    pressKey = _getch();
                switch (pressKey)
                {
                    case 72: Y = (Y < 1) ? 1 : --Y; break;//위쪽 방향키
                    case 75: X = (X < 1) ? 0 : --X; break;//오
                    case 77: X = (X > 75) ? 75 : ++X; break;//오른쪽 방향키
                    case 80: Y = (Y > 20) ? 20 : ++Y; break;//아래쪽 방향키
                    case 32: Attack(); break; //space bar
                }
            }
        }

        //플레이어를 그려줌
        public void PlayerDraw()
        {
            for (int i = 0; i<symbol.Length; i++)
            {
                Console.SetCursorPosition(X, Y+i);
                Console.WriteLine(symbol[i]);
            }
        }

        //미사일 그리기
        public void BulletDraw()
        {
            //string bullet = "->";
            for (int i = 0; i < bullets.Length; i++)
            {
                if (!bullets[i].Fire) continue;

                Console.SetCursorPosition(bullets[i].X, bullets[i].Y);
                bullets[i].Draw();

                bullets[i].X++;
                if (bullets[i].X > 78)
                {
                    bullets[i].Fire = false;
                }
            }
        }

        public void BulletDraw2()
        {
            //string bullet = "->";
            for (int i = 0; i < bullets2.Length; i++)
            {
                if (!bullets2[i].Fire) continue;

                Console.SetCursorPosition(bullets2[i].X, bullets2[i].Y);
                bullets2[i].Draw();

                bullets2[i].X++;
                if (bullets2[i].X > 78)
                {
                    bullets2[i].Fire = false;
                }
            }
        }

        public void BulletDraw3()
        {
            //string bullet = "->";
            for (int i = 0; i < bullets3.Length; i++)
            {
                if (!bullets3[i].Fire) continue;

                Console.SetCursorPosition(bullets3[i].X, bullets3[i].Y);
                bullets3[i].Draw();

                bullets3[i].X++;
                if (bullets3[i].X > 78)
                {
                    bullets3[i].Fire = false;
                }
            }
        }

        //충돌 처리
        public void ClashEnemyAndBullet(Enemy enemy)
        {
            for (int i = 0; i<bullets.Length; i++)
            {
                if (!bullets[i].Fire) continue;
                if (bullets[i].Y == enemy.Y)
                {
                    if (bullets[i].X >= enemy.X-1 && bullets[i].X <= enemy.X+1)//Math.Abs써도될듯,
                    {
                        Random rand = new Random();
                        enemy.X = 75;
                        enemy.Y = rand.Next(2, 22);
                        bullets[i].Fire = false;
                    }
                }
            }
        }
        public void ClashEnemyAndBullet2(Enemy enemy)
        {
            for (int i = 0; i<bullets2.Length; i++)
            {
                if (!bullets2[i].Fire) continue;
                if (bullets2[i].Y == enemy.Y)
                {
                    if (bullets2[i].X >= enemy.X-1 && bullets2[i].X <= enemy.X+1)//Math.Abs써도될듯,
                    {
                        Random rand = new Random();
                        enemy.X = 75;
                        enemy.Y = rand.Next(2, 22);
                        bullets2[i].Fire = false;
                    }
                }
            }
        }

        public void ClashEnemyAndBullet3(Enemy enemy)
        {
            for (int i = 0; i<bullets3.Length; i++)
            {
                if (!bullets3[i].Fire) continue;
                if (bullets3[i].Y == enemy.Y)
                {
                    if (bullets3[i].X >= enemy.X-1 && bullets3[i].X <= enemy.X+1)//Math.Abs써도될듯,
                    {
                        Random rand = new Random();
                        enemy.X = 75;
                        enemy.Y = rand.Next(2, 22);
                        bullets3[i].Fire = false;
                    }
                }
            }
        }

        private void Attack()
        {
            //총알2(중앙)
            for (int i = 0; i < bullets2.Length; i++)
            {
                if (bullets2[i].Fire) continue;//발사하지 않은경우.
                {
                    bullets2[i].Fire = true;
                    bullets2[i].X = X+5;
                    bullets2[i].Y = Y+1;
                    return;
                }
            }
            //총알1(위쪽)
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Fire) continue;//발사하지 않은경우.

                bullets[i].Fire = true;
                bullets[i].X = X+5;
                bullets[i].Y = Y;
                return;

            }
            //총알3(아래)
            for (int i = 0; i < bullets3.Length; i++)
            {
                if (bullets3[i].Fire) continue;//발사하지 않은경우.
                bullets3[i].Fire = true;
                bullets3[i].X = X+5;
                bullets3[i].Y = Y+2;
                return;
            }

        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        //아이템 충돌이 일어나면 양쪽 미사일 발사
        public void CrashItem()
        {
            if (X+1==item.itemY)
            {
                if(X >= item.itemX-2 && X <= item.itemX +2)
                {
                    item.ItemLife = false;

                    if (itemCount<3)
                        itemCount++;

                    for (int i = 0; i<20; i++)//총알 초기화
                    {
                        bullets[i] = new Bullet();
                        bullets[i].X = 0;
                        bullets[i].Y = 0;
                        bullets[i].Fire = false;

                        bullets2[i] = new Bullet();
                        bullets2[i].X = 0;
                        bullets2[i].Y = 0;
                        bullets2[i].Fire = false;

                        bullets3[i] = new Bullet();
                        bullets3[i].X = 0;
                        bullets3[i].Y = 0;
                        bullets3[i].Fire = false;
                    }
                }
            }
        }
    }//player

    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        Random random = new Random();

        public Enemy()
        {
            X = 77;
            Y = 12;
        }
        string symbol = "<-0->";

        public void EnemyDraw()
        {
            Console.SetCursorPosition(X, Y); //좌표설정
            Console.Write(symbol);//출력

        }
        public void EnemyMove()
        {
            X--; //왼쪽으로 움직임

            if (X <2) //화면 왼쪽넘어가면 새로 좌표잡아라
            {
                X = 77; //좌표 77
                Y = random.Next(2, 22); //2~21 
            }
        }
    }//Enemy

    class Item
    {
        public string ItemName { get; set; }
        public string ItemSprite;
        public int itemX { get; set; }
        public int itemY { get; set; }
        public bool ItemLife { get; set; } = false;

        public void ItemDraw()
        {
            Console.SetCursorPosition(itemX, itemY);
            ItemSprite = "★Item★";
            Console.Write(ItemSprite);
        }

        public void ItemMove()
        {
            //if (itemX<=1||itemY<=1)
            //{
            //    ItemLife=false;
            //}
        }
    }//Item

    class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Player player = new Player();
            Enemy enemy = new Enemy();
            //유니티처럼 속도 프레임 속도 조절
            int dwTime = Environment.TickCount;// 1ms씩 
            while (true)
            {
                if (dwTime + 50 < Environment.TickCount)
                {
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    //플레이어
                    player.GameMain();

                    //총알
                    player.BulletDraw2();
                    player.BulletDraw();
                    player.BulletDraw3();
                    //적
                    enemy.EnemyMove();
                    enemy.EnemyDraw();

                    //충돌 처리
                    player.ClashEnemyAndBullet(enemy);
                    player.ClashEnemyAndBullet2(enemy);
                    player.ClashEnemyAndBullet3(enemy);
                }
            }
        }
    }
}
