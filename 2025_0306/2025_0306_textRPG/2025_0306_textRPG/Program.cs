using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_textRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            MainGame mainGame = new MainGame();
            mainGame.Initialize();
            mainGame.Progress();
        }
    }
}
