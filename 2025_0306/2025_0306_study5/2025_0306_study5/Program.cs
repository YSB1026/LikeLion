using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("간단한 RPG");
            GameClass warrior = new Warrior("전사");
            GameClass mage = new Mage("마법사");

            Console.WriteLine("===전투시작!===");

            warrior.BasicAttack(mage);
            warrior.SpecialAttack(mage);

            mage.BasicAttack(warrior);
            mage.SpecialAttack(warrior);

            Console.WriteLine("전투 종료");
        }
    }
}
