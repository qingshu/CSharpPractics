using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.DesignPatterns
{
    internal class IteratorPattern:PatternBase
    {
        public override void Main()
        {
            ConcreteCollection list = new ConcreteCollection();
            IIterator iterator = list.getIterator();
            while (iterator.IsCanMoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }
        }

        #region 迭代器模式
        /// <summary>
        /// 迭代器接口
        /// </summary>
        public interface IIterator
        {
            bool IsCanMoveNext();
            Object GetCurrent();
            void Next();
            void Reset();
        }

        /// <summary>
        /// 迭代器聚合接口
        /// </summary>
        public interface IListCollection
        {
            int Length { set; get; }
            Object GetElement(int nIndex);
            IIterator getIterator();
        }
        /// <summary>
        /// 具体聚合类
        /// </summary>
        public class ConcreteCollection : IListCollection
        {
            int[] nList;
            public ConcreteCollection()
            {
                nList = new int[] { 2, 4, 6, 8 };
            }

            public int Length { set { value = nList.Length; } get { return nList.Length; } }

            public Object GetElement(int nIndex)
            {
                return nList[nIndex];
            }

            public IIterator getIterator()
            {
                return new ConcreteIterator(this);
            }
        }

        public class ConcreteIterator:IIterator
        {
            IListCollection m_listCollection;
            private int nIndex;
            public ConcreteIterator(IListCollection listCollection)
            {
                m_listCollection = listCollection;
                nIndex = 0;
            }

            public bool IsCanMoveNext()
            {
                if (nIndex >= m_listCollection.Length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public Object GetCurrent()
            {
                return m_listCollection.GetElement(nIndex);
            }

            public void Next()
            {
                nIndex++;
            }
            public void Reset()
            {
                nIndex = 0;
            }
        }
        #endregion
    }
}
