using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2025_0225_과제2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //모험가 키우기
            Random rand = new Random();

            //멋사 4기는 능력이 사기다
            const int MAX_HEALTH = 100;
            int gold = 500;
            int health = MAX_HEALTH;
            int power = 10;
            int input;
            bool isAlive = true;

            Console.WriteLine("⚔️ 모험가 키우기 ⚔️");
            Thread.Sleep(1000);

            while (isAlive)
            {
                Console.Clear();
                Console.WriteLine($"체력 {health} | 골드 : {gold} | 공격력 : {power}");
                Console.WriteLine("\n1. 탐험하기 🏕️");
                Console.WriteLine("2. 장비 뽑기🎲 (1000골드)");
                Console.WriteLine("3. 휴식하기❤️ (체력 +=20)");
                Console.WriteLine("4. 종료하기🚪");
                Console.Write("입력 : ");
                
                input = int.Parse(Console.ReadLine());

                Thread.Sleep(1000);
                if (input == 1)
                {
                    string dot = ".";
                    string str = "모험을 떠납니다";

                    for (int i = 0; i < 5; i++)
                    {
                        Console.Clear();
                        Console.WriteLine(str);
                        Thread.Sleep(500);
                        str += dot;
                    }

                    int eventChance = rand.Next(1, 101);
                    if (eventChance <=30)//30퍼 확률로 전투 발생
                    {
                        int damage = rand.Next(5, 21);
                        health -= damage;
                        Console.WriteLine($"⚔️ 몬스터를 만났습니다! ⚔️");
                        Console.WriteLine("⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\r\n" +
                            "⠄⠄⠄⠄⠄⠄⢰⣷⡄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\r\n⠄⠄⠄⠄⣠⣾⣿⣿⣷⣦⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\r\n" +
                            "⠄⠄⠄⣠⣿⣿⣿⣿⣿⣿⣇⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄\r\n⠄⠄⠄⠄⠛⠿⣿⣿⣿⣿⣿⣆⠄⠄⠄⠄⠄⣴⣿⣿⣆⠄⠄⠄\r\n" +
                            "⠄⠄⠄⠄⠄⣰⣿⣿⣿⣿⣿⣿⣷⣄⠄⠄⠄⣿⣿⠛⠉⠄⠄⠄\r\n⠄⠄⠄⠄⠄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠄⠘⣿⡆⠄⠄⠄⠄\r\n" +
                            "⠄⠄⠄⠄⠄⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠸⣿⡀⠄⠄⠄\r\n⠄⠄⠄⠄⠄⠄⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠄⣿⡇⠄⠄⠄\r\n" +
                            "⠄⠄⠄⠄⠄⠄⢸⣿⡟⣿⣿⣿⣿⣿⣿⣿⣿⡇⢀⣿⠇⠄⠄⠄\r\n⠄⠄⠄⠄⠄⢀⣸⡿⢁⣘⣿⣿⣿⣿⣿⣿⣿⣇⣼⠋⠄⠄⠄⠄\r\n" +
                            "⠄⠄⠄⠄⠄⠻⠿⠓⠿⠿⠿⠿⠿⠿⠿⠿⠿⠛⠁⠄⠄⠄⠄⠄\r\n⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄");
                        Thread.Sleep(500);
                        Console.WriteLine($"몬스터가 {damage}의 피해를 입혔습니다!");
                        Thread.Sleep(500);
                        Console.WriteLine($"남은 체력 : {health}");
                    }//if eventChance 30
                    else if (eventChance<=70)//보상얻기
                    {
                        int reward = rand.Next(100, 301);
                        gold+=reward;

                        Console.WriteLine($"🎉 보물을 찾았습니다! 🎉");
                        Thread.Sleep(500);
                        Console.WriteLine($"보물을 획득하였습니다! 골드 + {reward}");
                        Thread.Sleep(500);
                        Console.WriteLine($"현재 골드 : {gold}");
                    }
                    else//체력회복
                    {
                        int heal = rand.Next(10, 31);
                        health = Math.Min(health + heal, MAX_HEALTH);

                        Console.WriteLine($"❤ 체력을 회복 했습니다. ❤️");
                        Thread.Sleep(500);
                        Console.WriteLine($"체력 + {heal}");
                        Thread.Sleep(500);
                        Console.WriteLine($"현재 체력 : {health}");
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("💀 사망하였습니다. 게임을 종료합니다. 💀");
                        isAlive = false;
                    }
                    Thread.Sleep(1000);
                }//if input == 1
                else if (input == 2)//장비 뽑기
                {
                    if (gold>= 1000)
                    {
                        gold -= 1000;
                        Console.Clear();
                        Console.WriteLine("🎲 장비를 뽑습니다. 🎲");
                        Thread.Sleep(1000);

                        int rnd = rand.Next(1, 101);
                        if (rnd==1)
                        {
                            Console.WriteLine("🌟 전설의 검(SSS) 🌟");
                            power += 50;
                        }
                        else if (rnd<=10)
                        {
                            Console.WriteLine("🌟 희귀한 검(SS) 🌟");
                            power += 30;
                        }
                        else if (rnd<=30)
                        {
                            Console.WriteLine("🌟 강철 검(S) 🌟");
                            power += 10;
                        }
                        else
                        {
                            Console.WriteLine("🌟 흔한 검(A) 🌟");
                            power += 5;
                        }
                    }// if (gold>= 1000)
                    else
                    {
                        Console.WriteLine("골드가 부족합니다.");
                    }
                    Thread.Sleep(1000);
                }//else if input == 2
                else if (input==3)//휴식하기
                {
                    health = Math.Min(health + 20, MAX_HEALTH);
                    Console.WriteLine("❤ 휴식을 취합니다.(+20 체력) ❤");
                    Thread.Sleep(1000);
                }//else if input == 3
                else if (input==4)//종료하기
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }//while(isAlive)
            
            Console.WriteLine("게임을 종료합니다. 감사합니다!");
        }
    }
}
