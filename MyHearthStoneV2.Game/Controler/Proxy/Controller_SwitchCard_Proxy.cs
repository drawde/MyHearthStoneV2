using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Context;

namespace MyHearthStoneV2.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 开场换牌
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="lstInitCardIndex"></param>
        /// <returns></returns>
        public static APIResultBase SwitchCard(string gameCode, string userCode, List<string> lstInitCardIndex)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            //if (ctl.TurnIndex != 2)
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            //}
            if (ctl.GameContext.Players.Any(c => c.UserCode == userCode && c.SwitchDone == false) == false)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            List<int> initCardIndex = new List<int>();
            foreach (string idx in lstInitCardIndex)
            {
                initCardIndex.Add(idx.TryParseInt());
            }
            if (initCardIndex.Any(c => c < 0 || c > 3) || initCardIndex.Any(c => c >= ctl.GameContext.Players.First(x => x.UserCode == userCode).InitCards.Count()))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            var idxGroup = initCardIndex.GroupBy(c => c);
            if (idxGroup.Any(c => c.Count() > 1))
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.参数错误);
            }
            ctl.SwitchCard(userCode, initCardIndex);
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output().Players.First(c => c.UserCode == userCode));
        }
    }
}
