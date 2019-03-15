﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server_Client_Chat.Test
{
    public class FakeEndPoint : EndPoint
    {
        private string address;
        public string Addr { get { return address; } }
        private int port;
        public int Port { get { return port; } }

        public FakeEndPoint()
        {

        }

        public FakeEndPoint(string address, int port)
        {
            this.address = address;
            this.port = port;
        }



        public override int GetHashCode()
        {
            return Addr.GetHashCode() + Port;
        }

        public override bool Equals(object obj)
        {
            FakeEndPoint other = obj as FakeEndPoint;
            if (other == null)
                return false;

            return (this.address == other.address) && (this.port == other.port);
        }
    }
}
