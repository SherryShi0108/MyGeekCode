/*******************************************************************************************************************************
 *
 * 1. 实现一个支持动态扩容的数组
 * 2. 实现一个大小固定的有序数组，支持动态增删改操作
 * 3. 实现两个有序数组合并为一个有序数组
 * 
 *******************************************************************************************************************************/

#region 1. 实现一个支持动态扩容的数组

using System;

class DynamicArray<T>
{
    private T[] TArray;
    private int length ;
    private int size = 0;

    /* 无参构造 */
    public DynamicArray()
    {
        length = 10;
        TArray=new T[length];
    }

    /* 指定大小 */
    public DynamicArray(int capacity)
    {
        length = capacity;
        TArray = new T[capacity];
    }

    /* 获取当前数组容量 */
    public int GetCapacity()
    {
        return length;
    }

    /* 获取当前数组大小 */
    public int ArrayCount()
    {
        return size;
    }

    /* 插入数组 */
    public void InsertArray(int index,T item)
    {
        CheckIndex(index);

        //如果当前元素数==数组容量，那么就扩容2倍
        if (size == length)
        {
            length *= 2;
            T[] newData=new T[length];
            for (int i = 0; i < size; i++)
            {
                newData[i] = TArray[i];
            }

            TArray = newData;
        }

        for (int i = size; i > index; i--)
        {
            TArray[i] = TArray[i - 1];
        }

        TArray[index] = item;
        size++;
    }

    /* 插入头部元素 */
    public void InsertFirst(T item)
    {
        InsertArray(0, item);
    }

    /* 插入尾部元素 */
    public void InsertLast(T item)
    {
        InsertArray(size, item);
    }

    /* 删除当前位置元素，并返回 */
    public T DeleteArray(int index)
    {
        CheckIndex(index);
        T ret = TArray[index];
        for (int i = index+1; i < size; i++)
        {
            TArray[i - 1] = TArray[i];
        }

        size--;

        //缩容
        if (size < length / 4)
        {
            T[] newData = new T[length/2];
            for (int i = 0; i < size; i++)
            {
                newData[i] = TArray[i];
            }

            TArray = newData;
        }
        return ret;
    }

    /* 删除头部元素 */
    public T DeleteFirst()
    {
        return  DeleteArray(0);
    }

    /* 删除尾部元素 */
    public T DeleteLast()
    {
        return DeleteArray(size - 1);
    }

    /* 修改当前位置元素 */
    public void UpdateArray(int index, T item)
    {
        CheckIndex(index);
        TArray[index] = item;
    }

    /* 查找对应下标的元素 */
    public T QueryArray(int index)
    {
        CheckIndex(index);
        return TArray[index];
    }

    /* 查找相应元素下标 */
    public int Query(T item)
    {
        for (int i = 0; i < size; i++)
        {
            if (TArray[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    /* 判断对应元素是否存在 */
    public bool ContainsArray(T item)
    {
        for (int i = 0; i < size; i++)
        {
            if (TArray[i].Equals(item))
            {
                return true;
            }
        }

        return false;
    }

    /* 检查下标是否正确 */
    public void CheckIndex(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new ArgumentNullException("index is out of control");
        }
    }

}

#endregion

#region 2. 实现一个大小固定的有序数组，支持动态增删改操作

class RigidArray<T> 
{
    private T[] array;
    private int length;
    private int count;

    public RigidArray(int n)
    {
        length = n;
        array=new T[length];
        count = 0;
    }

    public bool Insert(int index, T value)
    {
        if (count == length)
        {
            return false;
        }

        if (index < 0 || index > count)
        {
            return false;
        }

        for (int i = count; i >index ; i--)
        {
            array[i] = array[i - 1];
        }

        array[index] = value;
        count++;
        return true;
    }

    public bool Delete(int index)
    {
        if (index < 0 || index >= count)
        {
            return false;
        }

        for (int i = index; i < count; i++)
        {
            array[i] = array[i + 1];
        }

        count--;
        return true;
    }

    public bool Update(int index,T value)
    {
        if (index < 0 || index >= count)
        {
            return false;
        }

        array[index] = value;
        return true;
    }

    public T Find(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new Exception("Out Size");
        }

        return array[index];
    }
}

#endregion

#region 3. 实现两个有序数组合并为一个有序数组

class MyClass3
{
    public int[] AddArray(int[] A, int[] B)
    {
        int[] result = new int[A.Length + B.Length];
        int k = 0;

        int i = 0, j = 0;
        while (i < A.Length && j < B.Length)
        {
            if (A[i] > B[j])
            {
                result[k++] = B[j++];
            }
            else
            {
                result[k++] = A[i++];
            }
        }

        while (k < result.Length)
        {
            if (i == A.Length)
            {
                result[k++] = B[j++];
            }
            else
            {
                result[k++] = A[i++];
            }
        }

        return result;
    }
}

#endregion
