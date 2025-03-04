using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2025_0304_study1
{
    #region 클래스 시그니처
    //C#에서 클래스 시그니처는 클래스의 선언부
    //[접근 지정자] [수정자 (abstact, sealed, static, partial)] class이름 : 부모클래스 : 인터페이스

    //기본클래스
    //public class Player
    //{
    //    public string Name { get; set; }
    //    public int Score { get; set; }
    //}

    //public class Warrior : Player //상속하는 클래스
    //{
    //    public int Strength { get; set; }
    //}

    //인터페이스를 구현하는 클래스
    //public class Enemy: IAttackable, IMovable
    //{
    //    public void Attack() { }
    //    public void Move() { }

    //}
    //추상 클래스 (abstract)
    //public abstract class Animal
    //{
    //    public abstract void MakeSound();
    //}
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region Environment
            //Console.WriteLine("Exiting the program");
            //Environment.Exit(0);

            //string[] path = Environment.GetEnvironmentVariable("PATH").Split(';');
            //foreach(var p in path) {
            //    Console.WriteLine(p);
            //}
            #endregion

            #region Random
            Random rnd = new Random();
            int rndNum = rnd.Next(1, 101);
            Console.WriteLine(rndNum);
            #endregion

            #region 프로그램 실행 시간 구하기
            //Stopwatch sw = Stopwatch.StartNew();
            //for (int i = 0; i<int.MaxValue; i++)
            //{
            //}
            //Console.WriteLine("for 시간 :" + sw.ElapsedMilliseconds);
            #endregion

            #region 정규식
            //string input = "Hello, my phone number is 010-1234-5678.";
            //string pattern = @"\d{3}-\d{4}-\d{4}";

            //bool isMatch = Regex.IsMatch(input, pattern);
            //Console.WriteLine(isMatch);
            #endregion
        }
    }
}