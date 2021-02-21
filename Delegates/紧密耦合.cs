using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    public class 紧密耦合
    {
        public void Show()
        {
            var _clinet = new Client();

        }

    }

    public class Client
    {
        public Operation operation;
        public Client()
        {
            operation = new Operation(this);
            operation.Operating();
        }

        public void Completed()
        {
            Console.WriteLine("Completed");
        }
    }

    public class Operation
    {
        Client client;
        public Operation(Client _client)
        {
            client = _client;
        }

        public void Operating()
        {
            Console.WriteLine("Operating");
            client.Completed();
        }
    }
}
