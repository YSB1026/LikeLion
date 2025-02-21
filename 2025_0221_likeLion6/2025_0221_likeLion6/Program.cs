using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0221_likeLion6
{
    class Program
    {
        static void Main(string[] args)
        {
            ////사용자 입력 받기
            //Console.WriteLine("이름을 입력하세요 : ");
            //string userName = Console.ReadLine();//사용자로부터 입력 받기

            //Console.WriteLine($"안녕하세요 {userName} 님");

            //문자열 변환
            //Console.WriteLine("나이를 입력하세요 : ");
            //string input = Console.ReadLine();
            //int age = int.Parse(input);
            //Console.WriteLine($"내년에는 {age + 1}세 입니다.");


            //루인 스킬 피해 : 4.5% <- 입력받기
            Console.WriteLine("루인 스킬 피해량을 입력하세요 : ");
            string input1 = Console.ReadLine();
            float skill_dmg = float.Parse(input1);

            Console.WriteLine("카드 게이지 획득량을 입력 하세요 : ");
            string input2 = Console.ReadLine();
            float card_gauge = float.Parse(input2);

            Console.WriteLine("각성기 피해를 입력하세요 : ");
            string input3 = Console.ReadLine();
            float ult_dmg = float.Parse(input3);

            Console.WriteLine("최대 마나를 입력하세요 : ");
            string input4 = Console.ReadLine();
            int max_mana = int.Parse(input4);

            Console.WriteLine("전투 중 마나 회복량을 입력하세요 : ");
            string input5 = Console.ReadLine();
            int battle_mana = int.Parse(input5);

            Console.WriteLine("비전투 중 마나 회복량을 입력하세요 : ");
            string input6 = Console.ReadLine();

            Console.WriteLine("이동속도를 입력하세요 : ");
            string input7 = Console.ReadLine();

            Console.WriteLine("탈 것 속도를 입력하세요 : ");
            string input8 = Console.ReadLine();

            Console.WriteLine("운반속도를 입력하세요 : ");
            string input9 = Console.ReadLine();

            Console.WriteLine("스킬 재사용 대기시감 감소를 입력하세요 : ");
            string input10 = Console.ReadLine();

            Console.WriteLine("======================================");
            Console.WriteLine($"루인 스킬 피해 : {skill_dmg}%");
            Console.WriteLine($"카드 게이지 획득량 : {card_gauge}%");
            Console.WriteLine($"각성기 피해 : {ult_dmg}%");
            Console.WriteLine($"최대 마나 : {max_mana}");
            Console.WriteLine($"전투 중 마나 회복량 : {battle_mana}");
            Console.WriteLine($"비전투 중 마나 회복량 : {input6}");
            Console.WriteLine($"이동속도 : {input7}%");
            Console.WriteLine($"탈 것 속도 : {input8}%");
            Console.WriteLine($"운반속도 : {input9}%");
            Console.WriteLine($"스킬 재사용 대기시간 감소 : {input10}%");
            Console.WriteLine("======================================");
        }
    }
}