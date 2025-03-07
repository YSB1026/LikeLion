using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_textRPG
{
    public class MainGame
    {
        Player player = null;
        //필드 객체
        Feild feild = null;

        //초기화 해주는 함수
        public void Initialize()
        {
            player = new Player();
            player.SelectJob();
        }
        
        public void Progress()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear();
                player.Render();
                Console.WriteLine("1.사냥터 2.종료 : ");
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 2) break;
                else if (iInput==1)
                {
                    //사냥터 구현
                    if (feild == null)
                    {
                        feild = new Feild();
                        feild.SetPlayer(ref player);
                    }

                    feild.Progress();
                }
            }
        }
    }
}
