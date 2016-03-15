using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Practics.LianXi.NetWorkAndThread
{
    //本地客户端
    public class LocalClient
    {
        private Dictionary<string, ReceiveAndSentMsg> dicReceiveAndSent;
        string[] szEndPoint;

        public LocalClient()
        {
            dicReceiveAndSent = new Dictionary<string, ReceiveAndSentMsg>();
        }

        public void Main()
        {
            TcpClient tcpClient;
            szEndPoint = new string[3];
            for (int i = 0; i < 3; i++)
            {
                tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect("localhost", 8500);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                string szTemp = tcpClient.Client.LocalEndPoint.ToString();
                dicReceiveAndSent[szTemp] = new ReceiveAndSentMsg(false);
                dicReceiveAndSent[szTemp].Init(tcpClient);
                szEndPoint[i] = szTemp;
            }
            ConsoleKey key;
            int nIndex = 0;
            string[] szSentMsg = new string[1];
            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    nIndex++;
                    if (nIndex >= szEndPoint.Length)
                    {
                        nIndex = 0;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    nIndex--;
                    if (nIndex < 0)
                    {
                        nIndex = szEndPoint.Length - 1;
                    }
                }

                string msg = Console.ReadLine();
                if (!string.IsNullOrEmpty(msg))
                {
                    string szKey = szEndPoint[nIndex];
                    msg = szKey + ":" + msg;
                    szSentMsg[0] = msg;
                    Console.WriteLine("客户端发送数据：" + msg);
                    dicReceiveAndSent[szKey].SentMsg(szSentMsg);
                    Thread.Sleep(15);
                }
            } while (key != ConsoleKey.End);
        }
    }
}
