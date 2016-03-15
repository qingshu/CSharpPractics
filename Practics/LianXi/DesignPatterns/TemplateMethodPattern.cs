using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class TemplateMethodPattern:PatternBase
    {
       public override void Main()
       {
           CCookFoods cookFoods = new CCookSpinach();
           cookFoods.CookFoods();
       }

        #region 模板方法模式
        public abstract class CCookFoods
        {
            public void CookFoods()
            {
                Wash();
                PushOil();
                PourFood();
                Cook();
            }
            /// <summary>
            /// 洗菜
            /// </summary>
            public abstract void Wash();
            public void PushOil()
            {
                Console.WriteLine("倒油");
            }
            /// <summary>
            /// 倒菜
            /// </summary>
            public abstract void PourFood();

            public void Cook()
            {
                Console.WriteLine("翻炒");
            }
        }
        /// <summary>
        /// 煮菠菜
        /// </summary>
        public class CCookSpinach:CCookFoods
        {
            public override void Wash()
            {
                Console.WriteLine("洗菠菜");
            }
            public override void PourFood()
            {
                Console.WriteLine("倒入菠菜");
            }
        }
        #endregion
    }
}
