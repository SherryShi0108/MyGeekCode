//Source  : https://time.geekbang.org/column/article/71840
//Date    : 2019-07-01
//Language: C#


public class _01_BinarySystem
{
    //HexBinDecOct
    public void HexBinDecOct()
    {
        int d = 4;
        //10->2 (int->string)
        System.Convert.ToString(d, 2);
        //10->16 (int->string)
        System.Convert.ToString(d, 16);
        string.Format("{0:x}", d);

        string s = "1010";
        //2->10 (string->int)
        System.Convert.ToInt32(s,2);
        //2->16 (string->int)(2->10->16)
        string.Format("{0:x}",System.Convert.ToInt32(s, 2));

        int h1 = 0x14;
        string h2 = "0x14";
        //16->2 (int->string)
        System.Convert.ToString(h1, 2);
        //16->10 (string->int int->int)
        System.Convert.ToString(h1, 10);
        System.Convert.ToInt32(h2, 16);
    }
    public string DecimalToBinary(int m)
    {
        return System.Convert.ToString(m, 2);
    }    
    public int BinaryToDecimal(string m)
    {
        return System.Convert.ToInt32(m, 2);
    }

    //Bit-shift
    public int BitLeftShift(int num, int n)
    {
        return num << n;
    }
    public int BitRightShift(int num, int n)
    {
        return num >> n;
    }

    // and or nor
    public int And(int m,int n)
    {
        return m & n;
    }
    public int Or(int m, int n)
    {
        return m | n;
    }
    public int Nor(int m, int n)
    {
        return m ^ n;
    }

    public string DecimalToBinary_Bit(int m)
    {
        string x="";
        while (m != 0)
        {
            int k= m & 1;
            x = x + k.ToString();
            m = m >> 1;
        }
        // x=x.reserve();
        return x;
    }
}

