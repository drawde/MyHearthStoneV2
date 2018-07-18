using BattleForAzeroth.Game.Cache;
using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Spell;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Util;
using Newtonsoft.Json;
using System.Linq;

namespace BattleForAzeroth.Game.Controler.Proxy
{
    public partial class Controller_Base_Proxy
    {
        /// <summary>
        /// 打出一张法术牌
        /// </summary>
        /// <param name="gameCode"></param>
        /// <param name="userCode"></param>
        /// <param name="cardInGameCode"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public string CastSpell(string gameCode, string userCode, string cardInGameCode, int target)
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

            Card card = player.HandCards.First(c => c.CardInGameCode == cardInGameCode);

            if (player.Power < card.Cost)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.没有足够的法力值));
            }
            if (card.CastCardPrecondition == CastCardPrecondition.健康 && target > -1)
            {
                BaseBiology biology = ctl.GameContext.DeskCards[target];
                if (biology.Life != biology.BuffLife)
                {
                    return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.错误的目标));
                }
            }
            if (card.CastCardPrecondition == CastCardPrecondition.装备有武器 && ctl.GameContext.GetHeroByActivation().Equip == null)
            {
                return JsonConvert.SerializeObject(JsonModelResult.PackageFail(OperateResCodeEnum.你无法施放这个技能));
            }
            ctl.CastSpell((BaseSpell)card, target);
            return JsonConvert.SerializeObject(JsonModelResult.PackageSuccess(_gameCache.GetContext(ctl.GameContext.GameCode).Output()));
        }
    }
}
