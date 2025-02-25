using System;
using System.Runtime.InteropServices;

namespace _2025_0224_study1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ~10시 40분
            //binary number
            //string binaryInput = Console.ReadLine();
            //int decVal = Convert.ToInt32(binaryInput, 2);//2진수 10진수 변환

            //string binaryOutput = Convert.ToString(decVal, 2);//10진수 2진수 변환

            //Console.WriteLine($"입력한 2진수 {binaryOutput}");
            //Console.WriteLine($"10 진수 : {decVal}");

            //var 변수
            //var name = "Alice";
            //var age = 20;
            //var isStudent = true;

            //Console.WriteLine($"name : {name}, age : {age}, 학생여부 : {isStudent}");

            //default
            //int defaultInt = default;//0
            //double defaultDouble = default;
            //string defaultString = default;//null
            //bool defaultBool = default;//false

            //Console.WriteLine($"defaultInt : {defaultInt}");
            //Console.WriteLine($"defaultDouble : {defaultDouble}");
            //Console.WriteLine($"defaultString : {defaultString}");
            //Console.WriteLine($"defaultBool : {defaultBool}");

            //연산자
            //int a = 5, b = 3;

            //int sum = 0;
            //sum = a + b;

            //int mul = 0;
            //mul = a*b;

            //int div = 0;
            //div = a/b;

            //int minus = 0;
            //minus = a - b;

            //int mod = 0;
            //mod = a % b;

            //Console.WriteLine($"a + b = {sum}");
            //Console.WriteLine($"a * b = {mul}");
            //Console.WriteLine($"a / b = {div}");
            //Console.WriteLine($"a - b = {minus}");
            //Console.WriteLine($"a % b = {mod}");

            //bool isEqual = false;

            //int a = 5;
            //int b = 5;
            //isEqual = a == b;

            //Console.WriteLine($"a == b : {isEqual}");
            #endregion

            #region 10시 40분~12시

            //단항 연산
            //int number = 5;
            //bool flag = true;

            //Console.WriteLine(+number);
            //Console.WriteLine(-number);
            //Console.WriteLine(!flag);

            //비트 연산
            //dec : 10, bin : 1010

            //int num = 10;
            //int reuslt = ~num;
            //Console.WriteLine(reuslt);

            //캐스팅
            //double pi = 3.14;
            //int integerPi = (int)pi;
            //Console.WriteLine(integerPi);

            //int iKor = 90;
            //int iEng = 75;
            //int iMath = 76;

            //int sum = iKor + iEng + iMath;
            //float avg = 0.0f;
            //avg = (float)sum/3;

            //Console.WriteLine(sum);
            //Console.WriteLine(avg);


            //string firstName = "Alice";
            //string lastName = "Smith";

            //Console.WriteLine($"{firstName} {lastName}");

            //int a = 10;
            //a+=5;
            //Console.WriteLine(a);
            //a-=5;
            //Console.WriteLine(a);
            //a*=5;
            //Console.WriteLine(a);
            //a/=5;
            //Console.WriteLine(a);
            //a*=5;
            //Console.WriteLine(a);
            //a%=5;
            //Console.WriteLine(a);

            /*문제 1. 학점 평균 계산 프로그램
            설명:
            국어, 영어, 수학 점수를 사용자로부터 입력받아 총점과 평균을 구하는 프로그램을 작성하세요.
            요구사항:

            각 과목의 점수는 정수형으로 입력받습니다.
            총점을 구한 후, 평균을 계산할 때 정수형 총점을 실수형으로 캐스팅하여 소수점까지 정확하게 계산합니다.
            평균은 소수점 둘째 자리까지 출력하세요.
            */
            //Console.WriteLine("문제 1 ");
            //int kor, eng, math, sum = 0;
            //float avg = 0.0f;

            //Console.Write("국어 점수 입력 : ");
            //kor = int.Parse(Console.ReadLine());
            //Console.Write("영어 점수 입력 : ");
            //eng = int.Parse(Console.ReadLine());
            //Console.Write("수학 점수 입력 : ");
            //math = int.Parse(Console.ReadLine());

            //sum = kor + eng + math;
            //avg = (float)sum/3;
            //Console.WriteLine($"총점 : {sum}, 평균 {avg:F2}");

            ///*
            //문제 2.비트 반전(~) 연산자 활용 프로그램
            //설명:
            //사용자로부터 정수를 입력받아, 해당 정수의 모든 비트를 반전(~)한 결과를 출력하는 프로그램을 작성하세요.
            //요구사항:

            //정수를 입력받습니다.
            //비트 반전 연산자(~)를 이용하여 입력된 정수의 비트를 반전합니다.
            //원래의 값과 비트 반전 후의 값을 함께 출력합니다.
            //*/

            //Console.WriteLine("\n문제 2 ");
            ////int num = int.Parse(Console.ReadLine());
            //Console.WriteLine(~int.Parse(Console.ReadLine()));

            #endregion

            #region 1시~2시

            //증감 연산자
            //int b = 3;
            ////전위
            //Console.WriteLine(++b);
            ////후위
            //Console.WriteLine(b++);
            //Console.WriteLine(b);

            //비교 연산자

            //int x = 5, y = 10;
            //Console.WriteLine(x < y);//true
            //Console.WriteLine(x==y);//false
            //Console.WriteLine(x!=y);//true
            //Console.WriteLine(x>=y);//false
            //Console.WriteLine(x<=y);//true

            //논리 연산

            //bool a = true, b = false;
            //Console.WriteLine(a && b);//false
            //Console.WriteLine(a || b);//true
            //b= !a;
            //Console.WriteLine(b);


            #endregion

            #region 2시~3시
            ////비트연산
            //int x = 5;//0101
            //int y = 3;//0011

            //Console.WriteLine(x & y);//0001 -> 1, and
            //Console.WriteLine(x | y);//0111 -> 7, or
            //Console.WriteLine(x ^ y);//0110 -> 6, xor
            //Console.WriteLine(~x); //NOT : -6

            ////시프트 연산
            //int value = 4;//0100
            //Console.WriteLine(value << 1);//1000 -> 8
            //Console.WriteLine(value >> 1);//0010 -> 2

            ////삼항 연산자
            //int a = 10, b = 20;
            //int max = a > b ? a : b;
            //Console.WriteLine(max);

            //문제
            //int key = 1;
            //string doorState = (key==1) ? "문 열림" : "문 안열림.";
            //Console.WriteLine(doorState);

            #endregion

            #region 3시~4시
            //int score = 85;
            //if(score >=90) {
            //    Console.WriteLine("A학점");
            //}
            //else
            //{
            //    Console.WriteLine("B학점");
            //}

            //string gameID = "멋사검존";
            //if (gameID=="멋사검존")
            //{
            //    Console.WriteLine("아이디 일치");
            //}
            //else
            //{
            //    Console.WriteLine("아이디 불일치");
            //}

            ////가지고 있는 소지금을 입력하세요 :
            ////0~100 무대 +1
            ////101~200 카타나 +2
            ////201~300 진은검
            ////301~400 집판검
            ////401~500 엑스칼리버
            ////501~600 환검(한국 전통 검)

            //string[] knives = {"무대","카타나","진은검", "집판검", "엑스칼리버", "환검(한국 전통 검)", "전설의 검" };
            //Console.Write("소지금 입력 : ");
            //int money = int.Parse(Console.ReadLine());

            //int kinfeCase = (money-1) / 100;

            ////Console.WriteLine($"{knives[kinfeCase]}을 구매!");
            ////사실 이런 케이스에선 굳이 if안하고 저 한줄로 다 됩니다 :)

            //if (kinfeCase==0)
            //{
            //    Console.WriteLine(knives[kinfeCase]);
            //}
            //else if (kinfeCase==1) {
            //    Console.Write(knives[kinfeCase]);
            //}
            //else if (kinfeCase==2)
            //{
            //    Console.Write(knives[kinfeCase]);
            //}
            //else if (kinfeCase==3)
            //{
            //    Console.Write(knives[kinfeCase]);
            //}
            //else if (kinfeCase==4)
            //{
            //    Console.Write(knives[kinfeCase]);
            //}
            //else if (kinfeCase==5)
            //{
            //    Console.Write(knives[kinfeCase]);
            //}
            //else if (kinfeCase>=6)
            //{
            //    kinfeCase = 6;
            //    Console.Write(knives[kinfeCase]);
            //}
            //else
            //{
            //    Console.WriteLine("소지금이 부족합니다.");
            //}
            //Console.WriteLine("을 구매!!");

            ////2단계
            ////캐릭터 이름 멋사검존
            ////공격력 100 + 1

            //Console.WriteLine($"캐릭터 이름 : 멋사 검존 \n 공격력 : {100+kinfeCase}");
            //Console.WriteLine($"무기 : {100 + knives[kinfeCase]+1}"); 

            #endregion

            ///*
            // * 문제 1. 세 정수의 최대값 구하기
            //    문제 설명:
            //    사용자로부터 3개의 정수를 입력받아 그 중 가장 큰 값을 출력하는 프로그램을 작성하세요.
            //    요구사항:사용자에게 세 개의 정수를 입력받습니다.
            //    if문을 사용하여 가장 큰 정수를 결정합니다.
            //    결과를 “최대값: X” 형식으로 출력합니다.
            // */

            //Console.WriteLine("문제 1 ");
            //int a = int.Parse(Console.ReadLine()), b= int.Parse(Console.ReadLine()), c = int.Parse(Console.ReadLine());
            //int max = 0;
            //if(a > b)
            //{
            //    max = a>c ? a : c;
            //}
            //else
            //{
            //    max = b>c ? b : c;
            //}
            //Console.WriteLine($"가장 큰 수 {max}");

            ///*
            // * 문제 2. 점수에 따른 학점 평가
            //    문제 설명:
            //    학생의 점수를 입력받아 아래 기준에 따라 학점을 출력하는 프로그램을 작성하세요.

            //    90 이상: A 학점
            //    80 이상 90 미만: B 학점
            //    70 이상 80 미만: C 학점
            //    60 이상 70 미만: D 학점
            //    60 미만: F 학점
            //*/

            //Console.WriteLine("문제 2 ");
            //int score = int.Parse(Console.ReadLine());
            //int scoreCase = score/10;
            //string grade;
            //if (scoreCase >= 9)
            //{
            //    grade = "A";
            //}
            //else if (scoreCase >= 8)
            //{
            //    grade = "B";
            //}
            //else if (scoreCase >= 7)
            //{
            //    grade = "C";
            //}
            //else if (scoreCase >= 6)
            //{
            //    grade = "D";
            //}
            //else
            //{
            //    grade = "F";
            //}

            //Console.WriteLine($"Your grade is {grade}");

            ///*문제 3. 간단한 사칙연산 계산기
            //문제 설명:
            //사용자로부터 두 개의 숫자와 연산자(+, -, *, /)를 입력받아 해당 연산을 수행하고 결과를 출력하는 계산기 프로그램을 작성하세요.
            //요구사항:

            //두 개의 숫자와 연산자 기호를 입력받습니다.
            //if문을 사용하여 연산자를 확인하고 해당 연산을 수행합니다.
            //나눗셈의 경우 0으로 나누는 상황을 처리하여 에러 메시지를 출력합니다.
            //결과는 “결과: X” 형식으로 출력합니다.
            //*/

            //Console.WriteLine("문제 3 ");

            //Console.WriteLine("두 수 입력 ... ");
            //int n1 = int.Parse(Console.ReadLine()), n2 = int.Parse(Console.ReadLine());
            //Console.WriteLine("연산자 입력 ... ");
            //string oper = Console.ReadLine();

            //if (oper == "+") Console.WriteLine(n1+n2);
            //else if (oper == "-") Console.WriteLine(n1-n2);
            //else if (oper == "*") Console.WriteLine(n1*n2);
            //else
            //{

            //    if(n2 == 0) Console.WriteLine("0으로 나눌 수 없습니다.");
            //    else Console.WriteLine(n1/n2);
            //}

            string s = "";
            s = String.Join(s,Console.ReadLine());
            Console.WriteLine(s);
        }
    }
}
