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
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Hero;
using EntityFramework.Extensions;
namespace MyHearthStoneV2.BLL
{
    public class UserCardGroupBll : BaseBLL<HS_UserCardGroup>
    {
        private IRepository<HS_UserCardGroup> _repository = new Repository<HS_UserCardGroup>();
        private UserCardGroupBll()
        {
        }
        public static UserCardGroupBll Instance = new UserCardGroupBll();

        /// <summary>
        /// 获取玩家卡组
        /// </summary>
        /// <param name="groupCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public HS_UserCardGroup GetCardGroup(string groupCode, string userCode)
        {
            var where = LDMFilter.True<HS_UserCardGroup>();
            where = where.And(c => c.GroupCode == groupCode && c.UserCode == userCode);
            var res = _repository.Get(where).Result;
            return res.TotalItemsCount > 0 ? res.Items.First() : null;
        }

        public IPagedItemsResult<HS_UserCardGroup> GetCardGroups(string userCode)
        {
            var where = LDMFilter.True<HS_UserCardGroup>();
            where = where.And(c => c.UserCode == userCode);
            return _repository.Get(where).Result;            
        }

        /// <summary>
        /// 创建或修改卡组
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="GroupCode"></param>
        /// <param name="GroupName"></param>
        /// <param name="Cards"></param>
        /// <returns></returns>
        public APITextResult AddOrUpdateCardGroup(string UserCode, string GroupCode, string GroupName,string Profession, string Cards)
        {
            if (UserCode.IsNullOrEmpty() || GroupName.IsNullOrEmpty() || Cards.IsNullOrEmpty() || Profession.IsNullOrEmpty() || Cards.Split(',').Length < 1)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }

            List<Card> lstCards = CardUtil.GetCardInRedis();
            string[] cardsArr = Cards.Split(',');
            int cardCount = 0;
            Dictionary<Card, int> dicCardGroup = new Dictionary<Card, int>();
            foreach (string cardstr in cardsArr)
            {
                string cardCode = cardstr.Substring(0, cardstr.LastIndexOf("X")).Trim();
                if (!lstCards.Any(c => c.CardCode == cardCode && c is BaseHero == false))
                {
                    return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
                }
                int count = cardstr.Substring(cardstr.LastIndexOf("X") + 1).Trim().TryParseInt();
                cardCount += count;
                dicCardGroup.Add(lstCards.First(c => c.CardCode == cardCode), count);
            }
            if (cardCount != 30)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            #region 验证卡牌是否有效
            #endregion
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                HS_UserCardGroup cardGroupModel = new HS_UserCardGroup();
                if (!GroupCode.IsNullOrEmpty())
                {
                    cardGroupModel = context.hs_usercardgroup.First(c => c.UserCode == UserCode && c.GroupCode == GroupCode);
                    if (cardGroupModel == null)
                    {
                        return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
                    }
                    context.hs_usercardgroupdetail.Where(c => c.GroupCode == GroupCode).Delete();
                    //context.hs_usercardgroupdetail.Where(c => c.GroupCode == GroupCode).ToList().RemoveAll(c => true);
                    cardGroupModel.GroupName = GroupName;
                    cardGroupModel.Profession = Profession;
                }
                else
                {
                    cardGroupModel.AddTime = DateTime.Now;
                    cardGroupModel.UserCode = UserCode;
                    cardGroupModel.GroupName = GroupName;
                    cardGroupModel.Profession = Profession;
                    cardGroupModel.GroupCode = SignUtil.CreateSign(UserCode + DateTime.Now.ToString("yyyyMMddHHmmss") + RandomUtil.CreateRandomStr(5));
                    context.hs_usercardgroup.Add(cardGroupModel);
                }

                foreach (var dic in dicCardGroup)
                {
                    for (int i = 0; i < dic.Value; i++)
                    {
                        HS_UserCardGroupDetail detail = new HS_UserCardGroupDetail();
                        detail.AddTime = DateTime.Now;
                        detail.CardBorder = 1;
                        detail.CardCode = dic.Key.CardCode;
                        detail.CardName = dic.Key.Name;
                        detail.Cost = dic.Key.Cost;
                        detail.GroupCode = cardGroupModel.GroupCode;
                        detail.UserCode = UserCode;
                        context.hs_usercardgroupdetail.Add(detail);
                    }
                }
                context.SaveChanges();
            }
            return JsonModelResult.PackageSuccess();
        }
    }
}
