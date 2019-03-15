using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_Client_Chat 
{
    public class Client
    {
      
        private EndPoint endPoint;
        string message = "ciao";
        public string inverseMessage;
        private ChatServer server;
        
        public Client(ChatServer server, EndPoint endPoint)
        {
            this.endPoint = endPoint;
            this.server = server;
        }



        void Process() 
        {
         

            byte[] data = ConvertStringToBytes();
            server.Send(data, endPoint );
        }

        byte[] ConvertStringToBytes()
        {
            return Encoding.UTF8.GetBytes(message);
        }

        

    }
}
