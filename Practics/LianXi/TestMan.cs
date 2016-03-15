using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practics.LianXi.DesignPatterns;
using Practics.LianXi.NetWorkAndThread;
using Practics.LianXi.Sort;

namespace Practics.LianXi
{
    #region 知识点枚举
    //测试知识点
    public enum enKnowledge
    {
        enKnowledge_No=-1,
        enKnowledge_DesignPattern,
        enKnowledge_NetworkAndMultiThread,
        enKnowledge_Sort,
        enKnowledge_Max,
    }

    public enum enSort
    {
        enSort_Exchange,
        enSort_InsertSort,
        enSort_Max,
    }

    //设计模式枚举
    public enum enPattern
    {
        enPattern_None = -1,
        enPattern_SingletonPattern,
        enPattern_SimpleFactoryPattern,
        enPattern_AbstractFactoryPattern,
        enPattern_BuilderPattern,
        enPattern_AdapterPattern,
        enPattern_BrigePattern,
        enPattern_Decorator,
        enPattern_Composite,
        enPattern_FacaePattern,
        enPattern_ProxyPattern,
        enPattern_TemplatePattern,
        enPattern_CommandPattern,
        enPattern_StatePattern,
        enPattern_IteratorPattern,
        enPattern_ObserverPattern,
        enPattern_Max
    }

    #endregion

    public abstract class KnowledgeTestBase
    {
        public abstract void Test(int nTestID);
    }

    public class TestMan
    {
        public KnowledgeTestBase[] m_knowledgeTest;

        public TestMan()
        {
            m_knowledgeTest = new KnowledgeTestBase[(int)enKnowledge.enKnowledge_Max];
            m_knowledgeTest[(int)enKnowledge.enKnowledge_DesignPattern] = new DesignPatternMan();
            m_knowledgeTest[(int)enKnowledge.enKnowledge_NetworkAndMultiThread] = new NetworkAndMultiThread();
            m_knowledgeTest[(int)enKnowledge.enKnowledge_Sort] = new SortManager();
        }

        public void Test(enKnowledge knowledgeID,int nTestID)
        {
            if (knowledgeID > enKnowledge.enKnowledge_No && knowledgeID<enKnowledge.enKnowledge_Max)
            {
                m_knowledgeTest[(int)knowledgeID].Test(nTestID);
            }           
        }
    }
}
