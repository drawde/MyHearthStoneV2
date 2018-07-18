using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleForAzeroth.Game.Util
{
    /// <summary>
    /// 随机数工具
    /// </summary>
    public class RandomUtil
    {
        /// <summary>
        /// 随机字符字典
        /// </summary>
        public const string RANDOMDICTIONARY = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string VERIFICATIONCODE = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string CreateVerificationCode(int Length)
        {
            string result = string.Empty;
            List<int> lstIndex = CreateRandomInt(0, VERIFICATIONCODE.Length - 1, Length, true);
            for (int i = 0; i < lstIndex.Count; i++)
            {
                result += VERIFICATIONCODE[lstIndex[i]];
            }
            return result;
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string CreateRandomStr(int Length)
        {
            string result = string.Empty;
            List<int> lstIndex = CreateRandomInt(0, RANDOMDICTIONARY.Length - 1, Length, true);
            for (int i = 0; i < lstIndex.Count; i++)
            {
                result += RANDOMDICTIONARY[lstIndex[i]];
            }
            return result;
        }
        /// <summary>
        /// 生成指定个数、大小范围的随机数
        /// </summary>
        /// <param name="minVal">最小值</param>
        /// <param name="maxVal">最大值</param>
        /// <param name="count">生成个数</param>
        /// <param name="isRepeat">是否允许重复</param>
        /// <returns></returns>
        public static List<int> CreateRandomInt(int minVal, int maxVal, int count, bool isRepeat = false)
        {
            List<int> lst = new List<int>();
            Random rm = new Random(GetRandomSeed());
            while(lst.Count() < count)
            {
                int nValue = rm.Next(minVal, maxVal);
                if (!lst.Any(c => c == nValue) || isRepeat)
                {
                    lst.Add(nValue);
                }
            }
            return lst;
        }

        /// <summary>
        /// 生成指定大小范围的不重复随机数
        /// </summary>
        /// <param name="minVal">最小值</param>
        /// <param name="maxVal">最大值</param>
        /// <returns></returns>
        public static int CreateRandomInt(int minVal, int maxVal)
        {
            return CreateRandomInt(minVal, maxVal, 1).FirstOrDefault();
        }
    }
}
