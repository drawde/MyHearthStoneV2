﻿using System;
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
    public class HS_UsersBll : BaseBLL<HS_Users>
    {
        private IRepository<HS_Users> _repository = new Repository<HS_Users>();
        private HS_UsersBll()
        {
        }
        public static HS_UsersBll Instance = new HS_UsersBll();
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>用户实体</returns>
        public HS_Users GetUser(string userCode)
        {
            var res = _repository.Get(c => c.UserCode == userCode).Result;
            if (res.TotalItemsCount > 0)
                return res.Items.First();
            return null;
        }

        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户实体</returns>
        public HS_Users GetUserByUserName(string userName)
        {
            var res = _repository.Get(c => c.UserName == userName).Result;
            if (res.TotalItemsCount > 0)
                return res.Items.First();
            return null;
        }

        public string Register(string userName, string pwd, string mobile, string email, string invitationCode)
        {
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
            if (HS_InvitationBll.Instance.GetInvitation(invitationCode, userCode) == null)
            {
                return OperateJsonRes.Error(OperateResCodeEnum.参数错误);
            }
            HS_Users user = new HS_Users();
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
