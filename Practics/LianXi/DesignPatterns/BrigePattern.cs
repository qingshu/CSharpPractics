using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class BrigePattern:PatternBase
    {
       public override void Main()
       {
           YaoKongQi kangJia = new KangJiaYaoKongQi();
           kangJia.m_TV = new KangJia();
           kangJia.TurnOn();
           kangJia.TurnOff();
           kangJia.SwitchChannel();

           YaoKongQi TCL = new YaoKongQi();
           TCL.m_TV = new TCL();
           TCL.TurnOn();
           TCL.TurnOff();
           TCL.SwitchChannel();
       }

        #region 桥接模式
       public abstract class TV
       {
           public abstract void TurnOn();
           public abstract void TurnOff();
           public abstract void SwitchChannel();
       }

       public class YaoKongQi
       {
           private TV m_tv;

           public TV m_TV
           {
               set { m_tv = value; }
               get { return m_tv ; }
           }

           public virtual void TurnOn()
           {
               m_tv.TurnOn();
           }

           public virtual void TurnOff()
           {
               m_tv.TurnOff();
           }

           public virtual void SwitchChannel()
           {
               m_tv.SwitchChannel();
           }
        }
        
       public class KangJiaYaoKongQi:YaoKongQi
       {         
           public override void SwitchChannel()
           {
               Console.WriteLine("我是康佳遥控器,换台");
           }

           //KangJia kangJia = new KangJia();
           //public void TurnBackLastChannel()
           //{
           //    kangJia.TurnBackLastChannel();
           //}
       }

       public class KangJia : TV
       {
           public override void TurnOn()
           {
               Console.WriteLine("打开康佳电视机");
           }

           public override void TurnOff()
           {
               Console.WriteLine("关闭康佳电视机");
           }

           public override void SwitchChannel()
           {
               Console.WriteLine("康佳电视机换台");
           }

           //public void TurnBackLastChannel()
           //{
           //    Console.WriteLine("返回上一个台");
           //}
       }

       public class TCL : TV
       {
           public override void TurnOn()
           {
               Console.WriteLine("打开TCL电视机");
           }

           public override void TurnOff()
           {
               Console.WriteLine("关闭TCL电视机");
           }

           public override void SwitchChannel()
           {
               Console.WriteLine("TCL电视机换台");
           }
       }
        #endregion
    }
}
