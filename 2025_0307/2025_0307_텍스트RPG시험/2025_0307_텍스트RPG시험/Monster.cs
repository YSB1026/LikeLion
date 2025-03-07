using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_텍스트RPG시험
{
    public class Monster : Entity
    {
        public Monster(string name, int health, int atk, int dfs)
        {
            Name = name;
            Health = health;
            Atk = atk;
            Dfs = dfs;
        }
        public override void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(1, damage - Dfs);
            Health -= actualDamage;
            Console.WriteLine($"{Name}은 {actualDamage}의 피해를 입음 (남은 체력 {Health})");
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine($"{Name}은 {target.Name}을 공격함");
            target.TakeDamage(Atk);
        }
    }
}
