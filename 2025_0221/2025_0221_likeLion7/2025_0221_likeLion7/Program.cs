using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0221_likeLion7
{
    class Program
    {
        static void Main()
        {
            //로딩바 시작화면
            //게임 스토리 1
            int totalBlocks = 12; 
            char emptyBlock = '□';
            char filledBlock = '■';

            for (int i = 0; i <= totalBlocks; i += 2) 
            {
                Console.Clear();
                string loadingBar = new string(filledBlock, i) + new string(emptyBlock, totalBlocks - i);
                Console.WriteLine("  Loading..");
                Console.WriteLine(loadingBar);
                Thread.Sleep(1000); 
            }

            Console.WriteLine("엔터를 누르면 시작!");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            Console.Clear();

            string[] story = {
                "당신은 작은 마을에 살고 있는 젊은 마법사입니다.",
                "어느 날, 숲의 깊은 곳에서 오래된 돌을 발견하게 됩니다.",
                "이 돌은 마법의 기운을 잃은 듯 보이지만, 여전히 미묘한 힘을 품고 있는 것 같습니다.",
                "마을로 돌아가 장로님께 이 돌에 대해 물었고, 장로님은 그 돌이 숲의 생명력과 밀접하게 연결되어 있다고 말합니다.",
                "장로님은 당신에게 그 돌을 되살려 숲의 평화를 회복할 임무를 맡깁니다.",
                "당신은 숲을 지나며 다양한 생명체들과 교감을 나누고, 그들의 도움을 받으며 여정을 이어갑니다.",
                "여정 중, 숲의 깊은 곳에서 잃어버린 빛의 조각들을 찾아야 한다는 사실을 알게 됩니다.",
                "그리고 마침내, 빛의 조각들을 모았지만...",
                "숲을 되살리는 열쇠는 바로 볼드모트를 처치하는 것임을 깨닫게 됩니다.",
                "당신은 더욱 깊은 숲 속으로 들어가, 볼드모트와의 마지막 결전을 준비합니다.",
                "돌이 갑자기 강렬하게 빛을 발하며, 거대한 마법의 폭발이 일어납니다!",
                "폭발로 숲은 되살아났지만, 동시에 당신의 숙적 볼드모트는 마법에 휘말려 사라지게 됩니다.",
                "볼드모트는 사라졌으며, 당신은 평화로운 마을로 돌아옵니다.",
                "하지만... 그 돌은 다시 빛을 잃고, 당신은 그저 '하나의 돌'만 얻게 되는 엔딩..."
            };


            foreach (string line in story)
            {
                Console.Clear();
                Console.WriteLine(line);
                Thread.Sleep(3000);
            }
        }
    }
}
