using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practics.LianXi.NetWorkAndThread
{
    //自定义传输协议
    public class TransportProtocol
    {
        private string m_szTemp = String.Empty;

        /// <summary>
        /// 添加消息头
        /// </summary>
        /// <param name="szMsg"></param>
        /// <returns></returns>
        public string AddMsgHead(string szMsg)
        {
            return string.Format("[length={0}]{1}", szMsg.Length, szMsg);
        }

        /// <summary>
        /// 去除消息头，返回实际字符串数组
        /// </summary>
        /// <param name="szMsg">一串消息</param>
        /// <returns></returns>
        public string[] RemoveMsgHead(string szMsg)
        {
            return GetActualString(szMsg, null);
        }

        /// <summary>
        /// 获取字符串数组
        /// </summary>
        /// <param name="szInput"></param>
        /// <param name="outputSZList"></param>
        /// <returns></returns>
        private string[] GetActualString(string szInput, List<string> outputSZList)
        {
            if (null == outputSZList)
            {
                outputSZList = new List<string>();
            }
            if (!String.IsNullOrEmpty(m_szTemp))
            {
                szInput = m_szTemp + szInput;
                m_szTemp = "";
            }
            string szPattern = @"(?<=^\[length=)(\d+)(?=\])";
            if (Regex.IsMatch(szInput, szPattern))
            {
                Match m = Regex.Match(szInput, szPattern);
                int nLength = int.Parse(m.Groups[0].Value);
                int nStartIndex = szInput.IndexOf(']') + 1;
                //去掉“消息头”
                string szOutput = szInput.Substring(nStartIndex);
                if (szOutput.Length == nLength)
                {
                    outputSZList.Add(szOutput);
                }
                else if (szOutput.Length < nLength)
                {
                    m_szTemp = szInput;
                }
                else
                {
                    szOutput = szOutput.Substring(0, nLength);
                    outputSZList.Add(szOutput);
                    szInput = szInput.Substring(nStartIndex + nLength);
                    GetActualString(szInput, outputSZList);
                }
            }
            else
            {
                m_szTemp = szInput;
            }
            return outputSZList.ToArray();
        }
    }
}
