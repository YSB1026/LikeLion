using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_벽돌깨기_과제
{
    class Program
    {
        public static int Clamp(int clamped, int min, int max)
        {
            return Math.Max(min, Math.Min(clamped, max));
        }
        static void Main()
        {
            Console.CursorVisible = false;
            new GameManager().Run();
        }
    }
}
