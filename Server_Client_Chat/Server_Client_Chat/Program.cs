using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Client_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportIPv4 transport = new TransportIPv4();
            transport.Bind("192.168.1.2", 9999);

            ChatServer server = new ChatServer(transport);

            
        }
    }
}
