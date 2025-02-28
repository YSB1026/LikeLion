using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0228_study2
{
    class Person
    {
        private int count = 100;
        public string Name { get; set; } //자동 구현 프로퍼티
        public int Count
        {
            get { return count; } //읽기만 가능
        }

        public float Balance { get; private set; } //외부 변경 불가

        public void AddBal()
        {
            Balance += 100;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //C#에서 get/set 방식의 함수와 프로퍼티 비교
            //C#에서는 객체의 값을 읽고(get), 설정(set)하는
            //방식으로 함수(get/set 메서드) 또는
            //**프로퍼티(Property)**를 사용할 수 있습니다.

            Person p = new Person();
            p.Name = "홍길동";
            p.AddBal();
            Console.WriteLine("이름 : " + p.Name+"Count : "+ p.Count +"Balance "+p.Balance);
        }
    }
}
