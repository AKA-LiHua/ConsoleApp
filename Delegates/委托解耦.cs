using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    public class 委托解耦
    {
        public void Show()
        {
            var _clinet = new ClientNew();

        }
    }


    public class ClientNew
    {
        public OperationNew operation;
        public ClientNew()
        {
            operation = new OperationNew();
            operation.Operating(Completed);
        }

        public void Completed()
        {
            Console.WriteLine("Completed");
        }
    }

    public class OperationNew
    {
        public delegate void Callback();

        public void Operating(Callback callback)
        {
            Console.WriteLine("Operating");
            callback.Invoke();
        }
    }
}
