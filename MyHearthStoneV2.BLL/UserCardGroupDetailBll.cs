

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;


namespace MyHearthStoneV2.BLL
{
    public class UserCardGroupDetailBll : BaseBLL<HS_UserCardGroupDetail>
    {
        private IRepository<HS_UserCardGroupDetail> _repository = new Repository<HS_UserCardGroupDetail>();
        private UserCardGroupDetailBll()
        {
        }
        public static UserCardGroupDetailBll Instance = new UserCardGroupDetailBll();

        /// <summary>
        /// 获取玩家卡组
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public List<HS_UserCardGroupDetail> GetCardGroup(string groupCode, string userCode)
        {
            var where = LDMFilter.True<HS_UserCardGroupDetail>();
            where = where.And(c => c.GroupCode == groupCode && c.UserCode == userCode);
            var res = _repository.Get(where).Result;
            return res.Items.ToList();
        }
    }
}
