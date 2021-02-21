using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.设计模式
{
    /// <summary>
    /// 单列类：一个构造对象很耗时耗资源类型
    /// </summary>
    /// 
    /// 懒汉式
    ///
    public sealed class Singleton
    {
        private Singleton()
        {
            //do......
            long lresult = 0;
            for (int i = 0; i < 100; i++)
            {
                lresult += i;
            }
            Thread.Sleep(1000);

            Console.WriteLine($"{this.GetType().Name}被构造一次");
        }

        private static Singleton _singleton = null;
        private static readonly object singleton_lock = new object();
        public static Singleton CreateInstance()
        {
            //开始多线程初始化 -- lock锁定 -- 线程请求锁 -- 开始判断创建
            //以上多线程都结束后，再来个多线程请求呢？ --- 结果是都需要等待锁
            //-- 拿到锁 -- 进去判断 -- 不为空 -- 返回对象 -- ……（以上过程循环往复）
            //会造成浪费
            //解决：不需要等待锁，直接判断
            if(_singleton == null)
            {
                lock (singleton_lock)//可以保证任何时刻只有一个线程进入，其他线程等待
                {
                    if (_singleton == null)//这个判断不能去掉，保证只初始化一次
                    {
                        _singleton = new Singleton();
                    }
                }//线程到这里出来之后，下一个线程进入
            }
            return _singleton;
        } 

        public void Show()
        {
            Console.WriteLine("哈哈哈");
        }

        public static void DoNothing()
        {
            Console.WriteLine("Do Nothing");
        }

        public int Num = 0; //不是线程安全的，10000个线程同时来+1，总会有要等待的，结果一定小于10000
        public void Add()
        {
            this.Num++;
        }
    }
}
