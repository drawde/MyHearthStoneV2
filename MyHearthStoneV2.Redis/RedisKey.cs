using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Redis
{
    /// <summary>
    /// 用于获取Redis的键
    /// </summary>
    public class RedisKey
    {
        public static string GetKey(RedisAppKeyEnum appKey, RedisCategoryKeyEnum categoryKey, string key = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(appKey.ToString());
            sb.Append(".");
            sb.Append(categoryKey.ToString());

            if (string.IsNullOrWhiteSpace(key) == false)
                sb.Append("." + key);
            return sb.ToString();
        }        
    }
}
