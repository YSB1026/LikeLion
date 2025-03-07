using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0307_벽돌깨기_과제
{
    class GameManager
    {
        public const int WIDTH = 30;
        public const int HEIGHT = 15;
        private char[,] bricks = new char[WIDTH, 5];
        private Ball ball = new Ball { X = 15, Y = 10 };
        private Paddle paddle = new Paddle { X = 12 };
        private bool isRunning = true;

        public GameManager()
        {
            for (int x = 0; x < WIDTH; x++)
                for (int y = 0; y < 5; y++)
                    bricks[x, y] = '□';
        }

        public void Run()
        {
            int tickTime = Environment.TickCount;
            while (isRunning)
            {
                if (tickTime + 100 < Environment.TickCount)
                {
                    Input();
                    Draw();
                    Logic();
                    tickTime = Environment.TickCount;
                }
            }
        }

        private void Draw()
        {
            Console.Clear();
            for (int y = -1; y <= HEIGHT; y++)
            {
                for (int x = -1; x <= WIDTH; x++)
                {
                    if (x == -1 || x == WIDTH || y == -1 || y == HEIGHT) Console.Write('■');//벽그리기
                    else if (y < 5 && bricks[x, y] == '□') Console.Write('□');//벽돌그리기
                    else if (x == ball.X && y == ball.Y) Console.Write('●');//공그리기
                    else if (y == HEIGHT - 2 && x >= paddle.X && x < paddle.X + paddle.length) Console.Write('-');//paddle그리기
                    else Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        private void Input()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                paddle.Move(key);
            }
        }


        private void Logic()
        {
            ball.Move();

            if (ball.X <= 0 || ball.X >= WIDTH - 1) ball.DirX *= -1;//왼쪽 오른쪽 벽에 부딪힌 경우, x의 방향이 반대로 바뀌면됨
            if (ball.Y <= 0) ball.DirY *= -1; //위쪽 벽에 닿은경우도 마찬가지
            if (ball.Y >= HEIGHT) isRunning = false;//아래쪽 벽에 닿으면 게임 over

            //HEIGHT - 2이 paddl위치라 그 위인 -3에서 paddle 충돌 체크
            //paddle에 공이 닿은경우도 y 방향만 바꾸면됨.
            if (ball.Y == HEIGHT - 3 && ball.X >= paddle.X && ball.X < paddle.X + paddle.length)
                ball.DirY *= -1;

            if ((ball.Y>=0 && ball.Y < 5) && bricks[ball.X, ball.Y] == '□')//brick에 부딪힌경우엔 brick 없에고 공 아래로 가게 만들기
            {
                bricks[ball.X, ball.Y] = ' ';
                ball.DirY *= -1;
            }
        }
    }

}
