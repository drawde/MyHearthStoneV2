using BattleForAzeroth.Game.Cache;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Util;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BattleForAzeroth.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 将一名随从从手牌中移到场上
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public string CastServant(string gameCode, string userCode, string cardInGameCode, int location, int target)
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
            if (player.HandCards.Any(c => c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            if (location == 0 || location == 8)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }
            //if (ctl.GameContext.DeskCards[location] != null)
            //{
            //    return JsonModelResult.PackageFail(OperateResCodeEnum.位置已被占用);
            //}
            if (player.IsFirst && (location == 0 || location > 7))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            else if (player.IsFirst == false && (location == 8 || location < 8))
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);

            if (player.Power < card.Cost)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值));
            }

            ctl.CastServant((BaseServant)card, location, target);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }


        /// <summary>
        /// 随从发起攻击
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string ServantAttack(string gameCode, string userCode, string cardInGameCode, int target)
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

            if (ctl.GameContext.DeskCards.Any(c => c != null && c.CardInGameCode == cardInGameCode) == false)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            if (player.IsFirst && target < 8)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }
            else if (player.IsFirst == false && target > 7)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.参数错误));
            }

            BaseServant servant = ctl.GameContext.DeskCards.First(c => c != null && c.CardInGameCode == cardInGameCode) as BaseServant;
            if (servant.RemainAttackTimes < 1)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.查询不到需要的数据));
            }

            if (ctl.GameContext.DeskCards[target].HasTaunt == false)
            {
                List<BaseBiology> taunts = ctl.GameContext.DeskCards.GetDeskCardsByIsFirst(player.IsFirst ? false : true).Where(c => c != null && c.HasTaunt).ToList();
                for (int i = 0; i < taunts.Count; i++)
                {
                    if (taunts[i].HasTaunt && i != target)
                    {
                        return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.你必须先攻击有嘲讽技能的随从));
                    }
                }
            }
            ctl.ServantAttack(servant, target);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }
    }
}
