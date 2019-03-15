using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Server_Client_Chat.Test
{
    public class  TestManager
    {
        private FakeTransport transport;
        
        private  ChatServer server;

        // Viene chiamato prima di ogni test
        [SetUp]
        public void SetUp()
        {
            transport = new FakeTransport();
            
            server = new ChatServer(transport);
        }

        [Test]
        public void TestClientOnStart()
        {
            Assert.That(server.client, Is.Not.EqualTo(null));
        }
    }
}
