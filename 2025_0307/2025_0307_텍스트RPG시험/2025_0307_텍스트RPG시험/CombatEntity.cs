using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_텍스트RPG시험
{
    public interface Combatant
    {
        void TakeDamage(int damage);
        void Attack(Entity target);
    }
    public abstract class Entity : Combatant
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Atk { get; protected set; }
        public int Dfs { get; protected set; }
        public abstract void TakeDamage(int damage);

        public abstract void Attack(Entity target);

        public void Render()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"이름 : {Name}, 체력 {Health}, 공격력 : {Atk}, 방어력 : {Dfs}");
            Console.WriteLine("==================================================");
        }
    }
}
