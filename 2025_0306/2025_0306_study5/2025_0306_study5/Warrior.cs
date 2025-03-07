using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study5
{
    public class Warrior : GameClass
    {
        public Warrior(string name)
            : base(name: name, health: 100, attack: 15, defense: 10)
        {

        }
        public override void BasicAttack(GameClass target)
        {
            Console.WriteLine($"{Name}가 {target.Name}에게 도끼를 휘두릅니다.");
            target.TakeDamage(Attack);
        }

        public override void SpecialAttack(GameClass target)
        {
            Console.WriteLine($"{Name}가 {target.Name}에게 도끼로 머리를 찍습니다!");
            target.TakeDamage(Attack+20);
        }
    }
}
