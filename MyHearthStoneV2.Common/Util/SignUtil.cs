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
    }
}
