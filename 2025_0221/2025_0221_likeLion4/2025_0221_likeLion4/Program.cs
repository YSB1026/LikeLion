using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0221_likeLion4
{
    class Program
    {
        static void Main(string[] args)
        {
            //숫자 데이터 형식 : 정수와 실수를 다룰 때 사용하는 다양한 타입
            //int integerNum = 10;    //정수 데이터
            //float floatNum = 3.14f; //단정밀도 실수
            //double doubleNum = 3.14159;

            //Console.WriteLine(integerNum);
            //Console.WriteLine(floatNum);
            //Console.WriteLine(doubleNum);

            //정수 데이터 형식 : 소수점이 없는 숫자들 표현
            //long longVal = 123456790L;
            //float signlePrecision = 3.14159265358979323846f;
            //double doublePrecision = 3.14159265358979323846;
            //decimal decimalVal = 3.14159265358979323846m;

            //Console.WriteLine(longVal);
            //Console.WriteLine(signlePrecision);
            //Console.WriteLine(doublePrecision);
            //Console.WriteLine(decimalVal);

            ////char 단일 문자 형식
            //char charVal = 'A';//문자 'A'를 저장
            //char symbol = '@';//특수 기호 저장
            //char num = '7';//숫자 형태의 문자 저장
            //char hangul = '가';//char는 2byte unicode

            //Console.WriteLine(charVal);
            //Console.WriteLine(symbol);
            //Console.WriteLine(num);
            //Console.WriteLine(hangul);

            //string 문자열 형식 여러 문자를 저장
            //string str = "Hello, World";//문자열 저장
            //string name = "Alice";

            //Console.WriteLine(str);
            //Console.WriteLine(name);
            //Console.WriteLine(str + " " + name);

            //bool : true = 1, false = 0
            //bool isRunning = true;
            //bool isFinished = false;


            //const int MAX = 100;

            int num = 123;
            string numberAsString = num.ToString();

            bool b = true;
            string flagAsString = b.ToString();

            Console.WriteLine(numberAsString);
            Console.WriteLine(flagAsString);
        }
    }
}
