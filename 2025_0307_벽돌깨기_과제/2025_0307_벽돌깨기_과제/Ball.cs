using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_벽돌깨기_과제
{
    public class Ball
    {
        public int X, Y;
        public int DirX = 1, DirY = -1;

        public void Move()
        {

            X += DirX;
            Y += DirY;
        }
    }

}
