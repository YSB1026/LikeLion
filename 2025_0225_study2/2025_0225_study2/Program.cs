using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace _2025_0225_study2
{
    class Program
    {
        //메모리 영역
        //스택
        //힙
        //코드
        //데이터(정적 메모리)
        //static int count = 0;
        //int instan = 200;

        //함수!
        
        static void Loading()
        {
            Console.WriteLine("로딩 화면!");
        }

        //parameter!
        static void AttackFunc(int _attack)
        {
            Console.WriteLine($"Attack {_attack}");
        }

        static int BaseAttack()
        {
            int attack = 10;
            return attack;
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            //int instan = 10;
            //count++;
            //Console.WriteLine(instan);
            //Console.WriteLine(count);

            #region 함수

            //Loading();

            //int attack = 0;
            //Console.Write("케릭터의 공격력을 입력 :");
            //attack = int.Parse(Console.ReadLine());
            //AttackFunc(attack);
            
            //int bAttack = 0;
            //bAttack = BaseAttack();

            //AttackFunc(attack+bAttack);

            int result = Add(10, 20);
            Console.WriteLine($"10 + 20 = {result}");
            #endregion
        }
    }
}
