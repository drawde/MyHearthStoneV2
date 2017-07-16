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
    public class HS_InvitationBll : BaseBLL<HS_Invitation>
    {
        private IRepository<HS_Invitation> _repository = new Repository<HS_Invitation>();
        public string CreateInvitationCode(string userCode)
        {
            HS_UsersBll userBll = new HS_UsersBll();
            if (userCode.IsNullOrEmpty() || !userBll.IsUserCodeRepeat(userCode))
            {
                return OperateJsonRes.Error(Common.Enum.OperateResCodeEnum.参数错误);
            }
            if (GetInvitation(userCode) != null)
            {
                return OperateJsonRes.Error(Common.Enum.OperateResCodeEnum.参数错误);
            }
            string code = SignUtil.CreateSign(userCode + DateTime.Now.ToString("yyyyMMddHHmmss"));
            HS_Invitation invitation = new HS_Invitation();
            invitation.AddTime = DateTime.Now;
            invitation.FromUserCode = userCode;
            invitation.InvitationCode = code;
            invitation.Status = (int)InvitationStatus.未使用;
            invitation.ToUserCode = "";
            _repository.Insert(invitation);
            return OperateJsonRes.SuccessResult(code);
        }

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
        public HS_Invitation GetInvitation(string invitationCode, string userCode)
        {
            var where = LDMFilter.True<HS_Invitation>();
            where = where.And(c => c.InvitationCode == invitationCode && c.Status == (int)InvitationStatus.未使用 && c.FromUserCode != userCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }
    }
}
