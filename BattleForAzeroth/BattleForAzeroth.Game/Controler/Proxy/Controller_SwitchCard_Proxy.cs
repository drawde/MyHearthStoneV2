using System.Collections.Generic;
using System.Linq;
using BattleForAzeroth.Game.Util;
using BattleForAzeroth.Game.Context;
using Newtonsoft.Json;

namespace BattleForAzeroth.Game.Controler.Proxy
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
        public string SwitchCard(string gameCode, string userCode, List<string> lstInitCardIndex, IShortCodeService shortCodeService)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            //if (ctl.TurnIndex != 2)
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            //}
            if (ctl.GameContext.Players.Any(c => c.UserCode == userCode && c.SwitchDone == false) == false)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            List<int> initCardIndex = new List<int>();
            foreach (string idx in lstInitCardIndex)
            {
                initCardIndex.Add(idx.TryParseInt());
            }
            if (initCardIndex.Any(c => c < 0 || c > 3) || initCardIndex.Any(c => c >= ctl.GameContext.Players.First(x => x.UserCode == userCode).InitCards.Count()))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            var idxGroup = initCardIndex.GroupBy(c => c);
            if (idxGroup.Any(c => c.Count() > 1))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            ctl.SwitchCard(userCode, initCardIndex, shortCodeService);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output().Players.First(c => c.UserCode == userCode)));
        }
    }
}
