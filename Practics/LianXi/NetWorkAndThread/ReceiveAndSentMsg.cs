using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Practics.LianXi.NetWorkAndThread
{
    //接收和发送数据
    public class ReceiveAndSentMsg
    {
        private bool m_bIsServer;
        private byte[] m_buffer;
        private const int nBufferSize = 8192;
        private TcpClient m_TcpClient;
        private NetworkStream m_networkStream;
        private TransportProtocol m_transportProtocol;
        private List<string> listMsgs;
        private string m_szRemoteEndPoint;

        public ReceiveAndSentMsg(bool bIsServer)
        {
            m_bIsServer = bIsServer;
            m_buffer = new byte[nBufferSize];
            m_transportProtocol = new TransportProtocol();
            listMsgs = new List<string>();
        }

        public void Init(TcpClient tcpClient)
        {
            if (null == tcpClient)
            {
                return;
            }
            m_TcpClient = tcpClient;
            m_szRemoteEndPoint = m_TcpClient.Client.RemoteEndPoint.ToString();
            m_networkStream = m_TcpClient.GetStream();
            AsyncCallback asyncCallback = new AsyncCallback(ReadComplete);
            m_networkStream.BeginRead(m_buffer, 0, nBufferSize, asyncCallback, null);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="szMsg"></param>
        public void SentMsg(string[] szMsg)
        {
            if (null == m_networkStream || null == m_transportProtocol)
            {
                return;
            }
            for (int i = 0; i < szMsg.Length; i++)
            {
                if ("" == szMsg[i])
                {
                    continue;
                }
                szMsg[i] = m_transportProtocol.AddMsgHead(szMsg[i]);
                byte[] byteMsg = Encoding.Unicode.GetBytes(szMsg[i]);
                try
                {
                    m_networkStream.Write(byteMsg, 0, byteMsg.Length);
                    m_networkStream.Flush();
                }
                catch (System.Exception ex)
                {
                    if (null != m_networkStream)
                    {
                        m_networkStream.Dispose();
                    }
                    m_TcpClient.Close();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 读取完成
        /// </summary>
        /// <param name="ar"></param>
        private void ReadComplete(IAsyncResult ar)
        {
            if (null == m_networkStream || null == m_transportProtocol)
            {
                return;
            }
            int byteRead = 0;
            try
            {
                //lock (m_networkStream)
                //{
                    byteRead = m_networkStream.EndRead(ar);
                //}
                if (0 == byteRead)
                    Console.WriteLine("读取到0字节");
                string szMsg = Encoding.Unicode.GetString(m_buffer, 0, byteRead);
                //清空缓存
                Array.Clear(m_buffer, 0, byteRead);
                string[] szMsgs = m_transportProtocol.RemoveMsgHead(szMsg);
                string szReceiveTarget = "Client";
                if (m_bIsServer)
                {
                    szReceiveTarget = "Server";
                }
                for (int i = 0; i < szMsgs.Length; i++)
                {
                    //打印收到的数据
                    string szTemp = string.Format("{0} Receive Date <{1}> Form RemoteEndPoint {2}",
                        szReceiveTarget, szMsgs[i], m_szRemoteEndPoint);
                    Console.WriteLine(szTemp);
                }
                if (m_bIsServer)
                {
                    //服务器将接收到的字符串转换成大写再发回客户端
                    szMsgs = ToUpper(szMsgs);
                    SentMsg(szMsgs);
                }
                //lock (m_networkStream)
                //{
                    AsyncCallback callBack = new AsyncCallback(ReadComplete);
                    m_networkStream.BeginRead(m_buffer, 0, nBufferSize, callBack, null);
                //}
            }
            catch (System.Exception ex)
            {
                if (null != m_networkStream)
                {
                    m_networkStream.Dispose();
                }
                m_TcpClient.Close();
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 将字母转换成大写
        /// </summary>
        /// <param name="szMsgs"></param>
        /// <returns></returns>
        private static string[] ToUpper(string[] szMsgs)
        {
            for (int i = 0; i < szMsgs.Length; i++)
            {
                szMsgs[i] = szMsgs[i].ToUpper();
            }
            return szMsgs;
        }
    }
}
