using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server_Client_Chat
{
    public class ChatServer
    {
        private ITransport transport;
        EndPoint clientAddress;
        public Client client;

        public ChatServer(ITransport transport)
        {
            this.transport = transport;
            
        }

        public void Update()
        {
            EndPoint sender = transport.CreateEndPoint();
            byte[] data = transport.Recv(256, ref sender);

            if(data != null)
            {
                string message = ConvertBytesToString(data);
                string invMess = Reverse(message);

                byte[] invData = ConvertStringToBytes(invMess);
            }

        }
        public bool Send(byte[]data,EndPoint sender)
        {
            return transport.Send(data, sender);
        }

        private void Join(byte[] data, EndPoint sender)
        {
            client = new Client(this, sender);

        }

        string ConvertBytesToString(byte[] data)
        {
            return Encoding.UTF8.GetString(data);
        }

        byte[] ConvertStringToBytes(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        public string Reverse (string message)
        {
            char[] charArray = message.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
