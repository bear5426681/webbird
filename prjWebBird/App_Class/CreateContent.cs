using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateContent
{
    public class create_content
    {

        public string showID(string mid1, string mid2)
        {
            var result = "";
            if (mid1 != null)
            {
                result += mid1.Substring(0, 2);
                for (int i = 1; i <= mid1.Length - 4; i++)
                {
                    result += "*";
                }
                result += mid1.Substring(mid1.Length - 3);
            }
            if (mid2 != null)
            {
                result += "、";
                result += mid2.Substring(0, 2);
                for (int i = 1; i <= mid2.Length - 4; i++)
                {
                    result += "*";
                }
                result += mid2.Substring(mid2.Length - 3);
            }
            return result;
        }
    }
}