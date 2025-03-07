using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_study5
{
    public class Mage : GameClass
    {
        public Mage(string name) 
            : base(name : name, health : 80, attack:20, defense:5)
        {
            
        }
        public override void BasicAttack(GameClass target)
        {
            Console.WriteLine($"{Name}가 {target.Name}에게 마법 구체를 던집니다!");
            target.TakeDamage(Attack);
        }

        public override void SpecialAttack(GameClass target)
        {
            Console.WriteLine($"{Name}가 {target.Name}에게 파이어볼을 날립니다!");
            target.TakeDamage(Attack+20);
        }
    }
}
