using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class SingletonPattern : PatternBase
    {
        public override void Main()
        {
            Singleton.Instance.SetSZ();
            Singleton.Instance.Test();
            Singleton.Instance.SetSZ("I am Singleton");
            Singleton.Instance.Test();
            Singleton.Instance.Test();
        }

        #region 单例模式
        public class Singleton
        {
            private static Singleton m_instance;
            //定义一个标志确保线程同步
            private static readonly object locker = new object();
            public static Singleton Instance
            {
                get
                {
                    lock(locker)
                    {
                        if (null == m_instance)
                       {
                           m_instance = new Singleton();
                       }
                    }
                    return m_instance;
                }
            }
            private string m_szTest;

            public void SetSZ(string szTest = "我是单例")
            {
                m_szTest = szTest;
            }

            public void Test()
            {
                Console.WriteLine(m_szTest);
            }

        }
        #endregion
    }
}
