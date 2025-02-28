using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0228_study1
{
    //마린 클래스를 만드세요.
    //이름, 미네랄
    //기본 생성자, 인자있는 생성자

    class Marin
    {
        public int Mineral { get; set; }
        public string Name { get; }
        Marin()
        {
            Mineral = 50;
            Name = "마린";
        }
        Marin(int mineral, string name)
        {
            Mineral=mineral;
            Name=name;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Mineral + " " + Name);
        }
    }

    class SCV
    {
        public int Mineral { get; set; }
        public string Name { get; }
        SCV()
        {
            Mineral = 50;
            Name = "SCV";
        }
        SCV(int mineral, string name)
        {
            Mineral=mineral;
            Name=name;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Mineral + " " + Name);
        }
    }
    class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        //기본생성자
        //클래스가 객체로 생성될 때 자동으로 실행되는 메소드
        //클래스와 같은 이름, 반환형이 없음
        //객체를 만들 때 필요한 초기값 할당

        public Person(string name = "이름 없어용", int age = 0)
        {
            Name = name;
            Age = age;
            Console.WriteLine("오호홍 실행");
        }
    
        public void ShowInfo()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("나이 : " + Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region 시간 관련 클래스
            ////시간 관련 클래스들
            //DateTime now = DateTime.Now;
            //Console.WriteLine($"Current Date and Time : {now}");

            //TimeSpan duration = new TimeSpan(1, 30, 0);//1시간 30분
            //Console.WriteLine($"Duration : {duration}");
            #endregion

            Person person = new Person();
            person.ShowInfo();
        }
    }
}
