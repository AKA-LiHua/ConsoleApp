using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    public class Bird
    {
        public int Id { get; set; }
    }
    public class Sparrow : Bird
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// out 协变  只能是返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListOut<out T> 
        //where T : new()
    {
        T Get();

        //void Show(T t);
    }

    public class CustomerListOut<T> : ICustomerListOut<T>
        //where T : new()
    {
        public T Get()
        {
            return default(T);
            //return new T();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustomerListIn<in T>
    //where T : new()
    {
        //T Get();

        void Show(T t);
    }

    public class CustomerListIn<T> : ICustomerListIn<T>
    //where T : new()
    {
        //public T Get()
        //{
        //    return default(T);
        //    //return new T();
        //}
        public void Show(T t)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);
    }

    public class MyList<T1, T2> : IMyList<T1, T2>
    {
        public T2 Do(T1 t)
        {
            throw new NotImplementedException();
        }

        public T2 Get()
        {
            throw new NotImplementedException();
        }

        public void Show(T1 t)
        {
            throw new NotImplementedException();
        }
    }
}
