using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_과제_textRPG_
{
    //전사 클래스
    public class Player : CombatEntity
    {
        protected List<Skill> skills = new List<Skill>();
        public Player(string name, int health, int atk, int dfs)
        {
            Name = name;
            Health = health;
            Atk = atk;
            Dfs = dfs;
        }
        public override void Render()
        {
            base.Render();
            Console.WriteLine("======================보유 스킬======================");
            for (int i = 0; i<skills.Count; i++)
            {
                Console.WriteLine($"스킬 : {skills[i].SkillName} (공격력 : {skills[i].SkillDamage} | " +
                    $"쿨다운 남은 턴 : {skills[i].CooldownRemaining})");
            }
            UpdateSkillCoolDown();
        }

        public void UseSkill(ICombatant target, in int index)
        {
            Skill skill = skills[index-1];
            skill.ExecuteSkill(target);
            target.TakeDamge(skill.SkillDamage);
            Console.WriteLine($"{skill.SkillName}을 사용했습니다");
        }

        public void UpdateSkillCoolDown()
        {
            for (int i = 0; i<skills.Count; i++)
            {
                skills[i].UpdateCooldown();
            }
        }
    }
    public class Warrior : Player
    {
        public Warrior() :
            base(name: "전사", health: 200, atk: 15, dfs: 20)
        {
            skills.Add(new Skill(skillName:"그냥 찌르기",skillDamage:Atk+10, coolDownTime:1));
            skills.Add(new Skill(skillName: "보통 찌르기", skillDamage: Atk+20, coolDownTime: 2));
            skills.Add(new Skill(skillName: "세게 찌르기", skillDamage: Atk+30, coolDownTime: 4));
        }
    }

    public class Mage : Player
    {
        public Mage() :
            base(name: "마법사", health: 150, atk: 30, dfs: 10)
        {
            skills.Add(new Skill(skillName: "그냥 파이볼", skillDamage: Atk+10, coolDownTime: 1));
            skills.Add(new Skill(skillName: "보통 파이볼", skillDamage: Atk+20, coolDownTime: 2));
            skills.Add(new Skill(skillName: "아픈 파이볼", skillDamage: Atk+30, coolDownTime: 4));
        }
    }

    public class Enemy : CombatEntity
    {
        public Enemy(string name, int health, int atk, int dfs)
        {
            Name = name;
            Health = health;
            Atk = atk;
            Dfs = dfs;
        }
    }
}
