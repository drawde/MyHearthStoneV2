using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.TestConsole
{
    public class ClassProxy
    {
        public static TestClass tc
        {
            get
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    return redisClient.Get<TestClass>("testkey");
                }
            }
            set
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set<TestClass>("testkey", value);
                }
            }
        }
    
    }
}
