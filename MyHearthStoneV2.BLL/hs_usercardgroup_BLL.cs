

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
    public class hs_usercardgroup_BLL : BaseBLL<HS_UserCardGroup>
    {
        private IRepository<HS_UserCardGroup> _repository = new Repository<HS_UserCardGroup>();
        private hs_usercardgroup_BLL()
        {
        }
        public static hs_usercardgroup_BLL Instance = new hs_usercardgroup_BLL();

        /// <summary>
        /// 获取玩家卡组
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public HS_UserCardGroup GetCardGroup(int id, string userCode)
        {
            var where = LDMFilter.True<HS_UserCardGroup>();
            where = where.And(c => c.ID == id && c.UserCode == userCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }
    }
}
