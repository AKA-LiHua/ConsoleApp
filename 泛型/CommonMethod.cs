using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    public class CommonMethod
    {
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is ShowInt, parameter = {0} type ={1}",iParameter, iParameter.GetType());
        }

        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is ShowString, parameter = {0} type ={1}", sParameter, sParameter.GetType());
        }

        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is ShowDateTime, parameter = {0} type ={1}", dtParameter, dtParameter.GetType());
        }

        /// <summary>
        /// 1、装箱 拆箱 性能损失
        /// 2、隐藏的类型安全隐患
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is ShowObject, parameter = {0} type ={1}", oParameter, oParameter.GetType());
        }
    }
}
