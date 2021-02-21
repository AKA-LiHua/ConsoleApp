using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    /// <summary>
    /// 泛型类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {

    }

    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="S"></typeparam>
    public interface GenericInterface<S>
    {

    }

    #region 简单使用泛型类、泛型接口

    //使用方法1
    public class Child<T> : GenericClass<T>, GenericInterface<T>
    {

    }

    //使用方法2
    public class ChildC : GenericClass<int>, GenericInterface<int>
    {

    }

    public class Common
    {
        public Common()
        {
            Child<string> child = new Child<string>();
            ChildC childC = new ChildC();
        }
    }

    #endregion


    /// <summary>
    /// 泛型委托
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public delegate T GetHandler<T>();
}
