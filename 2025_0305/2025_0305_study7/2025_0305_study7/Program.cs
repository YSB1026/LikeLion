using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0305_study7
{
    class Skill
    {
        public string Name;//스킬이름
        public int ManaCost;//마나 소모량
        public int CoolDown;//재사용 대기 시간
        public int LastUsedTime;//마지막 사용 시간

        public Skill(string name, int manaCost, int coolDown)
        {
            Name=name;
            ManaCost=manaCost;
            CoolDown=coolDown * 1000;//밀리초 변환
            LastUsedTime=0;//처음엔 사용하지 않은 상태
        }

        //스킬 사용 가능 여부 확인
        public bool CanUse(int playerMana)
        {
            int currentTime = Environment.TickCount;

            if (playerMana < ManaCost)
            {
                Console.WriteLine($"마나가 부족합니다!!(필요 MP:{ManaCost}");
                return false;
            }

            if (currentTime - LastUsedTime < CoolDown)//사용자가 스킬을 눌렀지만, 쿨다운일 때
            {
                int remainingTime = (CoolDown - (currentTime - LastUsedTime)) / 1000;
                Console.WriteLine($"{Name} 스킬은 아직 사용할 수 없습니다. (남은 시간 : {remainingTime}");
                return false;
            }

            return true;
        }

        public void Use(ref int playerMana)
        {
            if (!CanUse(playerMana)) return;

            playerMana -= ManaCost;
            LastUsedTime = Environment.TickCount;

            Console.WriteLine($"{Name} 스킬 사용! (MP - {ManaCost})");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int playerMana = 200;//플레이어의 초기 마나
            //스킬 목록 (배열 사용)
            Skill[] skills = new Skill[]
            {
                new Skill("파이어볼",20,3), //마나 20, 소모, 3초 쿨다운
                new Skill("얼음창",15,2),  //마나 15, 소모, 2초 쿨다운
                new Skill("힐링",20,3),       //마나 30, 소모, 5초 쿨다운
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"현재 MP : {playerMana}");
                Console.WriteLine("사용 가능한 스킬 :");
                for (int i = 0; i < skills.Length; i++)
                {
                    Console.WriteLine($"{i+1} : {skills[i].Name}" + 
                        $", 쿨다운 {skills[i].CoolDown/1000} s");
                }
                Console.WriteLine("0.종료");
                Console.Write("사용할 스킬 번호를 입력하세요 :");

                try
                {
                    int skillIndex = int.Parse(Console.ReadLine());

                    if (skillIndex ==0) break;

                    if (skillIndex >0 && skillIndex <= skills.Length)
                    {
                        skills[skillIndex-1].Use(ref playerMana);
                    }
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine("잘못된 입력");
                    Console.WriteLine(e.Message);//사실 에러는 로그 남기는식으로..
                }

                Thread.Sleep(500);
            }

        }
    }
}
