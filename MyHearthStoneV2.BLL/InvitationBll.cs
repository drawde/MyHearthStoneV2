using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.ShortCodeBll;

namespace MyHearthStoneV2.BLL
{
    public class InvitationBll : BaseBLL<HS_Invitation>
    {
        private IRepository<HS_Invitation> _repository = new Repository<HS_Invitation>();

        private InvitationBll()
        {
        }
        public static InvitationBll Instance = new InvitationBll();

        /// <summary>
        /// 创建邀请码
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public string CreateInvitationCode(string userCode)
        {
            string superAdminUserCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                superAdminUserCode = redisClient.Get<string>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SuperAdminUserCode));
            }
            if (userCode.IsNullOrEmpty() || superAdminUserCode != userCode)
            {
                if (userCode.IsNullOrEmpty() || !UsersBll.Instance.IsUserCodeRepeat(userCode))
                {
                    return JsonStringResult.Error(Common.Enum.OperateResCodeEnum.参数错误);
                }
                if (GetInvitation(userCode) != null)
                {
                    return JsonStringResult.Error(Common.Enum.OperateResCodeEnum.参数错误);
                }
            }
            string code = ShortCodeBusiness.Instance.CreateCode(ShortCodeTypeEnum.InvitationCode, userCode);

            HS_Invitation invitation = new HS_Invitation();
            invitation.AddTime = DateTime.Now;
            invitation.FromUserCode = userCode;
            invitation.InvitationCode = code;
            invitation.Status = (int)InvitationStatus.未使用;
            invitation.ToUserCode = "";
            _repository.Insert(invitation);
            return JsonStringResult.SuccessResult(code);
        }

        /// <summary>
        /// 根据用户获取邀请码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public HS_Invitation GetInvitation(string userCode, InvitationStatus status = InvitationStatus.无)
        {
            var where = LDMFilter.True<HS_Invitation>();
            where = where.And(c => c.FromUserCode == userCode);
            if (status != InvitationStatus.无)
            {
                where = where.And(c => c.Status == (int)status);
            }
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }

        /// <summary>
        /// 验证邀请码是否可用
        /// </summary>
        /// <param name="invitationCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public HS_Invitation GetInvitation(string invitationCode, string userCode)
        {
            var where = LDMFilter.True<HS_Invitation>();
            where = where.And(c => c.InvitationCode == invitationCode && c.Status == (int)InvitationStatus.未使用 && c.FromUserCode != userCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }

        public bool IsRepeatCode(string invitationCode)
        {
            var where = LDMFilter.True<HS_Invitation>();
            where = where.And(c => c.InvitationCode == invitationCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0;
        }
    }
}
