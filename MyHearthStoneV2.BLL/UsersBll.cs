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
using MyHearthStoneV2.Model.CustomModels;

namespace MyHearthStoneV2.BLL
{
    public class UsersBll : BaseBLL<HS_Users>
    {
        private IRepository<HS_Users> _repository = new Repository<HS_Users>();
        private UsersBll()
        {
        }
        public static UsersBll Instance = new UsersBll();

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <returns>用户实体</returns>
        public CUsers GetUser(string userCode)
        {
            var res = _repository.Get(c => c.UserCode == userCode).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.Select(c => new CUsers()
                {
                    UserCode = c.UserCode,
                    AddTime = c.AddTime,
                    Email = c.Email,
                    HeadImg = c.HeadImg,
                    Mobile = c.Mobile,
                    NickName = c.NickName,
                    UserName = c.UserName
                }).First();
            }
            return null;
        }

        public HS_Users GetUserByAdmin(string userCode)
        {
            var res = _repository.Get(c => c.UserCode == userCode).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.First();
            }
            return null;
        }

        /// <summary>
        /// 根据用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户实体</returns>
        public CUsers GetUserByUserName(string userName)
        {
            var res = _repository.Get(c => c.UserName == userName).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.Select(c => new CUsers()
                {
                    UserCode = c.UserCode,
                    AddTime = c.AddTime,
                    Email = c.Email,
                    HeadImg = c.HeadImg,
                    Mobile = c.Mobile,
                    NickName = c.NickName,
                    UserName = c.UserName
                }).First();
            }
            return null;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="invitationCode"></param>
        /// <param name="nickName"></param>
        /// <param name="headImg"></param>
        /// <returns></returns>
        public string Register(string userName, string pwd, string mobile, string email, string invitationCode, string nickName, string headImg = "")
        {
            if (userName.IsNullOrEmpty() || pwd.IsNullOrEmpty() || invitationCode.IsNullOrEmpty() || nickName.IsNullOrEmpty())
            {
                return OperateJsonRes.Error(OperateResCodeEnum.参数错误);
            }
            if (!StringUtil.IsNatural_Number(userName))
            {
                return OperateJsonRes.Error(OperateResCodeEnum.参数错误);
            }
            if (IsRepeat(userName))
            {
                return OperateJsonRes.Error(OperateResCodeEnum.用户名重复);
            }
            //if (!mobile.IsNullOrEmpty() && IsMobileRepeat(mobile))
            //{
            //    return OperateJsonRes.Error(OperateResCodeEnum.手机号重复);
            //}
            //if (!email.IsNullOrEmpty() && IsEmailRepeat(email))
            //{
            //    return OperateJsonRes.Error(OperateResCodeEnum.邮箱重复);
            //}
            string userCode = SignUtil.CreateSign(userName + RandomUtil.CreateRandomStr(10) + invitationCode + DateTime.Now.ToString("yyyyMMddHHmmss"));
            var invitation = InvitationBll.Instance.GetInvitation(invitationCode, userCode);
            if (invitation == null)
            {
                return OperateJsonRes.Error(OperateResCodeEnum.邀请码错误);
            }
            HS_Users user = new HS_Users();
            user.AddTime = DateTime.Now;
            user.Email = email.TryParseString();
            user.Mobile = mobile.TryParseString();
            user.Password = SignUtil.CreateSign(pwd);
            user.UserCode = userCode;
            user.UserName = userName;
            user.NickName = nickName;
            user.HeadImg = headImg.TryParseString();
            user.SecretCode = SignUtil.CreateSign(user.UserName + user.UserCode + RandomUtil.CreateRandomStr(10) + DateTime.Now.Ticks);
            _repository.Insert(user);

            invitation.ToUserCode = userCode;
            invitation.Status = (int)InvitationStatus.已使用;
            InvitationBll.Instance.Update(invitation);
            return OperateJsonRes.SuccessResult(user.UserCode);
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

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginName">用户名或手机号</param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public CUsers Login(string loginName,string pwd)
        {
            pwd = SignUtil.CreateSign(pwd);
            var res = _repository.Get(c => (c.UserName == loginName || c.Mobile == loginName) && c.Password == pwd).Result;
            if (res.TotalItemsCount > 0)
            {
                return res.Items.Select(c => new CUsers()
                {
                    UserCode = c.UserCode,
                    AddTime = c.AddTime,
                    Email = c.Email,
                    HeadImg = c.HeadImg,
                    Mobile = c.Mobile,
                    NickName = c.NickName,
                    UserName = c.UserName
                }).First();
            }
            return null;
        }
    }
}
