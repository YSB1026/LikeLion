using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study5
{
    public abstract class GameClass
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        protected GameClass(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public abstract void BasicAttack(GameClass target);
        public abstract void SpecialAttack(GameClass target);
        public void TakeDamage(int damage)
        {
            int actualDage = Math.Max(1, damage - Defense);
            Health -= actualDage;
            Console.WriteLine($"{Name}가 {actualDage}의 피해를 받았습니다! (남은체력 : {Health})");
        }
    }


}
