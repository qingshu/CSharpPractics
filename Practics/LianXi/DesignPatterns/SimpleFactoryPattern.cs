using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class SimpleFactoryPattern : PatternBase
    {
        public override void Main()
        {
            SimpleFactory simpleFactory = new SimpleFactory();
            Food food= simpleFactory.CreateFood(FoodType.FoodType_Meat);
            food.foodDescribe();
        }

        #region 简单工厂模式(烧菜为例)

        public abstract class Food
        {
            public abstract void foodDescribe();
        }

        public enum FoodType
        {
            FoodType_Vegetable,
            FoodType_Meat,
            FoodType_Max
        }

        public class Vegetable : Food
        {
            public override void foodDescribe()
            {
                Console.WriteLine("我是蔬菜");
            }
        }

        public class Meat : Food
        {
            public override void foodDescribe()
            {
                Console.WriteLine("我是肉类");
            }
        }

        public class SimpleFactory
        {
            public Food CreateFood(FoodType foodtype)
            {
                switch (foodtype)
                {
                    case FoodType.FoodType_Vegetable:
                        return new Vegetable();
                    case FoodType.FoodType_Meat:
                        return new Meat();
                    default:
                        return null;
                }
            }
        }
        #endregion
    }
}
