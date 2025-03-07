using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_과제_textRPG_
{
    public interface ICombatant
    {
        void Attack(ICombatant target);
        void TakeDamge(int damage);
    }
    public abstract class CombatEntity : ICombatant
    {
        public string Name { get; set; }
        public int Health {  get; set; }
        public int Atk { get; set; }
        public int Dfs { get; set; }

        public void TakeDamge(int damage)
        {
            int acutualDmg = Math.Max(1, damage-Dfs);
            Health -= acutualDmg;
            Console.WriteLine($"{Name}이/가 {acutualDmg}의 공격 받았습니다.");
        }
        public void Attack(ICombatant target) {
            target.TakeDamge(Atk);
        }
        public virtual void Render()
        {
            Console.WriteLine($"이름  : {Name}");
            Console.WriteLine($"체력  : {Health}");
            Console.WriteLine($"공격력 : {Atk}");
            Console.WriteLine($"방어력 : {Dfs}");
        }
    }
}
