/*******************************************************************************************************************************
 *
 * 1. 封装示例代码
 * 2. 抽象示例代码
 * 3. 继承示例代码
 * 4. 多态示例代码1——继承+方法重写
 * 5. 多态示例代码2——接口类语法
 *
 *******************************************************************************************************************************/

using System;

#region 1. 封装示例代码

public class Wallet
{
    private string Id;
    private DateTime CreatTime;
    private decimal Balance;
    private DateTime BalanceLastModifiedTime;

    public Wallet()
    {
        //传入数据库已有数据
        this.Id = "";
        this.CreatTime = System.DateTime.Now;
        this.Balance = decimal.Zero;
        this.BalanceLastModifiedTime = new DateTime();
    }

    public string GetId()
    {
        return this.Id;
    }

    public DateTime GetCreatTime()
    {
        return this.CreatTime;
    }

    public decimal GetBalance()
    {
        return this.Balance;
    }

    public DateTime GetBalanceLast()
    {
        return this.BalanceLastModifiedTime;
    }

    public void IncreaseBalance(decimal increaseAmount)
    {
        if (increaseAmount.CompareTo(decimal.Zero) < 0)
        {
            throw new InvalidCastException(",,,");
        }

        this.Balance += increaseAmount;
        this.BalanceLastModifiedTime = System.DateTime.Now;
    }

    public void DecreaseBalance(decimal decreaseAnount)
    {
        if (decreaseAnount.CompareTo(decimal.Zero) < 0)
        {
            throw new SystemException(",,,");
        }

        if (decreaseAnount.CompareTo(this.Balance) > 0)
        {
            throw new SystemException(",,,");
        }

        this.Balance -= decreaseAnount;
        this.BalanceLastModifiedTime = System.DateTime.Now;
    }
}

#endregion

#region 2. 抽象示例代码

public interface IPictoreStorage
{
    void SavePicture(string picture);
    string GetPicture(string pictureID);
    void DeletePicture(string pictureID);
    void ModifyMetaInfo(string pictureID, string MetaInfo);
}

public class PictureStorage : IPictoreStorage
{
    public void DeletePicture(string pictureID)
    {
        throw new NotImplementedException();
    }

    public string GetPicture(string pictureID)
    {
        throw new NotImplementedException();
    }

    public void ModifyMetaInfo(string pictureID, string MetaInfo)
    {
        throw new NotImplementedException();
    }

    public void SavePicture(string picture)
    {
        throw new NotImplementedException();
    }
}

#endregion

#region 3. 继承示例代码


#endregion

#region 4. 多态示例代码1——继承+方法重写

public class DynamicArray
{
    private static int CAPACITY = 10;
    protected int size = 0;
    protected int capacity = CAPACITY;
    protected int[] elements = new int[CAPACITY];

    public int Size()
    {
        return this.size;
    }

    public int Get(int index)
    {
        return elements[index];
    }

    public void Add(int e)
    {
        EnsureCapacity();
        elements[size++] = e;
    }

    protected void EnsureCapacity()
    {
        //如果数组满了扩容
    }
}

public class SortedDynamicArray : DynamicArray
{
    public void Add(int e)
    {
        EnsureCapacity();
        int i;
        for (i = size - 1; i >= 0; i--)
        {
            if (elements[i] > e)
            {
                elements[i + 1] = elements[i];
            }
            else
            {
                break;
            }
        }

        elements[i + 1] = e;
        size++;
    }
}

public class Example4
{
    public static void Test(DynamicArray dynamicArray)
    {
        dynamicArray.Add(5);
        dynamicArray.Add(1);
        dynamicArray.Add(3);

        for (int i = 0; i < dynamicArray.Size(); i++)
        {
            Console.WriteLine(dynamicArray.Get(i));
        }
    }

    public static void Main(string args)
    {
        DynamicArray dynamicArray = new SortedDynamicArray();
        Test(dynamicArray);

        // print 1,3,5
    }
}

#endregion

#region 5. 多态示例代码2——接口类语法

public interface ITerator
{
    bool HasNext();
    string Next();
    string Remove();
}

public class Array : ITerator
{
    public bool HasNext()
    {
        throw new NotImplementedException();
    }

    public string Next()
    {
        throw new NotImplementedException();
    }

    public string Remove()
    {
        throw new NotImplementedException();
    }
}

public class LinkedList : ITerator
{
    public bool HasNext()
    {
        throw new NotImplementedException();
    }

    public string Next()
    {
        throw new NotImplementedException();
    }

    public string Remove()
    {
        throw new NotImplementedException();
    }
}

public class Example5
{
    public static void Main(string args)
    {
        ITerator arrayITerator = new Array();
        ITerator LinkedListITerator = new LinkedList();

        print(arrayITerator);
        print(LinkedListITerator);
    }

    public static void print(ITerator iterator)
    {
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}

#endregion