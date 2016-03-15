using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
   internal class CompositePattern:PatternBase
    {
       public override void Main()
       {
           Console.WriteLine("<----------------------------->");
           Graphics line = new Line("直线");
           line.Draw();
           Console.WriteLine("<----------------------------->");
           Graphics circle = new Circle("圆圈");
           circle.Draw();
           Console.WriteLine("<----------------------------->");
           Graphics graphics = new CompositeGraphics("复合图形");
           graphics.AddGraphics(line);
           graphics.AddGraphics(circle);
           graphics.Draw();

           Console.WriteLine("<----------------------------->");
           graphics.RemoveGraphics(line);
           graphics.Draw();
       }

        #region 组合模式
       /// <summary>
       /// 抽象类，另外一种是只保留其所有的派生类公用的方法Draw，另外增删去掉，只写在派生CompositeGraphics类中
       /// </summary>
       public abstract class Graphics
       {
           public string szName { get; set; }
           public Graphics(string szName)
           {
               this.szName = szName;
               Console.WriteLine("新建" + szName);
           }
           public abstract void AddGraphics(Graphics graphics);
           public abstract void RemoveGraphics(Graphics graphics);
           public abstract void Draw();
       }

       public class Line : Graphics
       {
           public Line(string szName)
               : base(szName)
           {
           
           }
           public override void AddGraphics(Graphics graphics)
           {
               throw new NotImplementedException();
           }
           public override void RemoveGraphics(Graphics graphics)
           {
               throw new NotImplementedException();
           }
           public override void Draw()
           {
               Console.WriteLine("画直线");
           }
       }

       public class Circle : Graphics
       {
           public Circle(string szName)
               : base(szName)
           {
           }
           public override void AddGraphics(Graphics graphics)
           {
               throw new NotImplementedException();
           }
           public override void RemoveGraphics(Graphics graphics)
           {
               throw new NotImplementedException();
           }
           public override void Draw()
           {
               Console.WriteLine("画圆圈");
           }
       }

       public class CompositeGraphics : Graphics
       {
           public List<Graphics> listGraphics = new List<Graphics>();

           public CompositeGraphics(string szName)
               : base(szName)
           {
           
           }

           public override void AddGraphics(Graphics graphics)
           {
               Console.WriteLine("在复合图形中添加" + graphics.szName);
               listGraphics.Add(graphics);
           }

           public override void RemoveGraphics(Graphics graphics)
           {
               Console.WriteLine("删除复合图形中的" + graphics.szName);
               listGraphics.Remove(graphics);
           }

           public override void Draw()
           {
               Console.WriteLine("画复合图形：");
               foreach (Graphics graphics in listGraphics)
               {
                   graphics.Draw();
               }
           }
       }
        #endregion
    }
}
