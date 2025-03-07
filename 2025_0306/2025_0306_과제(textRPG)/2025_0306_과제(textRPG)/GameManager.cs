using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0306_과제_textRPG_
{
    public class GameManager
    {
        Player player;
        Field field;

        public bool SetPlayer()
        {
            Console.WriteLine("직업 선택 (1.전사, 2.마법사)");
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                return false;
            }
            Console.Write(input);

            if(input ==1)
            {
                player = new Warrior();
                return true;
            }
            else if (input == 2)
            {
                player = new Mage();
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Progress()
        {
            while (true)
            {
                Console.Clear();
                if (!SetPlayer()) continue;
                break;
            }

            int input;
            while (true)
            {
                Console.Clear();
                player.Render();

                Console.WriteLine("=====================================================");
                Console.WriteLine("1. 사냥터 2.종료");
                input = int.Parse(Console.ReadLine());

                if (input==2)
                {
                    break;
                }
                else if (input == 1)
                {
                    if (field == null)
                    {
                        field = new Field(player);
                    }
                    field.FieldProgress();
                }
            }//while progress
        }
    }
}
