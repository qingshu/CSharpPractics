using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class ObserverPattern:PatternBase
    {
        public override void Main()
        {
            TengXun tengXun = new TengXunGame("TengXunGame", "Have a new game published...");
            Subscriber subscriber1 = new Subscriber("小李");
            Subscriber subscriber2 = new Subscriber("小王");
            tengXun.AddObserver(subscriber1);
            tengXun.AddObserver(subscriber2);
            tengXun.NotifyObservers();           
        }

        #region 观察者模式
        /// <summary>
        /// 订阅号抽象类
        /// </summary>
        public abstract class TengXun
        {
            public List<IObserver> listIObserver = new List<IObserver>();
            public string szSymbol { set; get; }
            public string szInfo   { set; get; }
            public TengXun(string szSymbol,string szInfo)
            {
                this.szSymbol = szSymbol;
                this.szInfo   = szInfo;
            }
            //增加观察者
            public void AddObserver(IObserver observer)
            {
                listIObserver.Add(observer);
            }
            //删除观察者
            public void RemoveObserver(IObserver observer)
            {
                listIObserver.Remove(observer);
            }
            //通知所有订阅者
            public void NotifyObservers()
            {
                foreach (IObserver observer in listIObserver)
                {
                    observer.ReceiveAndPrint(this);
                }
            }
        }
        /// <summary>
        /// 订阅者接口
        /// </summary>
        public interface IObserver
        {
            void ReceiveAndPrint(TengXun tengXun);
        }

        /// <summary>
        /// 具体订阅号
        /// </summary>
        public class TengXunGame : TengXun
        {
            public TengXunGame(string szSymbol,string szInfo):base(szSymbol,szInfo)
            {
            
            }
        }
        /// <summary>
        /// 具体订阅者
        /// </summary>
        public class Subscriber : IObserver
        {
            public string szName { set; get; }
            public Subscriber(string szName)
            {
                this.szName = szName;
            }

            public void ReceiveAndPrint(TengXun tengXun)
            {
                Console.WriteLine("Notifyed {0} of {1}'s ,Info is {2}", szName, tengXun.szSymbol, tengXun.szInfo);
            }
        }
        #endregion
    }
}
