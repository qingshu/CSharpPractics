using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class AdapterPattern : PatternBase
    {
        public override void Main()
        {
            //三个孔的接口却能调用两个孔的插口
            Console.WriteLine("类适配器");
            ICThreeHole threeHole = new CHoleApapter();
            threeHole.Request();

            Console.WriteLine("对象适配器");
            IOThreeHole othreeHole = new OHoleAdapter();
            othreeHole.Request();
        }
        #region 适配器模式

        #region 类适配器
        /// <summary>
        /// 新的环境需要三个孔的插口，但却只有两个孔的插口
        /// </summary>
        public interface ICThreeHole
        {
            void Request();
        }
        /// <summary>
        /// 两个孔的插口，需要适配器供需三个孔的对象使用
        /// </summary>
        public class CTwoHole
        {
            public void TwoHoleRequest()
            {
                Console.WriteLine("我是两个孔的插口");
            }
        }

        public class CHoleApapter : CTwoHole, ICThreeHole
        {
            public void Request()
            {
                this.TwoHoleRequest();
            }
        }
        #endregion

        #region 对象适配器
        public interface IOThreeHole
        {
            void Request();
        }
        public class OTwoHole
        {
            public void TwoHoleRequest()
            {
                Console.WriteLine("我是两个孔的插口");
            }
        }
        public class OHoleAdapter : IOThreeHole
        {
            OTwoHole twoHole = new OTwoHole();
            public void Request()
            {
                twoHole.TwoHoleRequest();
            }
        }
        #endregion

        #endregion
    }
}
