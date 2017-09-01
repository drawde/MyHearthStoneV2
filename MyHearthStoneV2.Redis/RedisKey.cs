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
        public static string GetKey(RedisAppKeyEnum appKey, RedisCategoryKeyEnum categoryKey)
        {
            return appKey.ToString() + "." + categoryKey.ToString();
        }

        
    }
}
