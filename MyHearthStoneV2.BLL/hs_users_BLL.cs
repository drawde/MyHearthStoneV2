



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.Common;
using MyHearthStoneV2.Common.Enum;

namespace MyHearthStoneV2.BLL
{

    public class hs_users_BLL : BaseBLL<hs_users>
    {
        private IRepository<hs_users> _repository = new Repository<hs_users>();
        public string Register(string userName, string pwd, string mobile, string email, string invitationCode)
        {
            hs_invitation_BLL invBll = new hs_invitation_BLL();
            if (userName.IsNullOrEmpty() || pwd.IsNullOrEmpty() || invitationCode.IsNullOrEmpty())
            {
                return OperateJsonRes.Error(OperateResCodeEnum.参数错误);
            }
            if (IsRepeat(userName))
            {
                return OperateJsonRes.Error(OperateResCodeEnum.用户名重复);
            }
            if (!mobile.IsNullOrEmpty() && IsRepeat(mobile))
            {
                return OperateJsonRes.Error(OperateResCodeEnum.手机号重复);
            }
            if (!email.IsNullOrEmpty() && IsRepeat(email))
            {
                return OperateJsonRes.Error(OperateResCodeEnum.邮箱重复);
            }
            string userCode = SignUtil.CreateSign(userName + invitationCode + DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (invBll.GetInvitation(invitationCode, userCode) == null)
            {
                return OperateJsonRes.Error(OperateResCodeEnum.参数错误);
            }
            hs_users user = new hs_users();
            user.AddTime = DateTime.Now;
            user.Email = email.TryParseString();
            user.Mobile = mobile.TryParseString();
            user.Password = SignUtil.CreateSign(pwd);
            user.UserCode = userCode;
            user.UserName = userName;            
            _repository.Insert(user);
            return OperateJsonRes.SuccessResult();
        }
        public bool IsRepeat(string userName)
        {
            var res = _repository.Get(c => c.UserName == userName).Result;
            return res.TotalItemsCount > 0;
        }
        public bool IsMobileRepeat(string mobile)
        {
            var res = _repository.Get(c => c.Mobile == mobile).Result;
            return res.TotalItemsCount > 0;
        }
        public bool IsEmailRepeat(string email)
        {
            var res = _repository.Get(c => c.Email == email).Result;
            return res.TotalItemsCount > 0;
        }
        public bool IsUserCodeRepeat(string userCode)
        {
            var res = _repository.Get(c => c.UserCode == userCode).Result;
            return res.TotalItemsCount > 0;
        }
    }
}
