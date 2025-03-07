using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0306_textRPG
{
    public class Player
    {
        public Info m_tInfo;

        public void SetDamage(int iAttack) { m_tInfo.iHp -= iAttack; }
        public Info GetInfo() { return m_tInfo; }
        public void SetHp(int iHp) { m_tInfo.iHp = iHp; }

        //직업 선택
        public void SelectJob()
        {
            m_tInfo = new Info();

            Console.WriteLine("직업 선택 (1.기사 2.마법사 3.도둑)");

            int input = 0;

            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    m_tInfo.strName = "기사";
                    m_tInfo.iHp = 100;
                    m_tInfo.iAttack = 10;
                    break;
                case 2:
                    m_tInfo.strName = "마법사";
                    m_tInfo.iHp = 90;
                    m_tInfo.iAttack = 15;
                    break;
                case 3:
                    m_tInfo.strName = "도둑";
                    m_tInfo.iHp = 85;
                    m_tInfo.iAttack = 18;
                    break;
            }
        }//SelectJob

        public void Render()
        {
            Console.WriteLine("==================");
            Console.WriteLine("직업 이름 : " + m_tInfo.strName);
            Console.WriteLine("체력 : " + m_tInfo.iHp + "\t공격력 : " + m_tInfo.iAttack);
        }

        public Player() { }
        ~Player() { }
    }
}
