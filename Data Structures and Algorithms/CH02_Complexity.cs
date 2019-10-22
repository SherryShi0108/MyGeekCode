/*******************************************************************************************************************************
 *
 * 1. 复杂度初步理解估算
 * 2. 时间复杂度分析实例 / 空间复杂度分析实例
 * 3. 复杂的实例分析
 * 
 *******************************************************************************************************************************/

using System;

namespace Data_Structures_and_Algorithms
{
    #region 1. 复杂度初步理解估算

    class TestClass1
    {
        //功能：1-n累加。 时间复杂度分析：假设每行代码执行时间一样为unit_time，那么总执行时间（2n+2）*unit_time
        int Cal(int n)
        {
            int sum = 0;
            int i = 1;
            for (; i <= n; i++)
            {
                sum += i;
            }

            return sum;
        }

        //时间复杂度分析：2n^2+2n+3
        int Cal2(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    sum += i * j;
                }
            }

            return sum;
        }

        //时间复杂度分析：只关心量级最大的那个，即O(1) O(n) O(n^2)，最后这段代码时间复杂度为O(n^2)
        int Cal3(int n)
        {
            int sum1 = 0;
            for (int i = 0; i <= 100; i++)
            {
                sum1+=i;
            }

            int sum2 = 0;
            for (int i = 0; i <= n; i++)
            {
                sum2 += i;
            }

            int sum3 = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <=n; j++)
                {
                    sum3 += i * j;
                }
            }

            return sum1 + sum2 + sum3;
        }

        //时间复杂度分析：嵌套就相乘，时间复杂度为O(n^2)
        int Cla4(int n)
        {
            int ret = 0;
            for (int i = 0; i < n; i++)
            {
                ret += f(i);
            }

            return ret;
        }

        int f(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }

            return sum;
        }
    }

    #endregion

    #region  2. 时间复杂度分析实例 / 空间复杂度分析实例

    class TestClass2
    {
        //时间复杂度分析：2^x=n,n=log2 n,同理log3 n,但是由于对数换底公式，我们可以把所有对数表示的统称为logn
        void Test1(int n)
        {
            int i = 1;
            while (i<=n)
            {
                i = i * 2;
            }
        }
    }

    class TestClass3
    {
        //空间复杂度：O(n)
        void Print(int n)
        {
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = i * i;
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Console.WriteLine(a[i]);
            }
        }
    }

    #endregion

    #region 3. 复杂的实例分析

    class TestClass4
    {
        //无序数组中查询，是O(n)
        int Find(int[] nums, int x)
        {
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == x)
                {
                    index = i;
                }
            }

            return index;
        }

        //优化后代码分析：最好O(1),最坏O(n)，平均O(n)
        int Find2(int[] nums, int x)
        {
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == x)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }

    class TestClass5
    {
        private int[] array;
        private int count = 0;

        public TestClass5(int n)
        {
            array = new int[n];
        }

        //复杂度分析：最好O(1)，最坏O(n)，平均O(1)
        //均摊分析：由于大部分情况下是O(1)，极少数O(n)，且一个O(n)跟着n个O(1)，所以用摊还分析得均摊时间复杂度为O(1)
        void Insert(int val)
        {
            if (count == array.Length)
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }

                array[0] = sum;
                count = 1;
            }

            array[count] = val;
            count++;
        }
    }

    class TestClass6
    {
        private int[] array;
        private int len;
        private int i = 0;
        public TestClass6(int n)
        {
            array = new int[n];
            len = n;
        }

        //摊还分析：n个O(1)后跟着一个O(n)，所以是O(1)
        void Add(int x)
        {
            if (i >= len)
            {
                int[] newArray = new int[2 * len];
                for (int j = 0; j < len; j++)
                {
                    newArray[j] = array[i];
                }

                array = newArray;
                len *= 2;
            }

            array[i] = x;
            i++;
        }
    }

    #endregion
}