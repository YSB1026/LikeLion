using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0227_Inventory
{
    class Program
    {
        //최대 아이템 개수(배열크기)
        const int MAX_ITEMS = 100;
        //아이템 배열(이름 저장)
        static string[] itemsNames = new string[MAX_ITEMS];
        static int[] itemCounts = new int[MAX_ITEMS];

        //아이템 추가 함수
        static void AddItem(string name, int count)
        {
            for (int i = 0; i < MAX_ITEMS; i++)
            {
                if (itemsNames[i]==name)//이미 있는 아이템
                {
                    itemCounts[i] += count;
                    return;
                }
            }
            for(int i = 0;i < MAX_ITEMS; i++)
            {
                if (itemsNames[i] is null)
                {
                    itemsNames[i] = name;
                    itemCounts[i] = count;
                    return;
                }
            }

            Console.WriteLine("인벤토리 가득 참");
        }

        //아이템 제거 함수
        static void RemoveItem(string name, int count)
        {
            for (int i = 0; i<MAX_ITEMS; i++)
            {
                if (itemsNames[i]==name)
                {
                    if (itemCounts[i] < count)
                    {
                        Console.WriteLine("보유량 초과");
                        return;//보유 개수 보다 더 많은경우 return
                    }

                    itemCounts[i] -= count;
                    if (itemCounts[i] == 0) itemsNames[i] = null;

                    return;
                }
            }

            Console.WriteLine("아이템 찾을 수 없음");
        }

        static void ShowInventory()
        {
            Console.WriteLine("==현재 인벤토리==");
            for(int i=0; i<MAX_ITEMS;i++)
            {
                if (!string.IsNullOrEmpty(itemsNames[i]))//Null이나 빈 문자열이 아닌경우에만 출력
                    Console.WriteLine($"{itemsNames[i]} (x{itemCounts[i]})");
            }
        }
        
        static void Main(string[] args)
        {
            AddItem("포션", 5);
            AddItem("칼", 1);
            AddItem("포션", 3);

            ShowInventory();

            Console.WriteLine("포션 2개 사용");
            RemoveItem("포션", 9);
            ShowInventory() ;

            //테스트 : 없는 아이템 제거
            RemoveItem("방패", 1);
            ShowInventory();
        }
    }
}
