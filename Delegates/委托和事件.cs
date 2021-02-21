using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    public class 委托和事件
    {
        public void Show()
        {
            {
                Man man = new Man();
                man.SayWhatHandler += () => new Son().Cry(3);
                
                //man.SayWhatHandler.Invoke();
                //man.SayWhatHandler = null;

                man.SayWhatDelegate();
            }
            {
                Man man = new Man();
                man.SayWhatHandlerEvent += () => new Son().Cry(3);

                //man.SayWhatHandlerEvent.Invoke();
                //man.SayWhatHandlerEvent = null;
                
                man.SayWhatDelegateEvent();
            }
        }
    }

    public class Man
    {
        //委托
        public Action SayWhatHandler;
        public void SayWhatDelegate()
        {
            Console.WriteLine($"{this.GetType().Name} SayWhatDelegate......");
            this.SayWhatHandler?.Invoke();
        }

        //事件
        public event Action SayWhatHandlerEvent;
        public void SayWhatDelegateEvent()
        {
            Console.WriteLine($"{this.GetType().Name} SayWhatDelegateEvent......");
            this.SayWhatHandlerEvent?.Invoke();
        }
    }

    public class Son
    {
        public void Cry(int num)
        {
            Console.WriteLine("55555555");
        } 
    }
}
