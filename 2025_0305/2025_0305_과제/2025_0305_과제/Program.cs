using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0305_과제
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Champion> champions = new List<Champion>()
            {
                new 카타리나(),
                new 가렌()
            };

            int turn = 0;
            while (true)
            {
                Console.Clear();
                bool okFlag = true;
                Champion champion = champions[turn];
                Console.WriteLine($"{champion.GetName()}의 차례");
                Console.WriteLine($"현재 MP : {champion.GetMana()}");

                Console.WriteLine("0. 종료");
                Console.WriteLine("1. 기본 공격");
                Console.WriteLine("2. 스킬 사용");
                Console.Write("선택지를 입력하세요 : ");

                try
                {
                    int playerInput = int.Parse(Console.ReadLine());

                    if (playerInput == 0) break;
                    else if (playerInput == 1) champion.Attack();
                    else if (playerInput == 2)
                    {
                        Console.WriteLine("============ 스킬 ============");
                        var skills = champion.GetSkills();
                        foreach (Skill skill in skills)
                        {
                            Console.WriteLine($"{skill.Name}, 쿨다운 {skill.CoolDown / 1000}초");
                        }

                        Console.Write("1, 2, 3, 4 중 입력 : ");
                        int skillIndex = int.Parse(Console.ReadLine());
                        champion.UseSkill(skillIndex);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력");
                        okFlag = false;
                    }
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine("잘못된 입력");
                    Console.WriteLine(e.Message);
                    okFlag = false;
                }

                if (okFlag) turn = (turn + 1) % 2;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
