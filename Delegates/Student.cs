using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    public delegate void SayHiDelegate(string name);

    /// <summary>
    /// 需求：基础问候，需要支持不同的语言版本
    /// </summary>
    public class Student
    {
        public void Show()
        {
            Student student = new Student();
            //student.SayHi("狗子", Student.Country.Chinese);
            //student.SayHi("宫本", Student.Country.Japanese);
            //student.SayHi("宋钟基", Student.Country.Korea);
            //student.SayHi("bbbb", Student.Country.Australian);

            //student.SayHiChinese("狗子");
            //student.SayHiJapanese("宫本");
            //student.SayHiKorea("宋钟基");
            //student.SayHiAustralian("bbbb");

            SayHiDelegate sayHiChinese = new SayHiDelegate(student.SayHiChinese);
            sayHiChinese("狗子");

            SayHiDelegate sayHiJapanese = new SayHiDelegate(student.SayHiJapanese);
            sayHiJapanese("宫本");

            SayHiDelegate sayHiKorea = new SayHiDelegate(student.SayHiKorea);
            sayHiKorea("宋钟基");

            SayHiDelegate sayHiAustralian = new SayHiDelegate(student.SayHiAustralian);
            sayHiAustralian("bbbb");
        }

        /// <summary>
        /// 方法一、
        /// 缺点：如果再加一种语言，需要修改现有代码 ----对修改没有关闭，导致代码不稳定
        ///       逻辑耦合，不稳定
        ///       所有逻辑都包含在这里，所以任何分支变化都需要修改
        /// 要做的事情：
        /// 如何把分支逻辑分开
        /// 现在时传递Country ----进行类型判断----选择对应的逻辑
        /// 要不试试直接传递逻辑？？？？----逻辑就是方法---需要把方法做成变量  -- 委托
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        public void SayHi(string name, Country country)
        {
            //日志
            Console.WriteLine("start loging");
            switch (country)
            {
                case Country.Chinese:
                    Console.WriteLine($"你好，{name}");
                    break;
                case Country.Japanese:
                    Console.WriteLine($"扣你吉瓦，{name}");
                    break;
                case Country.Korea:
                    Console.WriteLine($"啊你哈塞哟，{name}");
                    break;
                case Country.Australian:
                    Console.WriteLine($"balabala，{name}");
                    break;
                default:
                    break;
            }
            Console.WriteLine("end loging");
        }

        public enum Country
        {
            Chinese,
            Japanese,
            Korea,
            Australian
        }


        /// <summary>
        /// 方法二、
        /// 不再受分支影响，加分支就加方法，不影响现有方法
        /// 缺点：
        /// 如果希望价格日志，就会发现有大量重复代码
        /// </summary>
        /// <param name="name"></param>

        public void SayHiChinese(string name)
        {
            Console.WriteLine("start loging");
            Console.WriteLine($"你好，{name}");
            Console.WriteLine("end loging");
        }
        public void SayHiJapanese(string name)
        {
            Console.WriteLine("start loging");
            Console.WriteLine($"扣你吉瓦，{name}");
            Console.WriteLine("end loging");
        }
        public void SayHiKorea(string name)
        {
            Console.WriteLine("start loging");
            Console.WriteLine($"啊你哈塞哟，{name}");
            Console.WriteLine("end loging");
        }
        public void SayHiAustralian(string name)
        {
            Console.WriteLine("start loging");
            Console.WriteLine($"balabala，{name}");
            Console.WriteLine("end loging");
        }

        /// <summary>
        /// 方法三、使用委托
        /// </summary>
        public void SayHiSenior(string name, SayHiDelegate sayHi)
        {
            Console.WriteLine("start loging");
            sayHi.Invoke(name);
            Console.WriteLine("end loging");
        }
    }    
}
