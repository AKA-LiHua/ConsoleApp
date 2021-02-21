using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    /// <summary>
    /// 泛型约束
    /// </summary>
    public class GenericConstraint
    {
        /// <summary>
        /// 方法是通用的，并且想使用People的一些信息，得保证传入的都是People或其子类
        /// 泛型约束：在泛型声明之后 where T :
        ///     基类约束：【只能一个】
        ///     1、权力 -》可以直接在方法里面使用基类的东西
        ///     2、义务 -》传入的类型参数必须满足约束
        ///     接口约束：【可以多个】
        ///     1、权力 -》可以直接在方法里面使用接口的东西
        ///     2、义务 -》传入的类型参数必须满足约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) 
            where T : People, ISport, ITag
        {
            Console.WriteLine("This is ShowObject, parameter = {0} type ={1}", tParameter.ToString(), tParameter.GetType());

            Console.WriteLine(tParameter.Id);
            Console.WriteLine(tParameter.Name);
            tParameter.Breath();

            tParameter.Walk();
        }

        /// <summary>
        /// 直接使用父类做参数，相对于泛型+约束而言  缺少灵活性，做不到多重约束 
        /// 只能是People及其子类
        /// </summary>
        /// <param name="tParameter"></param>
        public static void ShowParent(People tParameter)
        {
            Console.WriteLine("This is ShowObject, parameter = {0} type ={1}", tParameter.ToString(), tParameter.GetType());

            Console.WriteLine(tParameter.Id);
            Console.WriteLine(tParameter.Name);
            tParameter.Breath();
        }


        public static T Get<T>(T tParameter)
            //where T : class //ef经常有  引用类型约束
            //where T : struct //值类型约束
            where T : new() //无参构造函数约束 
        {
            //return null; //有 引用类型约束 才可以这样用
            //return default(T); //根据T的类型返回默认值  【通用的】
            return new T(); //有 无参构造函数约束 才可以这样用
            //return tParameter;
        }

        public static LiHua Get<T, S, LiHua>(T t)
            where T: new()
            where S: struct
            where LiHua: class
        {
            return default(LiHua);
        }
    }
}
