using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0304_study3
{
    class Cup<T>
    {
        public T Content { get; set; }

        public override string ToString()
        {
            return Content.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            #region 배열과 컬랙션
            //int[] numbewrs = { 1, 2, 3, 4, 5 };

            //foreach (var num in numbewrs)
            //{
            //    Console.WriteLine(num);
            //}

            //컬렉션
            //제네릭 / 비제네릭
            //List 제네릭 컬렉션
            //List<string> names = new List<string>(){ "Alice", "Bob", "Charlie"};
            //names.Add("Dave");
            //names.Remove("Bob");
            //names.Insert(1, "Kevin");
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //Console.WriteLine(names.Count);

            //Stack LIFO구조 Last In First Out
            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);

            //while(stack.Count > 0) {
            //    Console.WriteLine(stack.Pop());
            //}

            //Console.WriteLine("스택의 크기 : " + stack.Count);

            //queue
            //Queue queue = new Queue();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);

            //while (queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}

            //Queue queue = new Queue();
            //queue.Enqueue("Q");
            //queue.Enqueue("W");
            //queue.Enqueue("E");
            //queue.Enqueue("R");
            //queue.Enqueue("점멸");
            //queue.Enqueue("평타");

            //while (queue.Count > 0)
            //{
            //    Console.WriteLine(queue.Dequeue());
            //}

            //Console.WriteLine(queue.Count);

            //ArrayList
            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(1);
            //arrayList.Add("Hello");
            //arrayList.Add(3.14);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            //arrayList.Remove(1);

            //Console.WriteLine("\n제거 후\n");
            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            //Hash table 클래스
            //키 - 값 쌍을 저장하는 컬렉션
            //키를 이용해 값을 빠르게 탐색
            //Hashtable hashtable = new Hashtable();
            //hashtable["Alice"] = 25;
            //hashtable["Bob"] = 30;
            //hashtable["포션"] = 20;

            //Console.WriteLine("HashTable 요소");
            //foreach (DictionaryEntry entry in hashtable)
            //{
            //    Console.WriteLine(entry.Key + " " + entry.Value);
            //}
            #endregion

            #region 제네릭사용
            //Cup<string> cup = new Cup<string> { Content = "Coffee" };
            //Cup<int> cup2 = new Cup<int> { Content = 2 };
            //Console.WriteLine(cup);
            //Console.WriteLine(cup2);

            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //Console.WriteLine(stack.Pop());

            //List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
            //names.Add("Dave");


            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}
            #endregion

            #region IEnumerator

            //IEnumerator
            //C#컬렉션 순회 반복할 수 있는 인터페이스
            //IEnumerator를 사용하는 이유
            //✔ 컬렉션을 직접 제어하며 순회할 수 있음
            //✔ foreach 없이도 컬렉션 순회 가능
            //✔ LINQ나 커스텀 컬렉션을 만들 때 유용함
            //ArrayList list = new ArrayList() { "Apple", "Banana", "Cherry" };
            //IEnumerator enumerator = list.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}

            //SimpleConllection simpleConllection = new SimpleConllection();
            //foreach (var item in simpleConllection)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Dictionary
            //Dictionary<string, int> dic = new Dictionary<string, int>();
            //dic["금도끼"] = 10;
            //dic["은도끼"] = 5;

            //foreach(var item in dic)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}
            #endregion

            //null값
            //참조형식만 null을 가질 수 있음
            //string str = null;

            //int? nullableInt = null;
            //Console.WriteLine(nullableInt.HasValue ? nullableInt.Value.ToString() : "No value");

            //null값 판별
            //?? 연산자를 사용해 null인 경우 대체값을 제공하고, ?.은 null안전 접근
            //string str = null;
            //Console.WriteLine(str ?? "Default");
            //Console.WriteLine(str?.Length);


            //LinQ 람다식
            //int[] number = { 1, 2, 3, 4 };
            ////bool isEvent(int n) { return n%2==0; }
            //var evenNum = number.Where(n=> n%2==0);

            //foreach (var n in evenNum)
            //{
            //    Console.WriteLine(n);
            //}
        }

        class SimpleConllection : IEnumerable<int>
        {
            public int[] data = { 1, 2, 3, 4, 5, 6, 7, 8 };

            public IEnumerator<int> GetEnumerator()
            {
                foreach(var item in data)
                {
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
