using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class AbstractFactoryPattern : PatternBase
    {
        public override void Main()
        {
            //具有广东特色的工厂
            AbstractFactory guangDongFactory = new GuangDongFactory();
            //生产的产品也就具有广东特色
            Product1 guangDongProduct1 = guangDongFactory.CreateProduct1();
            //产品1属性
            guangDongProduct1.ProductDescribe();
            Prodect2 GuangDongProduct2 = guangDongFactory.CreateProduct2();
            GuangDongProduct2.ProductDescribe();

            //具有北京特色的工厂
            AbstractFactory beiJingFactory = new BeiJingFactory();
            Product1 product1 = beiJingFactory.CreateProduct1();
            product1.ProductDescribe();
            Prodect2 product2 = beiJingFactory.CreateProduct2();
            product2.ProductDescribe();
        }

       #region 抽象工厂
       /// <summary>
       /// 产品1
       /// </summary>
       public abstract class Product1
       {
           public abstract void ProductDescribe();
       }
       /// <summary>
       /// 产品2
       /// </summary>
       public abstract class Prodect2
       {
           public abstract void ProductDescribe();
       }

       /// <summary>
       /// 抽象工厂
       /// </summary>
       public abstract class AbstractFactory
       {
           public abstract Product1 CreateProduct1();
           public abstract Prodect2 CreateProduct2();
       }

       /// <summary>
       /// 广东工厂
       /// </summary>
       public class GuangDongFactory : AbstractFactory
       {
           public class GuangDongProduct1 : Product1
           {
               public override void ProductDescribe()
               {
                   Console.WriteLine("广东工厂产品1");
               }
           }

           public class GuangDongProduct2 : Prodect2
           {
               public override void ProductDescribe()
               {
                   Console.WriteLine("广东工厂产品2");
               }
           }

           public override Product1 CreateProduct1()
           {
               return new GuangDongProduct1();
           }

           public override Prodect2 CreateProduct2()
           {
               return new GuangDongProduct2();
           }
       }

       /// <summary>
       /// 北京工厂
       /// </summary>
       public class BeiJingFactory : AbstractFactory
       {
           public class BeiJingProduct1 : Product1
           {
               public override void ProductDescribe()
               {
                   Console.WriteLine("北京工厂产品1");
               }
           }

           public class BeiJingProduct2 : Prodect2
           {
               public override void ProductDescribe()
               {
                   Console.WriteLine("北京工厂产品2");
               }
           }

           public override Product1 CreateProduct1()
           {
               return new BeiJingProduct1();
           }

           public override Prodect2 CreateProduct2()
           {
               return new BeiJingProduct2();
           }
       }
       #endregion
    }  
}
