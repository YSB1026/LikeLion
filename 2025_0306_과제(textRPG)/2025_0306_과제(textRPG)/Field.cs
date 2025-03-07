using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0306_과제_textRPG_
{
    public class Field
    {
        Player player;
        Enemy enemy;
        public Field(Player player) { 
            this.player = player;
        }
        public void FieldProgress()
        {
            int input;
            while (true)
            {
                DrawMap();
                input = int.Parse(Console.ReadLine());
                if (input==4)
                {
                    break;
                }
                else if (input<=3)
                {
                    CreateMonster(input);
                    Fight();
                }
            }
        }
        private void Create(string enemyName, int health, int atk, int dfs, out Enemy enemy)
        {
            enemy = new Enemy(name : enemyName, health:health, atk:atk, dfs:dfs);
        }
        private void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    Create(enemyName:"모코코 몹", health:50, atk:20, dfs:5, out enemy);
                    break;
                case 2:
                    Create(enemyName:"할만한 몹", health:100, atk:25, dfs:6, out enemy);
                    break;
                case 3:
                    Create(enemyName:"고인물 몹", health:200, atk:40, dfs:10, out enemy);
                    break;
            }
        }

        private void Fight()
        {
            int input = 0;
            while (true)
            {
                Console.Clear();
                player.Render();
                Console.WriteLine("====================================================");
                enemy.Render();
                Console.WriteLine("====================================================");
                Console.WriteLine("1. 도망 2.일반 공격, 3.스킬사용");
                input = int.Parse(Console.ReadLine());


                if (input == 1)
                {
                    enemy = null;
                    break;
                }
                else if (input == 2)
                {
                    player.Attack(enemy);
                    enemy.Attack(player);
                }
                else if(input==3)
                {
                    int input2;
                    Console.WriteLine("=====================================================");
                    Console.Write("사용할 스킬 : ");
                    input2 = int.Parse(Console.ReadLine());
                    player.UseSkill(enemy, input2);
                    enemy.Attack(player);
                }

                if (player.Health <=0)//플레이어 사망 시
                {
                    player.Health = 100;
                    enemy = null;
                    break;
                }
                else if (enemy.Health<=0)//몬스터 사망 시
                {
                    enemy = null;
                    break;
                }
                Thread.Sleep(1000);
            }
        }

        private void DrawMap()
        {
            Console.Clear();
            player.Render();
            Console.WriteLine("=====================================================");
            Console.WriteLine("1. 모코코 난이도");
            Console.WriteLine("2. 중간 난이도");
            Console.WriteLine("3. 고인물 난이도");
            Console.WriteLine("4. 나가기");
            Console.Write("맵을 선택 하세요 :");
        }
    }
}
