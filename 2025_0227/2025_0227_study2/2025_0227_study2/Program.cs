using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0227_study2
{
    enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }

    enum StatusCod
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        NotFound = 404
    }

    enum WeaponType
    {
        Sword,
        Bow,
        Staff,
    }

    class Program
    {
        //일반적인 함수
        //static int Add()같은 경우
        static int AddArrow(int param1, int param2) => param1 + param2;

        //일반적인 함수
        static void PrintMessage()
        {
            Console.WriteLine("HEllO");
        }
        static void PrintMsg() => Console.WriteLine("HELLO!");

        static void ChooseWeapon(WeaponType weaponType)
        {
            string[] weapons = { "검", "활", "스태프" };
            string type = weapons[(int)weaponType];

            Console.WriteLine($"{type}을 선택 하셨습니다.");
        }

        static void Main(string[] args)
        {
            #region 람다식(람다 함수)
            //화살표 함수!
            //c# 화살표 함수 -> lambda 표현식
            //간결한 방식으로 함수를 정의
            //중괄호 및 return 생략가능

            //Console.WriteLine($"{AddArrow(1,2)}");

            //PrintMsg();

            #endregion

            #region Math 클래스
            ////Math 클래스
            ////수학 계산
            //Console.WriteLine($"PI : {Math.PI}");//원주율
            //Console.WriteLine($"Square root fo 25 : {Math.Sqrt(25)}");//제곱근
            //Console.WriteLine($"Power (2^3) : {Math.Pow(2, 3)}"); //제곱
            //Console.WriteLine($"Round(3.65) : {Math.Round(3.65)}");//반올림!

            #endregion

            #region 열거형(Enum)
            //c#에서 enum은 그냥 변수명 그대로 출력된다.
            //Enum은 default는 0으로 시작되지만 설정해줄수 있다.
            //DayOfWeek day = DayOfWeek.Sunday;
            //Console.WriteLine(day);
            //if (day==DayOfWeek.Sunday)
            //{
            //    Console.WriteLine(day + "입니다");
            //}

            //StatusCod statusCod = StatusCod.Success;
            //Console.WriteLine(statusCod);
            //Console.WriteLine((int)statusCod);


            //문제
            //열거형과 함수를 이용해서 풀어주세요.
            //WeaponType.Sword 검을 선택
            //Bow 활을선택
            //Staff 스태프 선택
            //ChooseWeapon(WeaponType.Bow);//출력 : 활을 선택했습니다.

            ChooseWeapon(WeaponType.Sword);
            ChooseWeapon(WeaponType.Bow);
            ChooseWeapon(WeaponType.Staff);


            #endregion
        }
    }
}
