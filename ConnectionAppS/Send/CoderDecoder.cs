using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionAppS.Send
{
    public static class CoderDecoder
    {
        private static List<bool> XORN(List<bool> a, List<bool> b)
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < b.Count; i++)
            {
                result.Add(a[i] ^ b[i]);
            }
            return result;
        }
        public static List<bool> BinaryDivision(List<bool> divident, List<bool> divisor)
        {
            int pick = divisor.Count;
            List<bool> temp = new List<bool>();
            for (int i = 0; i < pick; i++)
            {
                temp[i] = divident[i];
            }
            List<bool> zeroWorld = new List<bool>();
            for (int i = 0; i < pick; i++)
            {
                zeroWorld.Add(false);
            }
            while (pick < divident.Count)
            {
                if (temp[0] == true)
                {
                    temp = XORN(divisor, temp);
                }
                else
                {
                    temp = XORN(zeroWorld, temp);
                }
                temp.Append(divident[pick]);
                temp.Remove(temp.First());
                pick++;
            }
            if (temp[0] == true)
            {
                temp = XORN(divisor, temp);
            }
            else
            {
                temp = XORN(zeroWorld, temp);
            }
            temp.Remove(temp.First());
            return temp;
        }
        public static List<bool> Endcode(List<bool> toEncodeList, List<bool> genpolList)
        {
            List<bool> encodedList = toEncodeList;
            for (int i = 0; i < 4; i++)
            {
                encodedList.Append(false);
            }
            List<bool> remainder = BinaryDivision(encodedList, genpolList);
            for (int i = 0; i < 4; i++)
            {
                encodedList.Append(remainder[i]);
            }
            return encodedList;
        }
        public static List<bool> Decode(List<bool> toDecodeList, List<bool> genpolList)
        {
            List<bool> reaminder = BinaryDivision(toDecodeList, genpolList);
            return reaminder;
        }
    }
}
