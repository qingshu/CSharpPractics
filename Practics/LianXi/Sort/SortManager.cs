using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.Sort
{

    public class SortManager : KnowledgeTestBase
    {
        int[]  m_nArrTestNum;
        string m_szBeforeSort;
        SortBase[] m_ArrSortFunction;
        
        public SortManager()
        {
            m_nArrTestNum  = new int[] { 2, 4, 1, 5, 3, 6, 5, 9,7, 23, 11, 78, 43, 88, 34, 2 };
            m_szBeforeSort = "排序前：";
            m_ArrSortFunction = new SortBase[(int)enSort.enSort_Max];
            m_ArrSortFunction[(int)enSort.enSort_Exchange]   = new ExchangeSort();
            m_ArrSortFunction[(int)enSort.enSort_InsertSort] = new InsertSort();
        }
        public override void Test(int nTestID)
        {
            StringBuilder stringBuilderBeforeSort = new StringBuilder();
            stringBuilderBeforeSort.Append(m_szBeforeSort);
            //输出排序前
            Print(stringBuilderBeforeSort, m_nArrTestNum);
            if (nTestID < (int)enSort.enSort_Max)
            {
                //排序
                m_ArrSortFunction[nTestID].Sort(m_nArrTestNum); 
            }
            else
            {
                //执行所有排序方法
                for (int i=0; i < (int)enSort.enSort_Max;i++ )
                {
                    m_ArrSortFunction[i].Sort(m_nArrTestNum); 
                }
            }        
        }
        public void Print(StringBuilder stringBuilder, int[] nArrNum)
        {
            for (int i = 0; i < nArrNum.Length; i++)
            {
                stringBuilder.Append(nArrNum[i]);
                stringBuilder.Append("、");
            }
            stringBuilder.AppendLine("");
            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public abstract class SortBase
    {
        protected int m_nCount;

        public abstract void Sort(int[] nArrNums);

        protected int[] CloneArray(int[] nArrNums)
        {
            int[] arrNums = new int[nArrNums.Length];
            for (int i = 0; i < nArrNums.Length; i++)
            {
                arrNums[i] = nArrNums[i]; 
            }
            return arrNums; 
        }

        protected void Print(string szSort, int[] nArrNum,string szDescribe)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(szSort);
            for (int i = 0; i < nArrNum.Length; i++)
            {
                stringBuilder.Append(nArrNum[i]);
                stringBuilder.Append("、");
            }
            stringBuilder.AppendLine("");
            stringBuilder.Append(szDescribe);
            Console.WriteLine(stringBuilder.ToString());
            TimeComplexity(nArrNum);
        }

        private void TimeComplexity(int[] nArrNum)
        {
            string szEfficiency = string.Format("数组大小：{0}，运行次数：{1}", nArrNum.Length, m_nCount);
            Console.WriteLine(szEfficiency);
            Console.WriteLine("");
            m_nCount = 0;
        }
    }
}
