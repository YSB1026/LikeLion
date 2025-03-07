using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_과제_textRPG_
{
    public interface ISkill
    {
        void ExecuteSkill(ICombatant target);
        bool IsCooldownReady();
    }
    public class Skill : ISkill
    {
        public string SkillName { get; private set; }
        public int SkillDamage { get; private set; }
        public int CoolDownTime { get; private set; }
        public int CooldownRemaining { get; private set; }

        public Skill(string skillName, int skillDamage, int coolDownTime)
        {
            SkillName = skillName;
            SkillDamage = skillDamage;
            CoolDownTime = coolDownTime;
            CooldownRemaining = 0;  // 처음엔 쿨다운이 0,
        }

        // 스킬 사용
        public void ExecuteSkill(ICombatant target)
        {
            if (IsCooldownReady())
            {
                Console.WriteLine($"{SkillName} 사용! 데미지: {SkillDamage}");
                target.TakeDamge(SkillDamage);
                CooldownRemaining = CoolDownTime;
            }
            else
            {
                Console.WriteLine($"{SkillName}은/는 아직 쿨다운 중입니다. 남은 시간: {CooldownRemaining}초");
            }
        }

        // 쿨다운이 끝났는지 확인
        public bool IsCooldownReady()
        {
            return CooldownRemaining == 0;
        }

        // 쿨다운을 1초씩 감소시킴
        public void UpdateCooldown()
        {
            if (CooldownRemaining > 0)
            {
                CooldownRemaining--;
            }
        }

        public void ResetCoolDown()
        {
            CooldownRemaining = 0;
        }
    }


    //public class MagicSkill : Skill//음 나중에; 너무 커지네
    //{
    //    public void ExecuteSkill(ICombatant target)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool IsCooldownReady()
    //    {
    //        return CooldownRemaining <= 0;
    //    }
    //}
}
