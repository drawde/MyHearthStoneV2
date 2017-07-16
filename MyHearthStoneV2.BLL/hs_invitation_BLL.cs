

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

namespace MyHearthStoneV2.BLL
{
    public class hs_invitation_BLL : BaseBLL<hs_invitation>
    {
        private IRepository<hs_invitation> _repository = new Repository<hs_invitation>();
        public string CreateInvitationCode(string userCode)
        {
            hs_users_BLL userBll = new hs_users_BLL();
            if (userCode.IsNullOrEmpty() || !userBll.IsUserCodeRepeat(userCode))
            {
                return OperateJsonRes.Error(Common.Enum.OperateResCodeEnum.参数错误);
            }
            if (GetInvitation(userCode) != null)
            {
                return OperateJsonRes.Error(Common.Enum.OperateResCodeEnum.参数错误);
            }
            string code = SignUtil.CreateSign(userCode + DateTime.Now.ToString("yyyyMMddHHmmss"));
            hs_invitation invitation = new hs_invitation();
            invitation.AddTime = DateTime.Now;
            invitation.FromUserCode = userCode;
            invitation.InvitationCode = code;
            invitation.Status = (int)InvitationStatus.未使用;
            invitation.ToUserCode = "";
            _repository.Insert(invitation);
            return OperateJsonRes.SuccessResult(code);
        }

        public hs_invitation GetInvitation(string userCode, InvitationStatus status = InvitationStatus.无)
        {
            var where = LDMFilter.True<hs_invitation>();
            where = where.And(c => c.FromUserCode == userCode);
            if (status != InvitationStatus.无)
            {
                where = where.And(c => c.Status == (int)status);
            }
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }
        public hs_invitation GetInvitation(string invitationCode, string userCode)
        {
            var where = LDMFilter.True<hs_invitation>();
            where = where.And(c => c.InvitationCode == invitationCode && c.Status == (int)InvitationStatus.未使用 && c.FromUserCode != userCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }
    }
}
