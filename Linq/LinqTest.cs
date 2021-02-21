using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Linq
{
    public class LinqTest
    {
        public void Show()
        {
            List<Student> studentsList = DataInit.GetStudentsList();

            //Func<Student, bool> func1 = new Func<Student, bool>(student => { return student.Age > 15; });
            //Func<Student, bool> func1 = new Func<Student, bool>(student => student.Age > 15);
            //Func<Student, bool> func1 = student => student.Age > 15;
            //List<Student> students1 = LinqWhere(studentsList, func1);

            List<Student> students1 = LinqExtension.LinqWhere(studentsList, student => student.Age > 15);

            List<int> numList = new List<int>() { 1, 4, 65, 123, 676, 76, 9, 134, 987, 23, 654, 99, 321, 327, 0 };
            List<int> list1 = LinqExtension.LinqWhere<int>(numList, num => num > 100);
            List<int> list2 = LinqExtension.LinqWhere(numList, num => num > 100);

            //调用扩展方法
            List<int> list3 = numList.LinqWhere2(num => num > 100);

            IEnumerable<int> list4 = numList.IEnumerableLinqWhere(num => num > 100);
        }

        public void Show1()
        {
            List<int> numList = new List<int>() { 1, 4, 65, 123, 676, 76, 9, 134, 987, 23, 654, 99, 321, 327, 0 };
            {
                Console.WriteLine("************* start 系统定义的 ************");

                var list = numList.Where(s => {
                    Thread.Sleep(300);
                    return s > 100; 
                });
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("************* end 系统定义的 ************");
            }
            {
                Console.WriteLine("************* start 自定义1的 ************");

                var list = numList.LinqWhere2(s => {
                    Thread.Sleep(300);
                    return s > 100;
                });
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("************* end 自定义1的 ************");
            }
            {
                Console.WriteLine("************* start 自定义2的 ************");

                var list = numList.IEnumerableLinqWhere(s => {
                    Thread.Sleep(300);
                    return s > 100;
                });
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("************* end 自定义2的 ************");
            }
        }

    }
}
