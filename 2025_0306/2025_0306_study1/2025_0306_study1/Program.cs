using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//namespace Hello //namespace
//{
//    class Say
//    {
//        static public void SayHello()
//        {
//            Console.WriteLine("Hello");
//        }
//    }
//}

namespace _2025_0306_study1
{
    //class Person
    //{
    //    private string name;   
    //    public Person()
    //    {
    //        name = "Unknown";
    //    }
    //    public void SetName(string name) {  this.name = name; }
    //    public string GetName() { return name; }
    //}

    //class Test
    //{
    //    int time = Environment.TickCount;
    //    ~Test() {
    //        Console.WriteLine(Environment.TickCount-time);
    //    }
    //}
    class Program
    {
        static void OutFunc(out int x)
        {
            x = 10;
        }
        static void Main(string[] args)
        {
            //입력이 N개 들어온다. 
            
            //Person p = new Person();
            //Console.WriteLine(p.GetName());
            //p.SetName("Alice");
            //Console.WriteLine(p.GetName());
            //while (true)
            //{
            //    Test test = new Test();
            //}
            int x;
            OutFunc(out x);
        }
    }
}
