using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    public class DelegateDemo
    {
        public delegate void SayHelloDlg(string str);
        public event SayHelloDlg SayHelloEvent;
                
        public void Show()
        {
            SayHelloDlg sya1 = null;
            sya1 += null;
            sya1?.Invoke("hahah");

            //SayHelloDlg say = SayHello;
            //say += SayByeBye;
            //say -= SayHello;
            //say("viki");
            //say.Invoke("mimi");


            //SayHelloDlg sayHello = delegate (string name)
            //{
            //    Console.WriteLine($"{name},ahah");
            //};
            //sayHello("pig");


            //SayHelloDlg sayHello1 = ((string name) => { Console.WriteLine(name); });
            //SayHelloDlg sayHello1 = (string name) => { Console.WriteLine(name); };
            //SayHelloDlg sayHello1 = (name) => { Console.WriteLine(name); };
            //SayHelloDlg sayHello1 = name => { Console.WriteLine(name); };

            //sayHello1("DiDi");

            //事件
            //SayHelloEvent += Program_SayHelloEvent; //注册事件
            //SayHelloEvent -= Program_SayHelloEvent; //取消注册事件

            //调用
            //if (SayHelloEvent != null)
            //{
            //    SayHelloEvent("hahah");
            //}
        }

        private void Program_SayHelloEvent(string str)
        {
            Console.WriteLine(str);
        }

        public void SayHello(string name)
        {
            Console.WriteLine($"{name},hello");
        }

        public void SayByeBye(string name)
        {
            Console.WriteLine($"{name},byebye~");
        }
    }

}

