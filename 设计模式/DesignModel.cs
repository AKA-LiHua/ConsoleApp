using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.设计模式
{
    public class DesignModel
    {
        public void Show()
        {
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    //Singleton singleton = new Singleton(); //普通写法，会创建5次对象
                //    Singleton singleton = Singleton.CreateInstance();
                //    singleton.Show();
                //}

                //Singleton.DoNothing();

                //for (int i = 0; i < 5; i++)
                //{
                //    //启动一个线程执行这些动作，可以认为是5个同时执行
                //    Task.Run(() =>
                //    {
                //        Singleton singleton = Singleton.CreateInstance();
                //        singleton.Show();
                //    });
                //}
            }
            {
                //SingletonSecond singletonSecond = new SingletonSecond();
                //for (int i = 0; i < 5; i++)
                //{
                //    //启动一个线程执行这些动作，可以认为是5个同时执行
                //    Task.Run(() =>
                //    {
                //        SingletonSecond singleton = SingletonSecond.CreateInstance();
                //        singleton.Show();
                //    });
                //}
            }
            {
                //for (int i = 0; i < 5; i++)
                //{
                //    //启动一个线程执行这些动作，可以认为是5个同时执行
                //    Task.Run(() =>
                //    {
                //        SingletonThird singleton = SingletonThird.CreateInstance();
                //        singleton.Show();
                //    });
                //}
            }
            {
                //List<Task> tasks = new List<Task>();
                //for (int i = 0; i < 10000; i++)
                //{
                //    tasks.Add(Task.Run(() =>
                //    {
                //        Singleton singleton = Singleton.CreateInstance();
                //        singleton.Add();
                //    }));
                //}
                //Task.WaitAll(tasks.ToArray()); //等待10000个Task都完成
                //{
                //    Singleton singleton = Singleton.CreateInstance();
                //    Console.WriteLine(singleton.Num); //结果：一个比10000小的数字，接近10000，每次结果不一样
                //}
            }
            {
                MethodTest methodTest = new MethodTest();
                methodTest.Show();
            }
        }
    }
}
