using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_벽돌깨기_과제
{
    public class Paddle
    {
        public int X;
        public readonly int length = 7;

        public void Move(ConsoleKey key)
        {
            if (key == ConsoleKey.A) X = Math.Max(0, X - 3);//못나가게 고정
            if (key == ConsoleKey.D) X = Math.Min(X + 3, GameManager.WIDTH-length);//못나가게 고정
        }
    }
}
