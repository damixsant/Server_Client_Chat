﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Server_Client_Chat.Test
{
    public struct FakeData
    {
        public FakeEndPoint endPoint;
        public byte[] data;
    }

    public class FakeQueueEmpty : Exception
    {

    }

    public class FakeTransport : ITransport
    {
        private FakeEndPoint boundAddress;

        private Queue<FakeData> recvQueue;
        private Queue<FakeData> sendQueue;

        public FakeTransport()
        {
            recvQueue = new Queue<FakeData>();
            sendQueue = new Queue<FakeData>();
        }

        public uint ClientQueueCount { get { return (uint)sendQueue.Count; } }



        public FakeData ClientDequeue()
        {
            if (sendQueue.Count <= 0)
                throw new FakeQueueEmpty();
            return sendQueue.Dequeue();
        }

        public void Bind(string address, int port)
        {
            boundAddress = new FakeEndPoint(address, port);
        }

        public EndPoint CreateEndPoint()
        {
            return new FakeEndPoint();
        }

        public byte[] Recv(int bufferSize, ref EndPoint sender)
        {
            FakeData fakeData = recvQueue.Dequeue();
            if (fakeData.data.Length > bufferSize)
                return null;
            sender = fakeData.endPoint;
            return fakeData.data;
        }

     

        public bool Send(byte[] data, EndPoint endPoint)
        {
            FakeData fakeData = new FakeData();
            fakeData.data = data;
            fakeData.endPoint = endPoint as FakeEndPoint;
            sendQueue.Enqueue(fakeData);
            return true;
        }
    }
}
