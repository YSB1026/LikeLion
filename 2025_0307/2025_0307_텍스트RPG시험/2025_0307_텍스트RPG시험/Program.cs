using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_텍스트RPG시험
{
    class Program
    {
        public static int PlayerInput()
        {
            int input;
            int.TryParse(Console.ReadLine(), out input);

            if (input !=0) return input;
            return -1;
        }
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Process();
        }
    }
}
