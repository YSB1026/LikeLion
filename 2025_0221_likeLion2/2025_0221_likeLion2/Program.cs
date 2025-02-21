using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0221_likeLion2
{
    class Program
    {
        static void Main(string[] args)
        {
            //변수선언
            //int age = 26;//정수형

            //Console.WriteLine(age);

            ////리터럴(literal) - 정수,문자,문자열 등등 코드에서 직접 적은 값(10,3.14...등등)
            //int num = 10; //정수형 리터럴
            //double pi = 3.14;//실수형 리터럴
            //char c = 'c';//문자 리터럴
            //string str = "test"; //문자열 리터럴

            //Console.WriteLine(num);
            //Console.WriteLine(pi);
            //Console.WriteLine(c);
            //Console.WriteLine(str);

            //캐릭터
            //hp : 100
            //att : 56.7
            //캐릭터 이름 : 
            //등급 : S

            int hp = 100;
            double att = 56.7;
            string name = "커비";
            char rank = 'S';

            Console.WriteLine($"hp : {hp}");
            Console.WriteLine($"att : {att}");
            Console.WriteLine($"캐릭터 이름 : {name}");
            Console.WriteLine($"등급 : {rank}");
        }
    }
}
