using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0305_study6
{
    class Unit
    {
        public string Name;
        protected int Health;

        public Unit()
        {
            Name = "Unknown";
            Health = 0;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name}이 기본 공격을 합니다.");
        }

        public virtual void Heal(Unit target)
        {
            Console.WriteLine($"{target.Name}을 치유 합니다.");
        }
        public virtual void Move()
        {
            Console.WriteLine($"{Name}이 이동합니다.");
        }
    }

    class SCV : Unit
    {
        public SCV()
        {
            Name = "SCV";
            Health = 60;
        }

        public override void Attack()
        {
            Console.WriteLine($"{Name}이 피눈물을 흘리며 공격합니다..! 노예의 서러움");
        }

        public override void Heal(Unit target)
        {
            Console.WriteLine($"{Name}가 {target.Name}을 수리합니다. 기계 유닛만 가능");
        }
    }

    class Marine : Unit
    {
        public Marine()
        {
            Name = "Marine";
            Health = 40;
        }

        public override void Attack()
        {
            Console.WriteLine("Marine이 소총으로 공격합니다.");
        }
    }

    class Medic : Unit
    {
        public Medic()
        {
            Name = "Medic";
            Health = 50;
        }

        public override void Attack() {
            //this unit cannot attack
        }

        public override void Heal(Unit target)
        {
            Console.WriteLine($"Medic이 {target.Name}을 치료합니다. (생명유닛만가능)");
        }
    }

    class Tank : Unit
    {
        public Tank()
        {
            Name = "Tank";
            Health = 150;

        }

        public override void Attack()
        {
            Console.WriteLine("Tank가 시즈 모드로 강력한 포격!");
        }


        public override void Move()
        {
            Console.WriteLine("탱크가 천천히 움직입니다.");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Unit> units = new List<Unit>();

            units.Add(new SCV());
            units.Add(new Medic());
            units.Add(new Tank());
            units.Add(new Marine());

            foreach(Unit unit in units)
            {
                unit.Attack();
                unit.Move();
                Console.WriteLine();
            }

            SCV scv = new SCV();
            scv.Heal(units[2]);//탱크 수리

            Medic medic = new Medic();
            medic.Heal(units[1]);//메딕을 치료
        }
    }
}
