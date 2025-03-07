using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_textRPG
{
    public class Feild
    {
        Player player = null;
        //몬스터
        Monster monster = null;
        public void SetPlayer(ref Player player)
        {
            this.player = player;
        }

        public void Progress()
        {
            //사냥터로 들어옴.
            int iInput = 0;

            while (true)
            {
                DrawMap();
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 4) break;
                else if (iInput <= 3)
                {
                    CreateMonster(iInput);

                    Fight();
                }
            }
        }

        public void Create(string _stringName, int _iHp, int _iAttack, out Monster monster)
        {
            monster = new Monster();
            Info tMonster = new Info();
            tMonster.strName = _stringName;
            tMonster.iHp = _iHp;
            tMonster.iAttack = _iAttack;

            monster.SetMonster(tMonster);
        }

        public void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    //공장처럼 찍어내 줌
                    //디자인패턴 팩토리 메서드 패턴
                    Create("모코코 몹", 30, 2, out monster);
                    break;
                case 2:
                    //공장처럼 찍어내 줌
                    //디자인패턴 팩토리 메서드 패턴
                    Create("할만한 몹", 40, 4, out monster);
                    break;
                case 3:
                    //공장처럼 찍어내 줌
                    //디자인패턴 팩토리 메서드 패턴
                    Create("고인물 몹", 60, 7, out monster);
                    break;
            }
        }

        public void Fight()
        {
            int iInput = 0;
            while (true)
            {
                Console.Clear();
                player.Render();
                monster.Render();

                Console.WriteLine("1. 공격 2.도망");
                iInput = int.Parse(Console.ReadLine());
                if (iInput == 1)
                {
                    //플레이어가 몬스터에게 맞음
                    player.SetDamage(monster.GetMonster().iAttack);
                    //몬스터에게 데미지를 줌
                    monster.SetDamage(player.GetInfo().iAttack);

                    if(player.GetInfo().iHp <=0)//플레이어 사망 시
                    {
                        player.SetHp(100);
                        break;
                    }
                }
                if(iInput == 2 || monster.GetMonster().iHp<=0) 
                {
                    monster = null;
                    break;
                }
            }
        }

        private void DrawMap()
        {
            Console.Clear();
            player.Render();
            Console.WriteLine("1. 모코코");
            Console.WriteLine("2. 할만함");
            Console.WriteLine("3. 고인물");
            Console.WriteLine("4. 나가기");
            Console.WriteLine("===========");
            Console.Write("맵을 선택하세요 : ");
        }
    }
}
