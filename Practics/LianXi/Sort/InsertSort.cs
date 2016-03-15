using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practics.LianXi.Sort
{
    public class InsertSort : SortBase
    {
        public override void Sort(int[] nArrNums)
        {
            SimpleInsertSort(nArrNums);
        }

        //简单插入排序
        private void SimpleInsertSort(int[] nArrNums)
        {
            int[] arrNum = CloneArray(nArrNums);
            for (int i = 1; i < arrNum.Length; i++)
            {
                int j = i - 1;
                if (arrNum[i] < arrNum[j])
                {
                    int nTemp = arrNum[i];
                    while (j >= 0 && nTemp < arrNum[j])
                    {
                        arrNum[j + 1] = arrNum[j];
                        j--;
                        m_nCount++;
                    }
                    arrNum[j + 1] = nTemp;
                }
            }
            string szDescribe = "当n较小时，或局部或基本有序时，对稳定性有要求时可用插入排序";
            Print("插入排序：", arrNum, szDescribe);
        }


    }
}
