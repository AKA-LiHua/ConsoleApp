using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Linq
{
    public static class LinqExtension
    {
        #region Linq Where
        //Linq Where ：基于委托的代码封装，把数据筛选的通用逻辑完成，把判断逻辑交给委托传递

        /// <summary>
        /// 基于委托封装，完成代码的复用
        /// </summary>
        /// <param name="studentsList"></param>
        /// <param name="func">不同的逻辑需要传递，那么就是委托</param>
        /// <returns></returns>
        //public static List<Student> LinqWhere(List<Student> studentsList, Func<Student, bool> func)
        //{
        //    List<Student> students = new List<Student>();
        //    foreach (var student in studentsList)
        //    {
        //        if (func.Invoke(student))
        //        {
        //            students.Add(student);
        //        }
        //    }
        //    return students;
        //}

        /// <summary>
        /// 基于委托封装，完成代码的复用
        /// </summary>
        /// <typeparam name="T">泛型满足不同类型的需求</typeparam>
        /// <param name="list"></param>
        /// <param name="func">不同的逻辑需要传递，那么就是委托</param>
        /// <returns></returns>
        public static List<T> LinqWhere<T>(List<T> list, Func<T, bool> func)
        {
            List<T> _list = new List<T>();
            foreach (var item in list)
            {
                if (func.Invoke(item))
                {
                    _list.Add(item);
                }
            }
            return _list;
        }

        /// <summary>
        /// 基于委托封装，完成代码的复用
        /// </summary>
        /// <typeparam name="T">泛型满足不同类型的需求</typeparam>
        /// <param name="list">静态类 + 静态方法 + 第一个参数前面加this  ==》 扩展方法</param>
        /// <param name="func">不同的逻辑需要传递，那么就是委托</param>
        /// <returns></returns>
        public static List<T> LinqWhere2<T>(this List<T> list, Func<T, bool> func)
        {
            List<T> _list = new List<T>();
            foreach (var item in list)
            {
                if (func.Invoke(item))
                {
                    _list.Add(item);
                }
            }
            return _list;
        }

        /// <summary>
        /// 基于委托封装，完成代码的复用
        /// 迭代器升级，做到了按需获取，延迟加载
        /// </summary>
        /// <typeparam name="T">泛型满足不同类型的需求</typeparam>
        /// <param name="list">静态类 + 静态方法 + 第一个参数前面加this  ==》 扩展方法</param>
        /// <param name="func">不同的逻辑需要传递，那么就是委托</param>
        /// <returns></returns>
        public static IEnumerable<T> IEnumerableLinqWhere<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        #endregion
    }
}
