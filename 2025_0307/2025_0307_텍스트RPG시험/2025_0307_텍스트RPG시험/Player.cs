using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_텍스트RPG시험
{
    public class Player : Entity
    {
        public readonly int MAX_HEALTH;
        public Player(string name, int health, int atk, int dfs)
        {
            Name = name;
            Health = health;
            MAX_HEALTH = health;
            Atk = atk;
            Dfs = dfs;
        }
        public void Revive()
        {
            Health = MAX_HEALTH;
        }
        public override void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Dfs);
            Health -= actualDamage;
            Console.WriteLine($"{Name}는 {actualDamage}의 피해를 입음");
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine($"{Name}는 {target.Name}에게 공격합니다.");
            target.TakeDamage(Atk);
        }
    }

    public class Warrior : Player
    {
        public Warrior(string name = "전사", int health=200, int atk = 20, int dfs = 20) 
            : base(name, health, atk, dfs)
        { 
        }
    }

    public class Mage : Player
    {
        public Mage(string name = "마법사", int health = 150, int atk = 30, int dfs = 15) 
            : base(name, health, atk, dfs)
        {
        }
    }
}
