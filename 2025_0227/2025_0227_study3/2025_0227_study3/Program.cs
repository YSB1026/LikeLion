using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0227_study3
{
    struct Point
    {
        //public 어디서든 사용 가능
        //private 외부에서 사용 X
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Print()
        {
            Console.WriteLine($"좌표 {x}, {y}");
        }
    }

    struct Rectangle
    {
        public int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int GetArea() => width * height;
    }

    struct Student
    {
        string name;
        int kor, eng, math;
        public string Name { get { return name; } set { name = value; } }
        public int Kor { get { return kor; } set { kor = value; } }
        public int Eng { get { return Eng; } set { eng = value; } }
        public int Math { get { return Math; } set { math = value; } }

        public void Print()
        {
            Console.WriteLine($"{name}\t{kor,3}\t{eng,3}\t{math,3}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region 구조체
            //C# 구조체
            //클래스와 비슷하지만, 값 타입(Value Type)이며 가볍고 빠름
            //주로 간단한 데이터 묶음을 만들 때 사용
            //Point point;
            //point.x = -1; point.y = -1;
            //point.Print();

            ////구조체도 생성자 사용가능
            ////모든 필드 
            //Point p = new Point(10,20);
            //p.Print();

            //var rect = new Rectangle(width: 50, height: 30);
            //Console.WriteLine($"사각형 넓이 : {rect.GetArea()}");

            //Point[] points = new Point[2];
            //points[0] = new Point(10, 20);
            //points[1] = new Point(-1, 5);

            //foreach (Point p in points)
            //{
            //    p.Print();
            //}

            //구조체를 이용해서
            //학생 3명의 성적을 받고 국어,영어,수학
            //출력
            //이름
            Student[] students = new Student[3];
            Console.WriteLine("학생 3명의 이름 성적 입력");
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Student {i+1}");
                students[i] = new Student();
                Console.Write(" 이름 ");
                students[i].Name = Console.ReadLine();
                Console.Write(" 국어 ");
                students[i].Kor = int.Parse(Console.ReadLine());
                Console.Write(" 영어 ");
                students[i].Eng = int.Parse(Console.ReadLine());
                Console.Write(" 수학 ");
                students[i].Math = int.Parse(Console.ReadLine());
            }


            Console.WriteLine(" 이름\t국어\t영어\t수학");
            foreach (Student student in students)
            {
                student.Print();
            }
            #endregion


        }
    }
}
