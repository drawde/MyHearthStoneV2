using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Util;
using Newtonsoft.Json;

namespace BattleForAzeroth.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public string TurnEnd(string gameCode, string userCode, IShortCodeService shortCodeService)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (VictoryValidate(ctl.GameContext))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束));
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            ctl.TurnEnd(shortCodeService);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }

        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public string TurnStart(string gameCode, string userCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (VictoryValidate(ctl.GameContext))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.游戏已经结束));
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            ctl.TurnStart();
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }
    }
}
