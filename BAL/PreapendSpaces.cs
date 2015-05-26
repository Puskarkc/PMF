using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMF.BAL
{
    public static class PreapendSpaces
    {
       
            public static string PrependSpaces(int Size, string str)
            {


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < (Size - str.Length); i++)
                {
                    sb.Append(" ");
                }
                sb.Append(str);
                return sb.ToString();
            }
        }
    
}
