using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    /// <summary>
    /// 设计模式基类
    /// </summary>
    public abstract class PatternBase
    {
        public abstract void Main();
    }

    /// <summary>
    /// 设计模式管理类
    /// </summary>
    public class DesignPatternMan : KnowledgeTestBase
    {       
        private PatternBase[] m_DesignPatterns ;
        private string     [] m_szPatterns;

        public DesignPatternMan()
        {
            int nPatternCount   = (int)enPattern.enPattern_Max;
            m_DesignPatterns    = new PatternBase[nPatternCount];
            m_DesignPatterns[(int)enPattern.enPattern_SingletonPattern]       = new SingletonPattern();
            m_DesignPatterns[(int)enPattern.enPattern_SimpleFactoryPattern]   = new SimpleFactoryPattern();
            m_DesignPatterns[(int)enPattern.enPattern_AbstractFactoryPattern] = new AbstractFactoryPattern();
            m_DesignPatterns[(int)enPattern.enPattern_BuilderPattern]         = new BuilderPattern();
            m_DesignPatterns[(int)enPattern.enPattern_AdapterPattern]         = new AdapterPattern();
            m_DesignPatterns[(int)enPattern.enPattern_BrigePattern]           = new BrigePattern();
            m_DesignPatterns[(int)enPattern.enPattern_Decorator]              = new DecoratorPattern();
            m_DesignPatterns[(int)enPattern.enPattern_Composite]              = new CompositePattern();
            m_DesignPatterns[(int)enPattern.enPattern_FacaePattern]           = new FacadePattern();
            m_DesignPatterns[(int)enPattern.enPattern_ProxyPattern]           = new ProxyPattern();
            m_DesignPatterns[(int)enPattern.enPattern_TemplatePattern]        = new TemplateMethodPattern();
            m_DesignPatterns[(int)enPattern.enPattern_CommandPattern]         = new CommandPattern();
            m_DesignPatterns[(int)enPattern.enPattern_StatePattern]           = new StatePattern();
            m_DesignPatterns[(int)enPattern.enPattern_IteratorPattern]        = new IteratorPattern();
            m_DesignPatterns[(int)enPattern.enPattern_ObserverPattern]        = new ObserverPattern();

            m_szPatterns = new string[nPatternCount];
            m_szPatterns[(int)enPattern.enPattern_SingletonPattern]       = "单例模式，特点是全局只能获取一个类对象。\n";
            m_szPatterns[(int)enPattern.enPattern_SimpleFactoryPattern]   = "简单工厂模式,特点是工厂直接生产产品，并返回具有不同特性的产品（有多态实现）。";
            m_szPatterns[(int)enPattern.enPattern_AbstractFactoryPattern] = "抽象工厂模式，相比于简单工厂，产品由工厂子类的具体工厂生产，并返回具有不同工厂特性的产品。";
            m_szPatterns[(int)enPattern.enPattern_BuilderPattern]         = "构造者模式，特点是构造者提供构造方法和返回构造对象，但不主动构造，而是由指挥者统一控制具有不同特性的构造者并通过调用构造者的“模块”组装函数进行构造。";
            m_szPatterns[(int)enPattern.enPattern_AdapterPattern]         = "适配器模式，特点是需适配的接口方法在派生类实现方法中调用已有的目标类方法，类适配是调用父类方法，对象适配是调用目标类对象方法。";
            m_szPatterns[(int)enPattern.enPattern_BrigePattern]           = "桥接模式，遥控器为例，通过“遥控”抽象的TV,间接地遥控具体的TV";
            m_szPatterns[(int)enPattern.enPattern_Decorator]              = "装饰者模式，特点是通过多态，对派生自抽象类的方法，通过装饰者类为其添加额外的行为。";
            m_szPatterns[(int)enPattern.enPattern_Composite]              = "组合模式，以图形组合为例，简单图形和复杂图形都平等的继承于抽象图形接口，通过重写父类图形操作接口以达到对图形组合、删除、以及画图操作。";
            m_szPatterns[(int)enPattern.enPattern_FacaePattern]           = "外观模式，对相关的各个功能系统统一用一个类封装管理，再供客户端调用，降低了客户端与各个系统的耦合。";
            m_szPatterns[(int)enPattern.enPattern_ProxyPattern]           = "代理模式，定义统一的抽象主题角色，再由派生的代理角色主题调用其他派生角色主题，对客户端只提供代理接口，从而对真实主题进行封装和对客户端解耦。";
            m_szPatterns[(int)enPattern.enPattern_TemplatePattern]        = "模板方法模式，在基类方法中定义方法流程，把要更改的方法定义为虚或抽象方法供派生类重写，其他流程方法为普通方法。";
            m_szPatterns[(int)enPattern.enPattern_CommandPattern]         = "命令模式，命令发布者角色=》抽象命令《=具体命令=》命令接收者角色以及客户端调用;";
            m_szPatterns[(int)enPattern.enPattern_StatePattern]           = "状态模式，如果一种操作会涉及到多种状态，且每种状态不同行为，则可定义一个抽象状态类，通过内部条件切换不同状态从而实现不同的操作";
            m_szPatterns[(int)enPattern.enPattern_IteratorPattern]        = "迭代器模式，定义迭代对象接口和迭代容器接口，由迭代器访问容器中的元素模式，所有继承该迭代器接口的对象都可采用迭代访问元素";
            m_szPatterns[(int)enPattern.enPattern_ObserverPattern]        = "观察者模式，定义抽象订阅号和抽象观察者接口，由订阅号管理观察者，由多态转移到派生（具体）订阅号向派生（具体）观察者发消息。";
        }

        /// <summary>
        /// 测试设计模式
        /// </summary>
        /// <param name="nPattern"></param>
        public override void Test(int nPattern)
        {
            if (nPattern >= 0 && nPattern < m_DesignPatterns.Length)
            {
                Console.WriteLine("现在执行的是" + m_szPatterns[nPattern]);
                m_DesignPatterns[nPattern].Main();
            }
            else
            {
                Console.WriteLine("当前知识点下的所有内容如下，请输入索引测试：");
                for (int i = 0; i < m_szPatterns.Length;i++ )
                {
                    Console.WriteLine(i.ToString()+":"+m_szPatterns[i]);
                }
            }
        }
    }
}
