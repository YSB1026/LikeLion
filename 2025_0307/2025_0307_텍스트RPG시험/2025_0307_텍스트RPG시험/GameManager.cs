using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2025_0307_텍스트RPG시험
{
    public class GameManager
    {
        public Player player = null;
        public Field field = null;

        void SetPlayer()
        {
            int input;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("직업을 선택하세요 (1. 전사 2. 마법사)");
                int.TryParse(Console.ReadLine(), out input);
                if (input == 0)
                {
                    Console.WriteLine("잘못된 선택");
                }
                else if (input == 1)
                {
                    player = new Warrior();
                    break;
                }
                else if (input == 2)
                {
                    player = new Mage();
                    break;
                }
                else
                {
                    Console.WriteLine("전사 또는 마법사만 선택 가능");
                }
                Thread.Sleep(500);
            }
        }

        public void Process()
        {
            SetPlayer();

            int input = 0;
            while (true)
            {
                Console.Clear();
                player.Render();
                Console.WriteLine("1.사냥 2.종료");
                input = Program.PlayerInput();// 비정상적인 입력을 하면 -1을리턴
                //오늘 배운 델리게이트, 이벤트 이런거 쓰면 좋을거같기도..
                if(input == 1)
                {
                    field = new Field(player);
                    field.Process();
                }
                else if(input == 2)
                {
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("감사합니다!");
        }
    }
}
