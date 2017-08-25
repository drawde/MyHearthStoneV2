using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.BLL
{
    public class LoginTokenBll : BaseBLL<HS_LoginToken>
    {
        private IRepository<HS_LoginToken> _repository = new Repository<HS_LoginToken>();
        private LoginTokenBll()
        {
        }
        public static LoginTokenBll Instance = new LoginTokenBll();

        /// <summary>
        /// 根据userCode获取登录记录
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public HS_LoginToken GetTokenByUserID(string userCode)
        {
            var task = _repository.Get(c => c.UserCode == userCode).Result;
            if (task.TotalItemsCount > 0)
                return task.Items.First();
            return null;
        }
        /// <summary>
        /// 根据Token获取登录记录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public HS_LoginToken GetUserInfoByToken(string token)
        {
            var result = _repository.Get(c => c.Token == token).Result;
            if (result.TotalItemsCount > 0)
                return result.Items.First();
            return null;
        }
    }
}
