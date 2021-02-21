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
    public sealed class SingletonThird
    {
        private SingletonThird()
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

        /// <summary>
        /// 静态字段：由CLR保证，在第一次使用这个类型之前，会自动初始化且只初始化一次
        /// </summary>
        private static SingletonThird _singletonThird = new SingletonThird();
        public static SingletonThird CreateInstance()
        {
            return _singletonThird;
        } 

        public void Show()
        {
            Console.WriteLine("哈哈哈");
        }
    }
}
