using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.设计模式
{
    /// <summary>
    /// 普通方法、虚方法、抽象方法
    /// </summary>
    public class MethodTest
    {
        public void Show()
        {
            #region Abstract
            {
                //ParentClass parentClass = new ParentClass(); //抽象类不能直接实例化

                Console.WriteLine(" ParentClass abstractTest1 = new ChildClass();");
                ParentClass abstractTest1 = new ChildClass();
                abstractTest1.Show();
            }
            {
                Console.WriteLine("ChildClass abstractTest2 = new ChildClass();");
                ChildClass abstractTest2 = new ChildClass();
                abstractTest2.Show();
            }
            #endregion

            Console.WriteLine("****************");

            #region Common
            {
                Console.WriteLine("NewTest newTest1 = new NewTest();");
                NewTest newTest1 = new NewTest();
                newTest1.Show();
            }
            {
                Console.WriteLine("NewTest newTest2 = new NewTestChild();");
                NewTest newTest2 = new NewTestChild();
                newTest2.Show();
                //结果是：this is NewTest
                //提问：为什么会调用子类的方法？
                //错误回答：因为newTest2运行时是NewTestChild实例
                //原因：方法调用的选择是编译时决定的，在编译的时候只知道 newTest2 是 NewTest 类型的变量，所以方法就是用的父类的
                //所以：普通方法的调用是以左边为准的（编译时决定的）
            }
            {
                Console.WriteLine("NewTestChild newTest3 = new NewTestChild();");
                NewTestChild newTest3 = new NewTestChild();
                newTest3.Show();
            }
            #endregion

            Console.WriteLine("****************");

            #region Virtual
            {
                Console.WriteLine("VirtualTest virtualTest1 = new VirtualTest();");
                VirtualTest virtualTest1 = new VirtualTest();
                virtualTest1.Show();
            }
            {
                Console.WriteLine("VirtualTest virtualTest2 = new VirtualTestChild();");
                VirtualTest virtualTest2 = new VirtualTestChild();
                virtualTest2.Show();
                //抽象方法、虚方法 是特别处理的，编译时如果遇到 virtual、abstract 关键字，会把方法的选择留到运行时决定
                //所以：抽象/虚方法的调用是由右边决定的（运行时决定的）
            }
            {
                Console.WriteLine("VirtualTestChild virtualTest3 = new VirtualTestChild();");
                VirtualTestChild virtualTest3 = new VirtualTestChild();
                virtualTest3.Show();
            }
            #endregion
        }
    }


    #region Abstract

    //抽象类
    public abstract class ParentClass
    {
        //抽象方法
        public abstract void Show();
    }

    public class ChildClass : ParentClass
    {
        //virtual
        public override void Show()
        {
            Console.WriteLine("this is ChildClass");
        }
    }
    #endregion

    #region Common

    //普通类
    public class NewTest
    {
        //common
        public void Show()
        {
            Console.WriteLine("this is NewTest");
        }
    }

    public class NewTestChild : NewTest
    {
        // new 要不要都没有区别 都会隐藏掉父类方法
        //不要 new 会提示警告，不会报错
        public new void Show()
        {
            Console.WriteLine("this is NewTestChild");
        }
    }
    #endregion

    #region Virtual

    public class VirtualTest
    {
        // virtual 虚方法 必须包含实现，但是可以被复写
        public virtual void Show()
        {
            Console.WriteLine("this is VirtualTest");
        }
    }

    public class VirtualTestChild : VirtualTest
    {
        //可以复写，也可以不复写
        public override void Show()
        {
            Console.WriteLine("this is VirtualTestChild");
        }
    }
    #endregion
}
