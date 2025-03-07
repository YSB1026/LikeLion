using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_0307_study1
{
    class Program
    {
        //델리게이트 정의 - 메세지 출력을 위한 메서드 참조
        //함수 단위로 데이터 전달
        delegate void MessageHandler(string message);
        static void DisplayMessage(string message)
        {
            Console.WriteLine($"메세지 : {message}");
        }
        static void DisplayUpperMessage(string message)
        {
            Console.WriteLine($"대문자 메세지 : {message.ToUpper()}");
        }
        static void Main(string[] args)
        {
            //델리게이트, 이벤트
            Console.WriteLine("=== 간단한 델리게이트와 이벤트 예제 ===");

            //1.델리게이트 사용해보기
            Console.WriteLine("델리게이트");

            //델리게이트 변수 선언 및 메서드 연결
            //DisplayMessage함수 MessageHandler 변수 할당
            MessageHandler messageHandler = DisplayMessage;
            messageHandler("안녕하세요");

            //델리게이트에 다른 메서드 추가(멀티캐스트 델리게이트)
            // += 연산자로 메서드 추가
            messageHandler+=DisplayUpperMessage;

            //여러 메서드가 연결된 델리게이트 호출
            //등록된 모든 메서드가 순서대로 호출됨
            Console.WriteLine("여러 메서드 호출:");
            messageHandler("Hello c#");

            
        }
    }
}
