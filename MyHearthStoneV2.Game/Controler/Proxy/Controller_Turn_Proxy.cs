using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Game.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static APIResultBase TurnEnd(string gameCode, string userCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnEnd();
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }

        /// <summary>
        /// 回合结束
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public static APIResultBase TurnStart(string gameCode, string userCode)
        {
            string res = JsonStringResult.VerifyFail();
            Controler_Base ctl = Validate(gameCode, userCode);
            if (ctl == null)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }
            var player = ctl.GameContext.GetActivationUserContext();
            if (player == null || player.UserCode != userCode)
            {
                return JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据);
            }

            ctl.TurnStart();
            return JsonModelResult.PackageSuccess(GameContextCache.GetContext(ctl.GameContext.GameCode).Output());
        }
    }
}
