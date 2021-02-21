using ConsoleApp1.Delegates;
using ConsoleApp1.Linq;
using ConsoleApp1.XML;
using ConsoleApp1.泛型;
using ConsoleApp1.设计模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //new DelegateDemo().Show();

            //new 紧密耦合().Show();

            //new 委托解耦().Show();

            //new 产品订单().Show();

            //new XMLTEST().ser();

            //new Student().Show();

            //new LinqTest().Show();
            //new LinqTest().Show1();

            //foreach (int i in Power(2, 8, ""))
            //{
            //    Console.Write("{0} ", i);
            //}

            //new 委托和事件().Show();

            //new LhGeneric().ShowCC();

            new DesignModel().Show();

            Console.ReadKey();
        }
        //public static IEnumerable<int> Power(int number, int exponent, string s)
        //{
        //    int result = 1;

        //    var list = new List<int>();
        //    for (int i = 0; i < exponent; i++)
        //    {
        //        result = result * number;
        //        //list.Add(result);
        //        yield return result;
        //    }
        //    //return list;
        //    yield return 3;
        //    yield return 4;
        //    yield return 5;
        //}

    }
}
