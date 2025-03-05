using _2025_0305_과제;
using System.Collections.Generic;
using System;

namespace _2025_0305_과제
{
    public class Champion
    {
        protected List<Skill> Skills = new List<Skill>();
        protected string Name;
        protected int Atk;
        protected int Mp;
        protected Voice Voice = new Voice();

        public virtual void Attack() { }
        public virtual void UseSkill(int playerInput) { }

        public string GetName() { return Name; }
        public int GetMana() { return Mp; }

        public IReadOnlyList<Skill> GetSkills() { return Skills.AsReadOnly(); }
    }

    public class 카타리나 : Champion
    {
        public 카타리나() // 카타리나는 노코스트!
        {
            Console.WriteLine("폭력은 모든 것을 해결해 주지.");
            Name = "익명의 실버 카타리나";
            Atk = 200;
            Mp = 0;
            Skills = new List<Skill>()
            {
                new Skill(name: "담검 투척", manaCost: 0, coolDown: 3),
                new Skill(name: "준비", manaCost: 0, coolDown: 4),
                new Skill(name: "순보", manaCost: 0, coolDown: 5),
                new Skill(name: "죽음의 연꽃", manaCost: 0, coolDown: 6)
            };
        }

        public override void Attack()
        {
            Console.WriteLine("카타리나가 공격!");
        }

        public override void UseSkill(int playerInput)
        {
            if (playerInput < 1 || playerInput > Skills.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            bool isUse = Skills[playerInput - 1].Use(ref Mp);
            if (isUse)
            {
                Console.WriteLine($"{Skills[playerInput - 1].Name} 스킬을 사용했습니다!");
            }
            else
            {
                Console.WriteLine($"{Skills[playerInput - 1].Name} 스킬은 사용할 수 없습니다.");
            }
        }
    }

    public class 가렌 : Champion
    {
        public 가렌() // 가렌도 노코스트..?
        {
            Console.WriteLine("내 검과 심장은 데마시아의 것이다!");
            Name = "골드 현지인의 가렌";
            Atk = 200;
            Mp = 0;
            Skills = new List<Skill>()
            {
                new Skill(name: "결정타", manaCost: 0, coolDown: 3),
                new Skill(name: "용기", manaCost: 0, coolDown: 4),
                new Skill(name: "심판", manaCost: 0, coolDown: 5),
                new Skill(name: "데마시아의 정의", manaCost: 0, coolDown: 6)
            };
        }

        public override void Attack()
        {
            Console.WriteLine("가렌이 공격!");
        }

        public override void UseSkill(int playerInput)
        {
            if (playerInput < 1 || playerInput > Skills.Count)
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            bool isUse = Skills[playerInput - 1].Use(ref Mp);
            if (!isUse)
            {
                Console.WriteLine($"{Skills[playerInput - 1].Name} 스킬은 사용할 수 없습니다.");
                return;
            }

            // 각 스킬에 맞는 대사 출력
            if (playerInput == 1)
            {
                Voice.대사 = "전진!";
            }
            else if (playerInput == 2)
            {
                Voice.대사 = "데마시아!";
            }
            else if (playerInput == 3)
            {
                Voice.대사 = "눈도 깜짝 안한다!";
            }
            else
            {
                Voice.대사 = "정의를 위해!";
            }

            Console.WriteLine(Voice.대사);
        }
    }
}