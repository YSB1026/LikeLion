using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0307_텍스트RPG시험
{
    public class Field
    {
        Player player; //GameManager의 player참조
        Monster monster;
        public Field(Player player)
        {
            this.player=player;
        }

        public void Process()
        {
            int input = 0;
            while (true)
            {
                Console.Clear();
                player.Render();
                Console.WriteLine("1. Easy 사냥터");
                Console.WriteLine("2. Normal 사냥터");
                Console.WriteLine("3. Hard 사냥터");
                Console.WriteLine("4. 나가기");
                input = Program.PlayerInput();

                if (input ==1||input==2||input==3)
                {
                    EnterField(in input);
                }
                else if (input == 4)
                {
                    break;
                }
            }
        }

        private void EnterField(in int input)
        {
            int input1;
            while (true)
            {
                Console.Clear();
                CreateMonster(in input);
                player.Render();
                monster.Render();
                Console.WriteLine("1.싸운다 2.나가기");

                input1 = Program.PlayerInput();
                if (input1==1) 
                    Fight();
                else if (input1==2) break;
                //else
                //{
                //    Console.WriteLine("잘못된 선택");
                //}

                if (player.Health<=0)
                {
                    player.Revive();
                    break;
                }
                else if (monster.Health<=0)
                {
                    monster = null;
                    break;
                }
            }
        }

        private void CreateMonster(in int input)
        {
            if (monster != null) return;
            switch (input)
            {
                case 1:
                    monster = new Monster("쉬운 몹", health: 50, atk: 20, dfs: 5);
                    break;
                case 2:
                    monster = new Monster("중간 몹", health: 70, atk: 25, dfs: 7);
                    break;
                case 3:
                    monster = new Monster("어려운 몹", health: 100, atk: 30, dfs: 10);
                    break;
            }
        }

        private void Fight()
        {
            Console.WriteLine("");
            player.Attack(monster);
            Console.WriteLine("");
            monster.Attack(player);
            //Console.WriteLine("------" + monster.Health);
            Thread.Sleep(500);
        }
    }
}
