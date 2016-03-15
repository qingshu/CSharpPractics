using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class DecoratorPattern:PatternBase
    {
       /// <summary>
        /// 装饰者模式，特点是抽象类定义功能方法签名，并分别派生出具体派生类和装饰者抽象类，
        /// 且装饰者抽象类在重写方法中调用父类方法（由多态其实是调用具体派生类方法），
        /// 而在装饰者派生类重写方法中也调用父类方法并添加新行为，新的行为就是装饰行为。
       /// </summary>
       public override void Main()
       {
           Console.WriteLine("<------------------------->");
           //贴膜
           Phone phone = new ApplePhone();
           Decorator tieMo = new TieMo(phone);
           tieMo.Print();
           Console.WriteLine("<------------------------->");
           //加挂件
           Decorator guaJian = new GuaJian(phone);
           guaJian.Print();
           Console.WriteLine("<------------------------->");
           //三星手机既有挂件又贴膜
           phone = new SuamgPhone();
           guaJian = new GuaJian(phone);
           tieMo = new TieMo(guaJian);       
           tieMo.Print();
       }

        #region 装饰者模式
       public abstract class Phone
       {
           public abstract void Print();
        }

       public class ApplePhone:Phone
       {
           public override void Print()
           {
               Console.WriteLine("我是苹果手机");
           }
       }

       public class SuamgPhone : Phone
       {
           public override void Print()
           {
               Console.WriteLine("我是三星手机");
           }
       }

       public abstract class Decorator : Phone
       {
           private Phone m_phone;

           public Decorator(Phone phone)
           {
               m_phone = phone;
           }

           public override void Print()
           {
               if (m_phone!=null)
               {
                   m_phone.Print();
               }
           }
       }

       public class TieMo : Decorator
       {
           public TieMo(Phone phone):base(phone)
           {
           
           }

           public override void Print()
           {
               base.Print();
               AddTieMo();
           }

           /// <summary>
           /// 额外的贴膜（装饰行为）
           /// </summary>
           public void AddTieMo()
           {
               Console.WriteLine("贴膜");
           }
       }

       public class GuaJian : Decorator
       {
           public GuaJian(Phone phone)
               : base(phone)
           {
           
           }

           public override void Print()
           {
               base.Print();
               AddGuaJian();
           }

           public void AddGuaJian()
           {
               Console.WriteLine("增加挂件");
           }
       }
        #endregion
    }
}
