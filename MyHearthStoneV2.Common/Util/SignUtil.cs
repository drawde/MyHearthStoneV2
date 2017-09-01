using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Common.Util
{
    public class SignUtil
    {
        /// <summary>
        /// 生成MD5签名
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CreateSign(string str)
        {
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //所有字符转为大写
            return sb.ToString().ToUpper();
        }

        /// <summary>
        /// 混淆字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConfusionString(string str, DateTime now)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                sb.Append(ConfusionString(str[i], now));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取混淆后的ASCII码
        /// </summary>
        /// <param name="ascii"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        private static int GetConfusionAscii(int ascii, DateTime now)
        {
            int offset = GetConfusionOffset(now);
            int dateTimeAscii = GetDateTimeAscII(now);
            int newAscii = ascii + dateTimeAscii - offset;

            //Log.Default.Debug("newAscii=ascii("+ ascii + ")+dateTimeAscii("+ dateTimeAscii + ")-offset("+ offset + ")" + newAscii);
            //int min = 33, max = 126;
            //int newAscii = ascii;
            //int offset = GetConfusionOffset(now);
            //if (newAscii + offset > max)
            //{
            //    if (newAscii - offset < min)
            //    {
            //        offset = offset % 10;
            //        newAscii += offset;
            //    }
            //    else
            //    {
            //        newAscii -= offset;
            //    }
            //}
            //else if (newAscii - offset < min)
            //{
            //    if (newAscii + offset > max)
            //    {
            //        offset = offset % 10;
            //        newAscii -= offset;
            //    }
            //    else
            //    {
            //        newAscii += offset;
            //    }
            //}
            //else
            //{
            //    newAscii += offset;
            //}
            //newAscii = newAscii == 60 ? newAscii + offset : newAscii;
            return newAscii;
        }

        /// <summary>
        /// 获取混淆步进
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        private static int GetConfusionOffset(DateTime now)
        {
            int offset = 0;
            string nums = now.Second.ToString() + now.Millisecond.ToString();
            foreach (char c in nums)
            {
                offset += c.TryParseInt();
            }
            //char[] strch = now.ToString("yyyyMMddHHmm").ToCharArray();
            //int maxOffset = 0;
            //if (offset == 0 || offset % 10 == 0)
            //{
            //    maxOffset = strch.Max().ToString().TryParseInt();
            //}

            //int newOffset = strch.Max(c => c < maxOffset).ToString().TryParseInt() + maxOffset + offset;
            return offset;
        }

        /// <summary>
        /// 根据时间获取AscII
        /// </summary>
        /// <param name="now"></param>
        /// <returns></returns>
        private static int GetDateTimeAscII(DateTime now)
        {
            int ascii = now.Millisecond % 10;
            return Encoding.ASCII.GetBytes(ascii.ToString())[0];
        }

        /// <summary>
        /// 混淆日期时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static List<string> ConfusionDateTime(DateTime dt, DateTime now)
        {
            List<string> confusionLst = new List<string>();            
            confusionLst.Add(ConfusionInt(dt.Year,now));
            confusionLst.Add(ConfusionInt(dt.Month, now));
            confusionLst.Add(ConfusionInt(dt.Day, now));
            confusionLst.Add(ConfusionInt(dt.Hour, now));
            confusionLst.Add(ConfusionInt(dt.Minute, now));
            confusionLst.Add(ConfusionInt(dt.Second, now));
            confusionLst.Add(ConfusionInt(dt.Millisecond, now));
            return confusionLst;
        }

        /// <summary>
        /// 混淆日期时间
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static List<string> ConfusionDateTime(DateTime dt, char offset)
        {
            List<string> confusionLst = new List<string>();
            confusionLst.Add(ConfusionInt(dt.Year, offset));
            confusionLst.Add(ConfusionInt(dt.Month, offset));
            confusionLst.Add(ConfusionInt(dt.Day, offset));
            confusionLst.Add(ConfusionInt(dt.Hour, offset));
            confusionLst.Add(ConfusionInt(dt.Minute, offset));
            confusionLst.Add(ConfusionInt(dt.Second, offset));
            confusionLst.Add(ConfusionInt(dt.Millisecond, offset));
            return confusionLst;
        }

        /// <summary>
        /// 混淆整数
        /// </summary>
        /// <param name="num"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ConfusionInt(int num, char offset)
        {
            StringBuilder numStr = new StringBuilder();
            foreach (char c in num.ToString())
            {
                int ascii = Encoding.ASCII.GetBytes(c.ToString())[0];
                ascii = Encoding.ASCII.GetBytes(offset.ToString())[0] + ascii - 57;
                //ascii = ascii == 60 ? 33 : ascii;
                byte[] array = new byte[1];
                array[0] = (byte)(ascii);
                numStr.Append(Encoding.ASCII.GetString(array));
            }
            return numStr.ToString();
        }

        /// <summary>
        /// 混淆整数
        /// </summary>
        /// <param name="num"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static string ConfusionInt(int num, DateTime now)
        {
            StringBuilder numStr = new StringBuilder();
            foreach (char c in num.ToString())
            {
                numStr.Append(ConfusionString(c, now));
            }
            return numStr.ToString();
        }

        /// <summary>
        /// 混淆字符串
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ConfusionString(char c, DateTime now)
        {            
            int ascii = Encoding.ASCII.GetBytes(c.ToString())[0];            
            int newAscii = GetConfusionAscii(ascii, now);
            
            //if (ascii >= 33 && ascii <= 79)
            //{
            //    ascii += 47;
            //}
            //else if (ascii >= 80 && ascii <= 126)
            //{
            //    ascii -= 47;
            //}

            byte[] array = new byte[1];
            array[0] = (byte)(newAscii);
            return Encoding.ASCII.GetString(array);            
        }
    }
}
