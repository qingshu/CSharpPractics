using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class BuilderPattern : PatternBase
    {
       public override void Main()
       {
           //具有builder1特色的构造者 
           Builder builder1 = new Builder1();            
           Conductor conductor = new Conductor();
           //统一指挥构造者
           conductor.ConductBuilder(builder1);
           //从构造者中取出构造的对象
           BuildObj buildObj = builder1.GetBuildObj();
           //对象属性
           buildObj.Describe();
       }

        #region 构造者模式
       /// <summary>
       /// 构造的对象
       /// </summary>
       public class BuildObj
       {
           public List<string> strComponent = new List<string>();//构造的组建

           /// <summary>
           /// 为对象添加要构建的组建
           /// </summary>
           /// <param name="szComponent"></param>
           public void AddComponent(string szComponent)
           {
               strComponent.Add(szComponent);
               ShowConponent(szComponent);
           }

           public void ShowConponent(string szComponent)
           {
               Console.WriteLine("目标对象组装中，组建" + szComponent + "已组装");
           }

           public void Describe()
           {
               Console.WriteLine("我是xxx产品");
           }
       }

       /// <summary>
       /// 构造者
       /// </summary>
       public abstract class Builder
       {
           public abstract void BuildComponent1();
           public abstract void BuildComponent2();
           //。。。
           public abstract void BuildComponentN();
           public abstract BuildObj GetBuildObj();
       }

       /// <summary>
       /// 构造者1
       /// </summary>
       public class Builder1 : Builder
       {
           BuildObj buildObj = new BuildObj();
           /// <summary>
           /// 构造组建1
           /// </summary>
           public override void BuildComponent1()
           {
               buildObj.AddComponent("Component1");
           }
           /// <summary>
           /// 构造组建2
           /// </summary>
           public override void BuildComponent2()
           {
               buildObj.AddComponent("Component2");
           }

           //。。。

           /// <summary>
           /// 构造组建N
           /// </summary>
           public override void BuildComponentN()
           {
               buildObj.AddComponent("ComponentN");
           }

           /// <summary>
           /// 返回构造的对象
           /// </summary>
           /// <returns></returns>
           public override BuildObj GetBuildObj()
           {
               return buildObj;
           }
       }

       /// <summary>
       /// 指挥者，统一指挥构造者
       /// </summary>
       public class Conductor
       {
           public void ConductBuilder(Builder builder)
           {
               builder.BuildComponent1();
               builder.BuildComponent2();
               builder.BuildComponentN();
           }
       }
        #endregion
    }   
}
