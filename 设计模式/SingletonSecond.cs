using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.设计模式
{
    /// <summary>
    /// 饿汉式
    /// </summary>
    public sealed class SingletonSecond
    {
        private SingletonSecond()
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

        private static SingletonSecond _singletonSecond = null;
        /// <summary>
        /// 静态构造函数：由CLR保证，在第一次使用到这个类型之前，自动被调用且只被调用一次
        /// </summary>
        static SingletonSecond()
        {
            _singletonSecond = new SingletonSecond();
        }
        public static SingletonSecond CreateInstance()
        {
            return _singletonSecond;
        } 

        public void Show()
        {
            Console.WriteLine("哈哈哈");
        }
    }
}
