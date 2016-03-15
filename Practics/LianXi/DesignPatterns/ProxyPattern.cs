using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class ProxyPattern:PatternBase
    {
       /// <summary>
       /// 代理模式，定义一个抽象主题角色，再由派生的代理主题调用其他派生（真实主题）角色主题，
       /// 从而保护和管理真实角色。
       /// </summary>
       public override void Main()
       {
           Person proxy = new ProxyPerson();
           proxy.BuyGoods();
       }

        #region 代理模式
        //抽象主题角色
       public abstract class Person
       {
           /// <summary>
           /// 抽象主题
           /// </summary>
           public abstract void BuyGoods();
       }

       /// <summary>
       /// 真实主题角色
       /// </summary>
       public class LiSan : Person
       {
           public override void BuyGoods()
           {
               Console.WriteLine("帮我买一部IPhone4");
           }
       }

       /// <summary>
       /// 代理主题角色
       /// </summary>
       public class ProxyPerson : Person
       {
           private LiSan m_LiSan;

           public ProxyPerson()
           {
               m_LiSan = new LiSan();
           }

           /// <summary>
           /// 代理角色，可以对真实主题进行一些操作，如验证等。
           /// </summary>
           public override void BuyGoods()
           {
               //购买前的准备
               BuyGoodsPrepare();
               m_LiSan.BuyGoods();
               //买完后的操作
               BuyGoodsAfterOp();
           }

           /// <summary>
           /// 买东西前的准备
           /// </summary>
           private void BuyGoodsPrepare()
           {
               Console.WriteLine("记下所有代理的清单，帮小李买电脑、小张买彩电，小三买IPhone4,...");
           }

           /// <summary>
           /// 买完后的操作
           /// </summary>
           private void BuyGoodsAfterOp()
           {
               Console.WriteLine("对买的东西进行一下统计，小李的电脑是要邮件的，小张的彩电他自己来取，小三的。。。");
           }
       }
        #endregion
    }
}
