using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_BrickGame
{
    class GameManager
    {
        Ball ball = null;
        Bar bar = null;
        public void ScreenWall()
        {
            Program.gotoxy(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            for (int i = 1; i < 23; i++)
            {
                Program.gotoxy(0, i);
                Console.Write("┃                                                                              ┃");
            }
            Program.gotoxy(0, 23);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
        }

        public void Initialize()
        {
            //ScreenWall();
            if (ball == null)
            {
                ball = new Ball();
                ball.Initialize();
            }

            if (bar==null)
            {
                bar = new Bar();
                bar.Initialize();
            }

            ball.SetBar(bar);
        }

        public void Progress()
        {
            ball.MoveBall();
            bar.Progress(ball);
        }

        public void Render()
        {
            Console.Clear();
            ScreenWall();
            ball.Render();
            bar.Render();
        }

        public void Release()
        {
            ball.Release();
            bar.Release();
        }
    }
}
