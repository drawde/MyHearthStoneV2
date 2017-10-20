using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using System.Collections;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
namespace MyHearthStoneV2.BLL
{
    public class ShortCodeBll : BaseBLL<HS_ShortCode>
    {
        private IRepository<HS_ShortCode> _repository = new Repository<HS_ShortCode>();
        private ShortCodeBll()
        {
        }
        public static ShortCodeBll Instance = new ShortCodeBll();
        private static object obj = new object();

        public List<HS_ShortCode> GetList(string code = "", string data = "", ShortCodeTypeEnum codeType = ShortCodeTypeEnum.无)
        {
            LinkedList<HS_ShortCode> ht = null;
            try
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    ht = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
                    if (ht != null && ht.Count > 0)
                    {
                        var where = LDMFilter.True<HS_ShortCode>();
                        if (!code.IsNullOrEmpty())
                        {
                            where = where.And(c => c.Code == code);
                        }
                        if (!data.IsNullOrEmpty())
                        {
                            where = where.And(c => c.Data == data);
                        }
                        if (codeType != ShortCodeTypeEnum.无)
                        {
                            where = where.And(c => c.CodeType == (int)codeType);
                        }
                        return ht.AsQueryable().Where(where).ToList();
                    }
                }
            }
            catch (Exception)
            {
                return GetListFromDB(code, data, codeType);
            }
            return GetListFromDB(code, data, codeType);
        }

        public HS_ShortCode GetModel(string code = "", string data = "", ShortCodeTypeEnum codeType = ShortCodeTypeEnum.无)
        {
            LinkedList<HS_ShortCode> ht = null;
            try
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    ht = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
                    if (ht != null && ht.Count > 0)
                    {
                        var where = LDMFilter.True<HS_ShortCode>();
                        if (!code.IsNullOrEmpty())
                        {
                            where = where.And(c => c.Code == code);
                        }
                        if (!data.IsNullOrEmpty())
                        {
                            where = where.And(c => c.Data == data);
                        }
                        if (codeType != ShortCodeTypeEnum.无)
                        {
                            where = where.And(c => c.CodeType == (int)codeType);
                        }
                        return ht.AsQueryable().FirstOrDefault(where);
                    }
                }
            }
            catch (Exception)
            {
                return GetModelFromDB(code, data, codeType);
            }
            return GetModelFromDB(code, data, codeType);
        }

        public HS_ShortCode GetModelFromDB(string code = "", string data = "", ShortCodeTypeEnum codeType = ShortCodeTypeEnum.无)
        {
            var where = LDMFilter.True<HS_ShortCode>();
            if (!code.IsNullOrEmpty())
            {
                where = where.And(c => c.Code == code);
            }
            if (!data.IsNullOrEmpty())
            {
                where = where.And(c => c.Data == data);
            }
            if (codeType != ShortCodeTypeEnum.无)
            {
                where = where.And(c => c.CodeType == (int)codeType);
            }
            var res = _repository.GetList(where).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.FirstOrDefault();
            }
            return null;
        }

        public List<HS_ShortCode> GetListFromDB(string code = "", string data = "", ShortCodeTypeEnum codeType = ShortCodeTypeEnum.无)
        {
            var where = LDMFilter.True<HS_ShortCode>();
            if (!code.IsNullOrEmpty())
            {
                where = where.And(c => c.Code == code);
            }
            if (!data.IsNullOrEmpty())
            {
                where = where.And(c => c.Data == data);
            }
            if (codeType != ShortCodeTypeEnum.无)
            {
                where = where.And(c => c.CodeType == (int)codeType);
            }
            var res = _repository.GetList(where).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.ToList();
            }
            return null;
        }

        public HS_ShortCode GetOrCreate(string data, ShortCodeTypeEnum codeType)
        {
            HS_ShortCode code = GetModel("", data, codeType);
            if (code == null)
            {
                string shortCode = CreateCode(data, codeType);
                code = GetModel(shortCode);
            }
            return code;
        }

        /// <summary>
        /// 生成下一个短码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string CreateNextCode(string code)
        {
            string newCode = code;
            for (int i = code.Length - 1; i >= 0; i--)
            {
                int ascii = Encoding.ASCII.GetBytes(code[i].ToString())[0];

                switch (ascii)
                {
                    case 57: ascii = 65; break;
                    case 90: ascii = 97; break;
                    case 122: ascii = 48; break;
                    default: ascii++; break;
                }
                byte[] array = new byte[1];
                array[0] = (byte)(ascii);
                char[] chars = newCode.ToCharArray();
                chars[i] = Encoding.ASCII.GetChars(array)[0];
                newCode = new string(chars);
                if (ascii != 48)
                {
                    break;
                }
            }
            return newCode;
        }

        /// <summary>
        /// 生成短码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string CreateCode(string data, ShortCodeTypeEnum codeType)
        {
            string newCode = "";
            HS_ShortCode sc = null;
            lock (obj)
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    LinkedList<HS_ShortCode> ll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
                    sc = new HS_ShortCode();
                    sc.CodeType = (int)codeType;
                    sc.AddTime = DateTime.Now;
                    sc.Data = data;
                    sc.ID = 0;

                    //从缓存中获取最后一个code
                    if (ll != null && ll.Count > 0)
                    {
                        HS_ShortCode last = ll.Last.Value;
                        newCode = CreateNextCode(last.Code);
                    }
                    else
                    {
                        //缓存没有则从数据库中获取code
                        var dbLst = _repository.Get(c => 1 == 1, "ID", 1, 1, false).Result;
                        if (dbLst.TotalItemsCount > 0)
                        {
                            ll = new LinkedList<HS_ShortCode>();
                            newCode = CreateNextCode(dbLst.Items.First().Code);
                        }
                        else
                        {
                            //数据库也没有则创建从0开始的短码
                            ll = new LinkedList<HS_ShortCode>();
                            newCode = "00000";
                        }
                    }

                    sc.Code = newCode;
                    ll.AddLast(sc);
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey), ll);
                }
            }
            return newCode;
        }

        /// <summary>
        /// 将缓存中的数据保存到数据库
        /// </summary>
        public int SaveToDB()
        {
            int saveCount = 0;
            using (var redisClient = RedisManager.GetClient())
            {
                LinkedList<HS_ShortCode> ll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
                if (ll != null && ll.Count > 0)
                {
                    saveCount = ll.Count;
                    using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
                    {
                        LinkedListNode<HS_ShortCode> node = ll.First;
                        while (node != null)
                        {
                            context.hs_shortcode.Add(node.Value);
                            node = node.Next;
                        }
                        context.SaveChanges();
                    }
                    ll.Clear();
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey), ll);
                }
            }
            return saveCount;
        }
    }
}
