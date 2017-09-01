using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.BLL
{
    public class SystemConfigBll : BaseBLL<HS_SystemConfig>
    {
        private IRepository<HS_SystemConfig> _repository = new Repository<HS_SystemConfig>();
        private SystemConfigBll()
        {
        }
        public static SystemConfigBll Instance = new SystemConfigBll();

        public List<HS_SystemConfig> GetListByKey(string key)
        {
            return _repository.Get(c => c.ConfigKey == key).Result.Items.ToList();
        }
        public List<HS_SystemConfig> GetAll()
        {
            return _repository.Get().Result.Items.ToList();
        }

        public string GetValueByKey(string key)
        {
            return _repository.Get(c => c.ConfigKey == key).Result.Items.First().ConfigValue;
        }

        public string GetValueByCache(string key)
        {
            try
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    return redisClient.Get<string>(key);
                }
            }
            catch (Exception)
            {
                
            }
            return "";
        }
    }
}

