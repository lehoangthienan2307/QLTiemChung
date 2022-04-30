using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class Algorithm
{
    /// <summary>
    /// convert string to int
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static int myAtoi(string input)
    {
        string lookUpTable = "0123456789";
        int num = 0;
        bool isNegative = false;
        foreach (char c in input)
        {
            if (c == '-')
            {
                isNegative = true;
                continue;
            }
            if (c == ' ') continue;
            try
            {
                int value = lookUpTable.IndexOf(c);
                if (value < 0) { continue; }
                num = checked(num * 10);
                num += lookUpTable.IndexOf(c);
            }
            catch (OverflowException)
            {
                if (isNegative)
                {
                    return int.MinValue;
                }
                else
                {
                    return int.MaxValue - 1;
                }
            }
        }
        if (isNegative) return num * -1;
        else return num;
    }
}


