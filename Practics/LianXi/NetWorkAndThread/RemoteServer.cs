using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.NetWorkAndThread
{
    //远程服务器
    public class RemoteServer
    {
        public void Main()
        {
            IPAddress ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
            //对本地的8500端口进行监听
            TcpListener tcpListener = new TcpListener(ip, 8500);
            tcpListener.Start();
            Console.WriteLine("Server is Running");
            while (true)
            {
                //同步获取
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                string szRemotePoint = tcpClient.Client.RemoteEndPoint.ToString();
                Console.WriteLine("收到的连接" + szRemotePoint);
                ReceiveAndSentMsg receiveAndSentMsg = new ReceiveAndSentMsg(true);
                receiveAndSentMsg.Init(tcpClient);
            }
        }
    }
}
