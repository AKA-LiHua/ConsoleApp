using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    /// <summary>
    /// 泛型方法：为了一个方法满足不同类型的参数
    /// </summary>
    public class GenericMethod
    {
        /// <summary>
        /// 泛型方法：方法名后面多了个类型参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is ShowObject, parameter = {0} type ={1}", tParameter, tParameter.GetType());
        }

        //可以在方法名后面使用多个类型参数
        //参数可以不按照类型参数传
        private void ShowMany<T,S,HAHA>(T t, S s, string aa)
        {

        }
    }

    ///// <summary>
    ///// 泛型类
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public class GenericClass<T>
    //{
    //    public void Show1(T t)
    //    {

    //    }

    //    public void Show<S>(T t, S s)
    //    {

    //    }
    //}
}
