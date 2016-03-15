using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.Sort
{
    //交换排序
    public class ExchangeSort : SortBase
    {
        public override void Sort(int[] nArrNums)
        {
            BubbleSort(nArrNums);
            BubbleSortImprove1(nArrNums);
            BubbleSortImprove2(nArrNums);
            int[] arrNums = CloneArray(nArrNums);
            FastSort(arrNums, 0, arrNums.Length - 1);
            string szDescribe = "当n较大时，元素比较随机，对稳定性没要求宜用快速排序";
            Print("快速排序：", arrNums, szDescribe);
        }
        //交换两个数
        private void Swap(ref int nFirst,ref int nSecond)
        {
            int nTemp = nFirst;
            nFirst = nSecond;
            nSecond = nTemp;
        }

        #region 冒泡排序
        //冒泡排序
        private void BubbleSort(int[] ArrNums)
        {
            int[] nArrNums = CloneArray(ArrNums);
            for (int i = 0; i < nArrNums.Length - 1; i++)
            {
                for (int j = 0; j < nArrNums.Length - i - 1; j++)
                {
                    if (nArrNums[j] > nArrNums[j + 1])
                    {
                        Swap(ref nArrNums[j],ref nArrNums[j + 1]);
                    }
                    m_nCount++;
                }
            }
            string szDescribe = "当n较小时，对稳定性有要求时可用冒泡排序";
            Print("冒泡排序：", nArrNums, szDescribe);
        }

        //冒泡排序
        private void BubbleSortImprove1(int[] ArrNums)
        {
            int[] nArrNums = CloneArray(ArrNums);
            bool bIsExchange = false;
            for (int i = 0; i < nArrNums.Length - 1; i++)
            {
                for (int j = 0; j < nArrNums.Length - i - 1; j++)
                {
                    if (nArrNums[j] > nArrNums[j + 1])
                    {
                        bIsExchange = true;
                        Swap(ref nArrNums[j], ref nArrNums[j + 1]);
                    }
                    m_nCount++;
                }
                if (!bIsExchange)
                {
                    //没有交换则退出
                    break;
                }
            }
            string szDescribe = "改进思路1：设置标志位，如果有一趟没有发生交换，说明排序已经完成";
            Print("冒泡排序：", nArrNums, szDescribe);
        }

        private void BubbleSortImprove2(int[] arrNums)
        {
            int[] nArrNums = CloneArray(arrNums);
            int i = nArrNums.Length - 1;
            while (i > 0)
            {
                int nPos = 0;
                for (int j = 0; j < i;j++ )
                {
                    if (nArrNums[j] > nArrNums[j + 1])
                    {
                        nPos = j;
                        Swap(ref nArrNums[j],ref nArrNums[j + 1]);
                    }
                    m_nCount++;
                }
                i = nPos;
            }
            string szDescribe = "改进思路2：设置一标志性变量pos,用于记录每趟排序中最后一次进行交换的位置。由于pos位置之后的记录均已交换到位,故在进行下一趟排序时只要扫描到pos位置即可。";
            Print("冒泡排序：", nArrNums, szDescribe);
        }
        #endregion

        #region 快速排序
        //快速排序
        private void FastSort(int[] nArrNums, int nStartIndex, int nEndIndex)
        {
            if (nEndIndex > nStartIndex)
            {
                int nDivision = SortOnce(nArrNums, nStartIndex, nEndIndex);
                //递归快排左边块
                FastSort(nArrNums, nStartIndex, nDivision - 1);
                //递归快排右边块
                FastSort(nArrNums, nDivision + 1, nEndIndex);              
            }            
        }

        private int SortOnce(int[] nArrNums,int nLeftIndex,int nRightIndex)
        {
            int nBenchmark = nArrNums[nLeftIndex];
            while (nLeftIndex < nRightIndex)
            {
                //左移右指针，与基准比较，直到找到小于基准数
                while (nArrNums[nRightIndex] > nBenchmark && nRightIndex > nLeftIndex)
                {
                    --nRightIndex;
                    m_nCount++;
                }
                Swap(ref nArrNums[nLeftIndex], ref nArrNums[nRightIndex]);
                //右移左指针，与基准比较，直到找到大于基准数
                while (nArrNums[nLeftIndex] <= nBenchmark && nRightIndex > nLeftIndex)
                {
                    ++nLeftIndex;
                    m_nCount++;
                }
                Swap(ref nArrNums[nRightIndex], ref nArrNums[nLeftIndex]);
            }
            return nLeftIndex;
        }
        #endregion
    }
}
